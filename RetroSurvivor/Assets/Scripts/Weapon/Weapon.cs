
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tear { Raw, Common, Rare, Epic, Legend };

public class Weapon : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public float attackSpeed;

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
    private GameObject afterImage;
    public GameObject AfterImage
    {
        get => afterImage;
    }
    public Tear tear;

    public ObjectManager objectManager;
    protected Player player;

    public void Start()
    {
        player = transform.root.GetComponent<Player>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        afterImage = transform.GetChild(1).gameObject;
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
    }

    private void Update()
    {
        player.WeaponAttackSpeed = attackSpeed; //swap시에만 발동하도록 수정
    }
}