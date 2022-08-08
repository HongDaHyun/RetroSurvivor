using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour, IPointerUpHandler
{
    public int slotNum;
    public Item item;
    public Image itemIcon;
    Player player;
    public ObjectManager objectManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.sprite;
        itemIcon.SetNativeSize();
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(item != null)
        {
            if (item.type == ItemType.Equipment)
            {
                if (player.Weapon != null)
                {
                    player.Weapon.transform.localEulerAngles = new Vector3(0, 0, 0);
                    player.Weapon.SetActive(false);
                }
                switch (item.name)
                {
                    case "Basic":
                        player.Weapon = objectManager.MakeObj("BasicShortSword");
                        break;
                    case "Broken":
                        player.Weapon = objectManager.MakeObj("BrokenKingShortSword");
                        break;
                    case "Prince":
                        player.Weapon = objectManager.MakeObj("PrinceShortSword");
                        break;
                    case "Plant":
                        player.Weapon = objectManager.MakeObj("PlantShortSword");
                        break;
                    case "Kitchen":
                        player.Weapon = objectManager.MakeObj("KitchenShortSword");
                        break;
                    case "Black":
                        player.Weapon = objectManager.MakeObj("BlackShortSword");
                        break;
                    case "Round":
                        player.Weapon = objectManager.MakeObj("RoundShortSword");
                        break;
                    case "Wooden":
                        player.Weapon = objectManager.MakeObj("WoodenShortSword");
                        break;
                    case "Cactus":
                        player.Weapon = objectManager.MakeObj("CactusShortSword");
                        break;
                    case "Zelda":
                        player.Weapon = objectManager.MakeObj("ZeldaShortSword");
                        break;
                    case "RiceCake":
                        player.Weapon = objectManager.MakeObj("RiceCakeShortSword");
                        break;
                    case "Doran":
                        player.Weapon = objectManager.MakeObj("DoranShortSword");
                        break;
                    case "Monster":
                        player.Weapon = objectManager.MakeObj("MonsterShortSword");
                        break;
                    case "Blood":
                        player.Weapon = objectManager.MakeObj("BloodShortSword");
                        break;
                }

                player.Weapon.transform.parent = player.transform;
                player.Weapon.transform.position = new Vector2(player.transform.position.x + 0.2f, player.transform.position.y + 0.5f);
            }
        }
    }
}
