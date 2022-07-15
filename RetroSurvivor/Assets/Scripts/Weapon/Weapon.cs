
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
    public ObjectManager objectManager;

    protected Player player;

    private void Awake()
    {
        player = transform.parent.gameObject.GetComponent<Player>();
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
    }
}