using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    SpriteRenderer sprite;

    private int damage;
    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    private int curHealth;
    public int CurHealth
    {
        get => curHealth;
        set => curHealth = value;
    }
    private int defHealth;
    public int DefHealth
    {
        get => defHealth;
        set => defHealth = value;
    }

    private bool isStun;
    public bool IsStun
    {
        get => isStun;
        set => isStun = value;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        }
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
