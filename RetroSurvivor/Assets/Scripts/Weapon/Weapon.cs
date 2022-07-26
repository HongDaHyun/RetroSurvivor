using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public string type;
    public string tier;
    public int minDamage;
    public int maxDamage;
    public float attackSpeed;
    public int id;

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

    protected ObjectManager objectManager;
    protected Player player;
    protected CSVReader csvReader;

    public virtual void Start()
    {
        player = transform.root.GetComponent<Player>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        afterImage = transform.GetChild(1).gameObject;
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        csvReader = GameObject.Find("CSVReader").GetComponent<CSVReader>();
        SetStat();
    }
    //player attackspeed ¼³Á¤
    private void SetStat()
    {
        for (int i = 0; i < csvReader.weaponList.weapon.Length; i++)
        {
            if (csvReader.weaponList.weapon[i].type == type && csvReader.weaponList.weapon[i].name == weaponName)
            {
                tier = csvReader.weaponList.weapon[i].tier;
                minDamage = csvReader.weaponList.weapon[i].minDmg;
                maxDamage = csvReader.weaponList.weapon[i].maxDmg;
                attackSpeed = csvReader.weaponList.weapon[i].AtkSpeed;
            }
        }
    }
}