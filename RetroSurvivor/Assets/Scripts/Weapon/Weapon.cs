
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public float attackSpeed;

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