
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
    private SpriteRenderer sprite;
    public SpriteRenderer  Sprite
    {
        get => sprite;
    }
    private Animator anim;
    public Animator Anim
    {
        get => anim;
    }
    public ObjectManager objectManager;

    protected Player player;

    public void Awake()
    {
        player = transform.root.GetComponent<Player>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
    }
}