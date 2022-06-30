using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int damage;
    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
}
