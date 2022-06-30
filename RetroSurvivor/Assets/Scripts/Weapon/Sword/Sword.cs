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
                break;
            case SwordList.LongSword:
                break;
            case SwordList.TwinSwords:
                break;
            case SwordList.Spear:
                break;
        }
    }
/*
    IEnumerator ShortSword(int n)
    {
        GameObject shortSword = mapManager.MakeObj("ShortSword");
        shortSword.transform.position = new Vector2(transform.position.x + 1.3f, transform.position.y);
        yield return new WaitForSeconds(1.5f);
    }
*/
}