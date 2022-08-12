using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public BoxDB boxDB;
    bool isOpen, opened;

    ItemDatabase itemDatabase;
    ObjectManager objectManager;
    UIManager uiManager;
    SpriteRenderer spriteRenderer;
    GameObject guideKey_F;

    private void Awake()
    {
        itemDatabase = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        guideKey_F = transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        SetBox(itemDatabase.boxDB[Random.Range(0, itemDatabase.boxDB.Count)]);
    }

    private void Update()
    {
        if(isOpen && !opened && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(OpenBox());
        }
    }

    private void OnDisable()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        Color c = spriteRenderer.material.color;
        c.a = 1;
        spriteRenderer.material.color = c;
        guideKey_F.SetActive(false);
        opened = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !opened)
        {
            isOpen = true;
            guideKey_F.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpen = false;
            guideKey_F.SetActive(false);
        }
    }

    public void SetBox(BoxDB _boxDB)
    {
        boxDB.tierType = _boxDB.tierType;
        boxDB.weight = _boxDB.weight;
        boxDB.sprite = _boxDB.sprite;
        boxDB.openSprite = _boxDB.openSprite;

        spriteRenderer.sprite = _boxDB.sprite;
    }

    IEnumerator OpenBox()
    {
        spriteRenderer.sprite = boxDB.openSprite;
        GameObject fieldItem = objectManager.MakeObj("FieldItem");
        fieldItem.transform.position = transform.position;
        opened = true;
        guideKey_F.SetActive(false);
        uiManager.Light();
        for(int i = 10; i >= 0; i--)
        {
            float f = i / 10.0f;
            Color c = spriteRenderer.material.color;
            c.a = f;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
