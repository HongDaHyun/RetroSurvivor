using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Stat
    public string job;
    public int maxHP;
    public int damage; //무기공격력 * (1 + 플레이어공격력 / 100)
    public int defense; //대미지 = 공격력 * (1 - 방어율)   방어율 = 방어력 / (1 + 방어력)
    public int staticDmg; //구현 x
    public int staticDef; //구현 x
    public float attackSpeed; //무기공속 - (무기공속 * (플레이어공속 / 100)
    public float defSpeed;
    public int critical; //구현 x
    public int criticalDmg; //구현 x
    public int luck;
    public int aim;
    #endregion

    Animator anim;
    SpriteRenderer sprite;
    Camera cam;
    Vector2 mouse;
    GameObject weapon;
    CSVReader csvReader;
    UIManager uiManager;

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
    public List<Item> equipments = new List<Item>();

    private float aimSpeed;
    private float curSpeed;
    private float curAttackSpeed = 10000;
    private int curHP;
    private int curExp;
    private int maxExp;
    private int level = 1;
    private int statPoint;
    private List<int> saveList = new List<int>();
    private bool isHit;

    public float AimSpeed
    {
        get => aimSpeed;
        set => aimSpeed = value;
    }
    public float CurSpeed
    {
        get => curSpeed;
        set => curSpeed = value;
    }
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
    public List<int> SaveList
    {
        get => saveList;
        set => saveList = value;
    }

    public void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        csvReader = GameObject.Find("CSVReader").GetComponent<CSVReader>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("FieldItem") && Input.GetKeyDown(KeyCode.F))
        {
            FieldItem fieldItem = collision.GetComponent<FieldItem>();

            switch (fieldItem.item.type)
            {
                case ItemType.Equipment:
                    equipments.Add(fieldItem.GetItem());
                    uiManager.RedrawEquipmentSlotUI();
                    break;
            }
            fieldItem.gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && !isHit)
        {
            StartCoroutine(Damaged(collision.collider.GetComponent<Enemy>()));
        }
    }

    IEnumerator Damaged(Enemy enemy)
    {
        isHit = true;
        CurHP -= Mathf.RoundToInt(enemy.damage * (1f / (1 + ((float)defense / 100))));
        sprite.color = Color.red;
        yield return new WaitForSeconds(1f);
        isHit = false;
        sprite.color = Color.white;
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
            RanStat();
            uiManager.ResetStatBtn();
            uiManager.SetStatBtn();
            curExp -= maxExp;
            maxExp = (level * level + level) * 5;
        }
    }

    public void RemoveItem(int i)
    {
        equipments.RemoveAt(i);
        uiManager.RedrawEquipmentSlotUI();
    }

    public void RanStat()
    {
        if (statPoint <= 0)
        {
            return;
        }

        int ranNum = Random.Range(0, 11);
        List<int> ranNumList = new List<int>();

        for (int i = 0; i < 3;)
        {
            if (ranNumList.Contains(ranNum))
                ranNum = Random.Range(0, 11);
            else
            {
                ranNumList.Add(ranNum);
                i++;
            }
        }
        saveList.AddRange(ranNumList);
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