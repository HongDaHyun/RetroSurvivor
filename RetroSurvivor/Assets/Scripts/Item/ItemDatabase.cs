using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase database;
    public CSVReader csvReader;
    public List<Equipment> equipmentDB = new List<Equipment>();
    public List<BoxDB> boxDB = new List<BoxDB>();

    private void Awake()
    {
        database = this;
    }

    [ContextMenu("CSV리더에서 아이템 가져오기")]
    public void CSVinput()
    {
        for (int i = 0; i < csvReader.weaponList.weapon.Length; i++)
        {
            equipmentDB[i].name = csvReader.weaponList.weapon[i].name;
            equipmentDB[i].equipType = csvReader.weaponList.weapon[i].type;
            equipmentDB[i].tierType = csvReader.weaponList.weapon[i].tier;
            equipmentDB[i].id = csvReader.weaponList.weapon[i].id;
        }
    }

    public int WeaponCount(EquipmentType equipmentType)
    {
        int firstCount = 0;
        for (int i = 0; i < equipmentDB.Count; i++)
        {
            if (equipmentType == equipmentDB[i].equipType)
                firstCount++;
        }
        return firstCount;
    }
}
