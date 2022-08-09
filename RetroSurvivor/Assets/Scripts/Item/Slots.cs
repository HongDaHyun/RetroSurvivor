using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour, IPointerUpHandler
{
    public int slotNum;
    public Equipment equipment;
    public Image itemIcon;
    Player player;
    public ObjectManager objectManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void UpdateSlotUI()
    {
        itemIcon.sprite = equipment.sprite;
        itemIcon.SetNativeSize();
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        equipment = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(equipment != null)
        {
            if (player.Weapon != null)
            {
                player.Weapon.transform.localEulerAngles = new Vector3(0, 0, 0);
                player.Weapon.SetActive(false);
            }
            switch (equipment.equipType)
            {
                case EquipmentType.ShortSword:
                    switch (equipment.name)
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
                        case "Spine":
                            player.Weapon = objectManager.MakeObj("SpineShortSword");
                            break;
                        case "Saber":
                            player.Weapon = objectManager.MakeObj("SaberShortSword");
                            break;
                        case "Levatain":
                            player.Weapon = objectManager.MakeObj("LevatainShortSword");
                            break;
                        case "Quadruple":
                            player.Weapon = objectManager.MakeObj("QuadrupleShortSword");
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
                    break;

                case EquipmentType.LongSword:
                    switch(equipment.name)
                    {
                        case "BigBroken":
                            player.Weapon = objectManager.MakeObj("BigBrokenLongSword");
                            break;
                        case "Jack":
                            player.Weapon = objectManager.MakeObj("JackLongSword");
                            break;
                        case "Military":
                            player.Weapon = objectManager.MakeObj("MilitaryLongSword");
                            break;
                        case "Ruler":
                            player.Weapon = objectManager.MakeObj("RulerLongSword");
                            break;
                        case "Candle":
                            player.Weapon = objectManager.MakeObj("CandleLongSword");
                            break;
                        case "Cutter":
                            player.Weapon = objectManager.MakeObj("CutterLongSword");
                            break;
                        case "DarkSoul":
                            player.Weapon = objectManager.MakeObj("DarkSoulLongSword");
                            break;
                        case "Red":
                            player.Weapon = objectManager.MakeObj("RedLongSword");
                            break;
                        case "Thorn":
                            player.Weapon = objectManager.MakeObj("ThornLongSword");
                            break;
                        case "BigBlack":
                            player.Weapon = objectManager.MakeObj("BigBlackLongSword");
                            break;
                        case "BigKitchen":
                            player.Weapon = objectManager.MakeObj("BigKitchenLongSword");
                            break;
                        case "Dragon":
                            player.Weapon = objectManager.MakeObj("DragonLongSword");
                            break;
                        case "Fairy":
                            player.Weapon = objectManager.MakeObj("FairyLongSword");
                            break;
                        case "Cool":
                            player.Weapon = objectManager.MakeObj("CoolLongSword");
                            break;
                        case "Gun":
                            player.Weapon = objectManager.MakeObj("GunLongSword");
                            break;
                        case "Lazer":
                            player.Weapon = objectManager.MakeObj("LazerLongSword");
                            break;
                        case "Devil":
                            player.Weapon = objectManager.MakeObj("DevilLongSword");
                            break;
                        case "Ice":
                            player.Weapon = objectManager.MakeObj("IceLongSword");
                            break;
                    }
                    break;
            }
            player.Weapon.transform.parent = player.transform;
            player.Weapon.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.2f);

        }
    }
}
