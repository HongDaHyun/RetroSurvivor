using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    SpriteRenderer sprite;

    private float speed;
    public float Speed
    {
        get => speed;
        set => speed = value;
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
