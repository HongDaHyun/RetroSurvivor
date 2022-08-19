using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    ShortSword, LongSword
}

public enum TierType
{
    Raw, Common, Rare, Epic, Legend, Curse, Money
}

public enum TextType
{
    Chat, Dialogue, Option
}

[System.Serializable]
public class Equipment
{
    public EquipmentType equipType;
    public TierType tierType;
    public string name;
    public int id;
    public Sprite sprite;
    public GameObject prefab;
}

[System.Serializable]
public class BoxDB
{
    public TierType tierType;
    public int weight;
    public Sprite sprite;
    public Sprite openSprite;
}