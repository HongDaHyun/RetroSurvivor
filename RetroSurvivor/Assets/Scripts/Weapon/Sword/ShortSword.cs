using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSword : Weapon
{
    private void Update()
    {
        if (player.CurAttackSpeed > player.AttackSpeed && Input.GetMouseButton(0))
        {
            Anim.SetTrigger("Attack");
            AfterImage.SetActive(true);
            player.CurAttackSpeed = 0;
        }
        else
        {
            Aim();
        }
    }

    private void Aim()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        Vector2 scale = transform.localScale;

        if (!player.Sprite.flipX)
        {
            scale.y = 1;
        }
        else if (player.Sprite.flipX)
        {
            scale.y = -1;
        }
        transform.localScale = scale;

        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            Sprite.sortingOrder = -1;
        }
        else
        {
            Sprite.sortingOrder = 2;
        }
    }
}