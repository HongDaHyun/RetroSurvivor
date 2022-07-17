
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int minDamage;
    public int MinDamage
    {
        get => minDamage;
        set => minDamage = value;
    }
    private int maxDamage;
    public int MaxDamage
    {
        get => maxDamage;
        set => maxDamage = value;
    }

    [SerializeField]private SpriteRenderer sprite;
    public SpriteRenderer  Sprite
    {
        get => sprite;
    }
    [SerializeField] private Animator anim;
    public Animator Anim
    {
        get => anim;
    }
    [SerializeField] private GameObject afterImage;
    public GameObject AfterImage
    {
        get => afterImage;
    }
    [SerializeField] public ObjectManager objectManager;

    [SerializeField] protected Player player;

    public virtual void Start()
    {
        player = transform.root.GetComponent<Player>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        afterImage = transform.GetChild(1).gameObject;
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
    }
}