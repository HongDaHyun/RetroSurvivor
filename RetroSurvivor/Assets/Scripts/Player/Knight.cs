using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player
{
    Sword sword;

    Knight()
    {
        Speed = 2.4f;
        AttackSpeed = 1.5f;
        Eyesight = -10;
        MaxHP = 100;
        SetStat();
    }

    public override void Awake()
    {
        base.Awake();

        sword = GetComponent<Sword>();
    }

    public override void Update()
    {
        base.Update();

        Attack();
    }

    public void Attack()
    {
        if (Input.GetMouseButton(0) && CurAttackSpeed >= AttackSpeed)
        {
            sword.Attack(SwordList.ShortSword);
            CurAttackSpeed = 0;
        }
    }
}

