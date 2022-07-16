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
    private int health;
    public int Health
    {
        get => health;
        set => health = value;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        agent.SetDestination(player.transform.position);
        if (transform.position.x > player.transform.position.x)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }
}
