using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Slime()
    {
        CurHealth = defHealth;
    }

    private void Stop()
    {
        agent.SetDestination(transform.position);
    }
}
