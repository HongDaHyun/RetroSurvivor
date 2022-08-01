using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    bool isMove;
    public override void Start()
    {
        type = "Slime";
        base.Start();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
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

    IEnumerator Damaged(Collider2D collision)
    {
        CurHealth -= collision.GetComponent<AfterImage>().totalDmg;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

    private void Stop()
    {
        IsStun = true;
    }

    private void NonStop()
    {
        IsStun = false;
    }
}
