using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Item item;
    public GameObject guideKey_F;
    bool isPickUp;

    SpriteRenderer spriteRenderer;
    ItemDatabase itemDatabase;
    Player player;
    UIManager uiManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemDatabase = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void Start()
    {
        SetItem(itemDatabase.itemDB[Random.Range(0, itemDatabase.itemDB.Count)]);
        if (item.type == ItemType.Equipment)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
            guideKey_F.transform.localPosition = new Vector2(1.5f, 0);
            guideKey_F.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnDisable()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        guideKey_F.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPickUp = true;
            guideKey_F.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPickUp = false;
            guideKey_F.SetActive(false);
        }
    }

    private void Update()
    {
        if(isPickUp && Input.GetKeyDown(KeyCode.F))
        {
            switch(item.type)
            {
                case ItemType.Equipment:
                    if (player.equipments.Count < 16)
                    {
                        player.equipments.Add(GetItem());
                        uiManager.RedrawEquipmentSlotUI();
                    }
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    public void SetItem(Item _item)
    {
        item.name = _item.name;
        item.sprite = _item.sprite;
        item.type = _item.type;

        spriteRenderer.sprite = _item.sprite;
    }

    public Item GetItem()
    {
        return this.item;
    }
}
