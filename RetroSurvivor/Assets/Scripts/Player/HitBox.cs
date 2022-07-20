using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    bool isHit;
    Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isHit)
        {
            StartCoroutine(Damaged(collision.GetComponent<Enemy>()));
        }
    }

    IEnumerator Damaged(Enemy enemy)
    {
        isHit = true;
        player.CurHP -= enemy.damage;
        player.Sprite.color = Color.red;
        yield return new WaitForSeconds(1f);
        isHit = false;
        player.Sprite.color = Color.white;
    }
}
