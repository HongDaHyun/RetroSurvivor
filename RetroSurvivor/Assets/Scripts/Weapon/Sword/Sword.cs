using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwordList { ShortSword, LongSword, TwinSwords, Spear };

public class Sword : Weapon
{
    public void Attack(SwordList swordList)
    {
        switch(swordList)
        {
            case SwordList.ShortSword:
                StartCoroutine(ShortSword());
                break;
            case SwordList.LongSword:
                break;
            case SwordList.TwinSwords:
                break;
            case SwordList.Spear:
                break;
        }
    }

    IEnumerator ShortSword()
    {
        Vector2 playerPos2D = new Vector2(transform.position.x, transform.position.y);
        Vector2 attackDir = (player.Mouse - playerPos2D).normalized;
        Vector2 attackPos = playerPos2D + attackDir * 1f;
        float z = Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg;

        GameObject shortSword = objectManager.MakeObj("ShortSword");
        shortSword.transform.position = attackPos;
        shortSword.transform.rotation = Quaternion.Euler(0, 0, z);
        yield return new WaitForSeconds(0.3f);
        shortSword.SetActive(false);
    }

}