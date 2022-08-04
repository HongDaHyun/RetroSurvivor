using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Item item;
    SpriteRenderer spriteRenderer;
    ItemDatabase itemDatabase;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemDatabase = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
    }

    private void Start()
    {
        SetItem(itemDatabase.itemDB[Random.Range(0, itemDatabase.itemDB.Count)]);
        if (item.type == ItemType.Equipment)
            transform.localEulerAngles = new Vector3(0, 0, 90);
    }

    private void OnDisable()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
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
