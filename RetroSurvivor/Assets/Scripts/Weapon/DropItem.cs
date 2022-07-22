using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    enum Type { ShortSword, LongSword, Spear, Mace};
    Type type;
    private int randID;

    ObjectManager objectManager;
    Player player;
    SpriteRenderer sprite;
    GameObject weapon;

    private void Awake()
    {
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        type = Type.ShortSword; // 랜덤으로 수정
        switch (type)
        {
            case Type.ShortSword:
                randID = Random.Range(0, objectManager.shortSwordPrefabs.Length);
                sprite.sprite = objectManager.weaponSprites[randID];
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            switch (type)
            {
                case Type.ShortSword:
                    switch (randID)
                    {
                        case 0:
                            weapon = objectManager.MakeObj("BasicShortSword");
                            break;
                        case 1:
                            weapon = objectManager.MakeObj("BrokenKingShortSword");
                            break;
                        case 2:
                            weapon = objectManager.MakeObj("PrinceShortSword");
                            break;
                        case 3:
                            weapon = objectManager.MakeObj("PlantShortSword");
                            break;
                        case 4:
                            weapon = objectManager.MakeObj("KitchenShortSword");
                            break;
                        case 5:
                            weapon = objectManager.MakeObj("BlackShortSword");
                            break;
                        case 6:
                            weapon = objectManager.MakeObj("RoundShortSword");
                            break;
                        case 7:
                            weapon = objectManager.MakeObj("WoodenShortSword");
                            break;
                    }
                    weapon.transform.parent = player.transform;
                    weapon.transform.position = player.transform.position;
                    break;
            }

            gameObject.SetActive(false);
        }
    }
}
