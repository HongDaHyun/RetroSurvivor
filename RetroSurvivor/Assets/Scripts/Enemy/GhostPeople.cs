using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPeople : Enemy
{
    GhostPeople()
    {
        Damage = 3;
        DefHealth = 10;
        CurHealth = DefHealth;
    }
}
