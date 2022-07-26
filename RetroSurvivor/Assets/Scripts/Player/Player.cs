using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Stat
    public string job;
    public int maxHP;
    public float damage; //무기공격력 * (1 + 플레이어공격력 / 100)
    public float defense; //대미지 = 공격력 * (1 - 방어율)   방어율 = 방어력 / (1 + 방어력)
    public int staticDmg;
    public int staticDef;
    public float attackSpeed; //무기공속 - (무기공속 * (플레이어공속 / 100)
    public float defSpeed;
    public int critical;
    public int criticalDmg;
    public int luck;
    public int aim;
    #endregion

    Animator anim;
    SpriteRenderer sprite;
    Camera cam;
    Vector2 mouse;
    GameObject weapon;
    ObjectManager objectManager;
    CSVReader csvReader;

    public SpriteRenderer Sprite
    {
        get => sprite;
        set => sprite = value;
    }
    public Vector2 Mouse
    {
        get => mouse;
        set => mouse = value;
    }
    public GameObject Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    private float aimSpeed;
    private float curSpeed;
    private float curAttackSpeed = 10000;
    private int curHP;
    private int curExp;
    private int maxExp;
    private int level = 1;
    private int statPoint;

    public float CurAttackSpeed
    {
        get => curAttackSpeed;
        set => curAttackSpeed = value;
    }
    public int CurHP
    {
        get => curHP;
        set => curHP = value;
    }
    public int CurExp
    {
        get => curExp;
        set => curExp = value;
    }
    public int MaxExp
    {
        get => maxExp;
        set => maxExp = value;
    }
    public int Level
    {
        get => level;
        set => level = value;
    }
    public int StatPoint
    {
        get => statPoint;
        set => statPoint = value;
    }

    public void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        csvReader = GameObject.Find("CSVReader").GetComponent<CSVReader>();
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Update()
    {
        curAttackSpeed += Time.deltaTime;
        Aim();
        LevelUp();
    }

    public void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(inputX, inputY).normalized * Time.deltaTime * curSpeed);

        if (inputX != 0 || inputY != 0)
        {
            if(Input.GetMouseButton(0))
            {
                anim.SetBool("Run", false);
                anim.SetBool("Walk", true);
                curSpeed = aimSpeed;
            }
            else
            {
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
                curSpeed = defSpeed;
            }
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
        }

        if (mouse.x > transform.position.x)
        {
            sprite.flipX = false;
        }
        else if (mouse.x < transform.position.x)
        {
            sprite.flipX = true;
        }
    }

    public void Aim()
    {
        mouse = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void LevelUp()
    {
        if(curExp >= maxExp)
        {
            level++;
            statPoint++;
            curExp -= maxExp;
            maxExp = (level * level + level) * 5;
        }
    }

    public void SetStat()
    {
        for (int i = 0; i < csvReader.playerList.player.Length; i++)
        {
            if (csvReader.playerList.player[i].name == job)
            {
                maxHP = csvReader.playerList.player[i].hp;
                damage = csvReader.playerList.player[i].damage;
                defense = csvReader.playerList.player[i].defense;
                staticDmg = csvReader.playerList.player[i].staticDmg;
                staticDef = csvReader.playerList.player[i].staticDef;
                attackSpeed = csvReader.playerList.player[i].atkSpeed;
                defSpeed = csvReader.playerList.player[i].speed;
                critical = csvReader.playerList.player[i].critical;
                criticalDmg = csvReader.playerList.player[i].critDmg;
                luck = csvReader.playerList.player[i].luck;
                aim = csvReader.playerList.player[i].aim;
            }
        }

        maxExp = (level * level + level) * 5;
        curSpeed = defSpeed;
        aimSpeed = defSpeed / 1.5f;
        curHP = maxHP;
    }
}