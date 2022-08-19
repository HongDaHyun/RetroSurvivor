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

            player.Weapon = objectManager.MakeWeapon(equipment.equipType, equipment.id);

            player.Weapon.transform.parent = player.transform;
            player.Weapon.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.2f);

        }
    }
}
