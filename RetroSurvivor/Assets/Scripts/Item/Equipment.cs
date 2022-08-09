using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    ShortSword, LongSword
}

public enum TierType
{
    Raw, Common, Rare, Epic, Legend
}

[System.Serializable]
public class Equipment
{
    public EquipmentType equipType;
    public TierType tierType;
    public string name;
    public Sprite sprite;
    public GameObject prefab;
}
