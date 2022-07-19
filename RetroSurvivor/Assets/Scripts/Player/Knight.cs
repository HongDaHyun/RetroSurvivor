using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player
{
    Knight()
    {
        Speed = 3f;
        PlayerAttackSpeed = 1.5f;
        Eyesight = -10;
        MaxHP = 100;
        Damage = 5f;
        SetStat();
    }
}

