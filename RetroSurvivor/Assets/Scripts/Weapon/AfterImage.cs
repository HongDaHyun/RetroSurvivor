using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    public int totalDmg;
    Player player;
    Weapon weapon;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weapon = transform.parent.GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        totalDmg = Random.Range(Mathf.RoundToInt(weapon.minDamage + (weapon.minDamage * player.Damage / 100)), Mathf.RoundToInt(weapon.maxDamage + (weapon.maxDamage * player.Damage / 100)));
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
