using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    public SpriteRenderer Sprite
    {
        get => sprite;
        set => sprite = value;
    }
    Camera cam;
    Vector2 mouse;
    public Vector2 Mouse
    {
        get => mouse;
        set => mouse = value;
    }
    [SerializeField]private GameObject weapon;
    public GameObject Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    private float aimSpeed;
    private float curSpeed;
    public float speed;

    private float curAttackSpeed = 10000;
    public float CurAttackSpeed
    {
        get => curAttackSpeed;
        set => curAttackSpeed = value;
    }
    private float weaponAttackSpeed;
    public float WeaponAttackSpeed
    {
        get => weaponAttackSpeed;
        set => weaponAttackSpeed = value;
    }
    public float playerAttackSpeed;
    private float attackSpeed;
    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    private int curHP;
    public int CurHP
    {
        get => curHP;
        set => curHP = value;
    }
    public int maxHP;

    private int curExp;
    public int CurExp
    {
        get => curExp;
        set => curExp = value;
    }
    private int maxExp;
    public int MaxExp
    {   
        get => maxExp;
        set => maxExp = value;
    }
    private int level = 1;
    public int Level
    {
        get => level;
        set => level = value;
    }

    public float damage;

    private int statPoint;
    public int StatPoint
    {
        get => statPoint;
        set => statPoint = value;
    }

    private string job;
    public string Job
    {
        get => job;
        set => job = value;
    }

    public void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Update()
    {
        curAttackSpeed += Time.deltaTime;
        attackSpeed = playerAttackSpeed + weaponAttackSpeed; //swap시에만 발동하도록 수정
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
                curSpeed = speed;
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

    public void Swap()
    {
    }

    public void SetStat()
    {
        maxExp = (level * level + level) * 5;
        curSpeed = speed;
        aimSpeed = speed / 1.5f;
        curHP = maxHP;
    }
}