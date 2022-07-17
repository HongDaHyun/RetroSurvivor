using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public string type;
    public int id;

    ObjectManager objectManager;
    Player player;

    private void Awake()
    {
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            switch (type)
            {
                case "ShortSword":
                    switch (id)
                    {
                        case 0:
                            GameObject weapon = objectManager.MakeObj("BasicShortSword");
                            weapon.transform.parent = player.transform;
                            weapon.transform.position = player.transform.position;
                            break;
                    }
                    break;
            }

            gameObject.SetActive(false);
        }
    }
}
