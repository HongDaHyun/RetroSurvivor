using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    ItemDatabase itemDatabase;
    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    int thisCost;

    private void Awake()
    {
        itemDatabase = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        SetMoney();
    }

    private void OnDisable()
    {
        gameManager.money += thisCost;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.transform.position, 10 * Time.deltaTime);
            if(collision.transform.position == transform.position)
                gameObject.SetActive(false);
        }
    }

    private void SetMoney()
    {
        int random = Random.Range(0, itemDatabase.moneyDB.Count);
        spriteRenderer.sprite = itemDatabase.moneyDB[random].sprite;
        thisCost = itemDatabase.moneyDB[random].cost;
    }
}
