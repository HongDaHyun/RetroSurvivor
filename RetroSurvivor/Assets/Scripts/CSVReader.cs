using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset weaponData;

    [Serializable]
    public class Weapon
    {
        public string name;
        public string type;
        public string tier;
        public int minDmg;
        public int maxDmg;
        public float AtkSpeed;
        public int ID;
    }

    [Serializable]
    public class WeaponList
    {
        public Weapon[] weapon;
    }

    public WeaponList weaponList = new WeaponList();

    private void Start()
    {
        WeaponReadCSV();
    }

    void WeaponReadCSV()
    {
        string[] data = weaponData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = data.Length / 7 - 1;
        weaponList.weapon = new Weapon[tableSize];

        for(int i = 0; i < tableSize; i++)
        {
            weaponList.weapon[i] = new Weapon();
            weaponList.weapon[i].name = data[7 * (i + 1)];
            weaponList.weapon[i].type = data[7 * (i + 1) + 1];
            weaponList.weapon[i].tier = data[7 * (i + 1) + 2];
            weaponList.weapon[i].minDmg = int.Parse(data[7 * (i + 1) + 3]);
            weaponList.weapon[i].maxDmg = int.Parse(data[7 * (i + 1) + 4]);
            weaponList.weapon[i].AtkSpeed = float.Parse(data[7 * (i + 1) + 5]);
            weaponList.weapon[i].ID = int.Parse(data[7 * (i + 1) + 6]);
        }
    }
}
