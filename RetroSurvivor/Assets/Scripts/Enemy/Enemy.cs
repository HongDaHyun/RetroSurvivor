using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Player player;
    ObjectManager objectManager;
    NavMeshAgent agent;
    SpriteRenderer sprite;

    public int exp;

    public int damage;

    private int curHealth;
    public int CurHealth
    {
        get => curHealth;
        set => curHealth = value;
    }
    public int defHealth;

    private bool isStun;
    public bool IsStun
    {
        get => isStun;
        set => isStun = value;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    private void Update()
    {
        Move();
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AfterImage"))
        {
            StartCoroutine(Damaged(collision));
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        curHealth = defHealth;
        sprite.color = Color.white;
        IsStun = false;
        agent.enabled = false;
    }

    IEnumerator Damaged(Collider2D collision)
    {
        isStun = true;
        curHealth -= collision.GetComponent<AfterImage>().totalDmg;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        isStun = false;
    }

    private void Die()
    {
        if(curHealth <= 0)
        {
            gameObject.SetActive(false);
            player.CurExp += exp;

            Drop();
        }
    }

    private void Drop()
    {
        //int rand = Random.Range(1, 101);
        //if (rand <= 80)
        //    return;

        //rand = Random.Range(1, 101);
        ////rand값에 따라 상자 희귀도 결정
        GameObject dropItem = objectManager.MakeObj("DropItem");
        dropItem.transform.position = transform.position;
    }

    public void Move()
    {
        agent.enabled = true; //최적화 필요?
        agent.SetDestination(player.transform.position);

        if (isStun)
        {
            agent.SetDestination(transform.position);
        }

        if (transform.position.x > player.transform.position.x)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }
}
