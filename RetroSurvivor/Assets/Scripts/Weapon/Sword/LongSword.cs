using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSword : Weapon
{
    public override void Start()
    {
        type = EquipmentType.LongSword;
        base.Start();
    }
}
