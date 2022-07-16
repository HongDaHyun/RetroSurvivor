using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    Player player;
    Weapon weapon;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weapon = transform.parent.gameObject.GetComponent<Weapon>();
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //collision.gameObject.GetComponent<Enemy>().Health -= Random.Range(weapon.MinDamage + (weapon.MinDamage * player.Damage / 100), weapon.MinDamage + (weapon.MinDamage * player.Damage / 100))
        }
    }
}
