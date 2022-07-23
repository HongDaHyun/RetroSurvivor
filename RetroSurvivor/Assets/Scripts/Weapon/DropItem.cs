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
            if(player.Weapon != null)
            {
                player.Weapon.transform.localEulerAngles = new Vector3(0, 0, 0);
                player.Weapon.SetActive(false);
            }
            switch (type)
            {
                case Type.ShortSword:
                    switch (randID)
                    {
                        case 0:
                            player.Weapon = objectManager.MakeObj("BasicShortSword");
                            break;
                        case 1:
                            player.Weapon = objectManager.MakeObj("BrokenKingShortSword");
                            break;
                        case 2:
                            player.Weapon = objectManager.MakeObj("PrinceShortSword");
                            break;
                        case 3:
                            player.Weapon = objectManager.MakeObj("PlantShortSword");
                            break;
                        case 4:
                            player.Weapon = objectManager.MakeObj("KitchenShortSword");
                            break;
                        case 5:
                            player.Weapon = objectManager.MakeObj("BlackShortSword");
                            break;
                        case 6:
                            player.Weapon = objectManager.MakeObj("RoundShortSword");
                            break;
                        case 7:
                            player.Weapon = objectManager.MakeObj("WoodenShortSword");
                            break;
                    }
                    player.Weapon.transform.parent = player.transform;
                    player.Weapon.transform.position = player.transform.position;
                    break;
            }

            gameObject.SetActive(false);
        }
    }
}
