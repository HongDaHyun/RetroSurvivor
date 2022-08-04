using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment, Consumables, Etc
}

[System.Serializable]
public class Item
{
    public ItemType type;
    public string name;
    public Sprite sprite;
}
