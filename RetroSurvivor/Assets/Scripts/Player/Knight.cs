using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player
{
    Knight()
    {
        Speed = 2.4f;
        Eyesight = -10;
        MaxHP = 100;
        SetStat();
    }
}

