using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : Enemy
{
    public override void Start()
    {
        type = "Boss";
        base.Start();
    }
}
