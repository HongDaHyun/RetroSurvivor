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

    private float aimSpeed;
    private float curSpeed;
    private float speed;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    private float curAttackSpeed = 10000;
    public float CurAttackSpeed
    {
        get => curAttackSpeed;
        set => curAttackSpeed = value;
    }
    private float attackSpeed;
    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    private int eyesight;
    public int Eyesight
    {
        get => eyesight;
        set => eyesight = value;
    }

    private int curHP;
    public int CurHP
    {
        get => curHP;
        set => curHP = value;
    }
    private int maxHP;
    public int MaxHP
    {
        get => maxHP;
        set => maxHP = value;
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
        Aim();
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

    public void SetStat()
    {
        curSpeed = speed;
        aimSpeed = speed / 1.5f;
        curHP = maxHP;
    }
}