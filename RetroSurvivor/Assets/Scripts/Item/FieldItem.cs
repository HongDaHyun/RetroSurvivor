using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Equipment equipment;
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
        SetEquipment(itemDatabase.equipmentDB[Random.Range(0, itemDatabase.equipmentDB.Count)]);
        transform.localEulerAngles = new Vector3(0, 0, 90);
        guideKey_F.transform.localPosition = new Vector2(1.5f, 0);
        guideKey_F.transform.eulerAngles = new Vector3(0, 0, 0);
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
            if (player.equipments.Count < 16)
            {
                player.equipments.Add(GetEquipment());
                uiManager.RedrawEquipmentSlotUI();
            }

            gameObject.SetActive(false);
        }
    }

    public void SetEquipment(Equipment _equipment)
    {
        equipment.name = _equipment.name;
        equipment.sprite = _equipment.sprite;
        equipment.equipType = _equipment.equipType;
        equipment.tierType = _equipment.tierType;

        spriteRenderer.sprite = _equipment.sprite;
    }

    public Equipment GetEquipment()
    {
        return this.equipment;
    }
}
