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

    private void Update()
    {
        if (!GlobalVariable.isStop)
        {
            Attack();
            Aim();
        }
    }

    private void OnDisable()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void Aim()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        Vector2 scale = transform.localScale;

        if (!player.Sprite.flipX)
        {
            scale.y = 1;
        }
        else if (player.Sprite.flipX)
        {
            scale.y = -1;
        }
        transform.localScale = scale;
    }

    private void Attack()
    {
        float totalAtkSpeed = attackSpeed - (attackSpeed * (player.attackSpeed / 100));
        totalAtkSpeed = (totalAtkSpeed <= 0.5f) ? 0.5f : totalAtkSpeed;

        if (player.CurAttackSpeed > totalAtkSpeed && Input.GetMouseButton(0))
        {
            Anim.SetTrigger("Attack");
            AfterImage.SetActive(true);
            player.CurAttackSpeed = 0;
        }
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