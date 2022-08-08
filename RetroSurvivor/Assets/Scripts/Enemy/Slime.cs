using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
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
        int dmg = collision.GetComponent<AfterImage>().totalDmg;
        CurHealth -= dmg;
        GameObject dmgText = objectManager.MakeObj("DamageText");
        dmgText.GetComponent<DamageText>().DmgTxt(dmg);
        dmgText.transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

    public void NonStop()
    {
        IsStun = false;
    }

    public void Stop()
    {
        IsStun = true;
    }
}
