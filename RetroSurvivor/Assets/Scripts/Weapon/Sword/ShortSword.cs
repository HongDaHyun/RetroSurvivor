using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSword : Weapon
{
    public override void Start()
    {
        type = EquipmentType.ShortSword;
        base.Start();
    }
}