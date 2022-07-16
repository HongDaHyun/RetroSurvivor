using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    SpriteRenderer sprite;
    BuffManager buffManager;

    private int damage;
    public int Damage
    {
        get => damage;
        set => damage = value;
    }
    private int health;
    public int Health
    {
        get => health;
        set => health = value;
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
        buffManager = GameObject.Find("BuffManager").GetComponent<BuffManager>();
    }

    private void Start()
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
    }

    IEnumerator Damaged(Collider2D collision)
    {
        isStun = true;
        health -= collision.GetComponent<AfterImage>().totalDmg;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        isStun = false;
    }

    private void Die()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Move()
    {
        agent.SetDestination(player.transform.position);
        if(isStun)
        {
            agent.SetDestination(transform.position);
        }
        if (transform.position.x > player.transform.position.x)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }
}
