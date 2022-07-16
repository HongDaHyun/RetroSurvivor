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
        totalDmg = Random.Range(Mathf.RoundToInt(weapon.MinDamage + (weapon.MinDamage * player.Damage / 100)), Mathf.RoundToInt(weapon.MaxDamage + (weapon.MaxDamage * player.Damage / 100)));
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
