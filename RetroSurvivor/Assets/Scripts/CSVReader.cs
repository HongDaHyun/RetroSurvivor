using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset[] textAssets;

    [Serializable]
    public class Weapon
    {
        public string name;
        public string type;
        public string tier;
        public int minDmg;
        public int maxDmg;
        public float AtkSpeed;
    }
    [Serializable]
    public class WeaponList
    {
        public Weapon[] weapon;
    }

    [Serializable]
    public class Enemy
    {
        public string name;
        public string type;
        public int dmg;
        public int hp;
        public int exp;
        public int stage;
        public float speed;
    }
    [Serializable]
    public class EnemyList
    {
        public Enemy[] enemy;
    }

    public WeaponList weaponList = new WeaponList();
    public EnemyList enemyList = new EnemyList();

    private void Awake()
    {
        WeaponReadCSV();
        EnmeyReadCSV();
    }

    void WeaponReadCSV()
    {
        string[] data = textAssets[0].text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = data.Length / 6 - 1;
        weaponList.weapon = new Weapon[tableSize];

        for(int i = 0; i < tableSize; i++)
        {
            weaponList.weapon[i] = new Weapon();
            weaponList.weapon[i].name = data[6 * (i + 1)];
            weaponList.weapon[i].type = data[6 * (i + 1) + 1];
            weaponList.weapon[i].tier = data[6 * (i + 1) + 2];
            weaponList.weapon[i].minDmg = int.Parse(data[6 * (i + 1) + 3]);
            weaponList.weapon[i].maxDmg = int.Parse(data[6 * (i + 1) + 4]);
            weaponList.weapon[i].AtkSpeed = float.Parse(data[6 * (i + 1) + 5]);
        }
    }

    void EnmeyReadCSV()
    {
        string[] data = textAssets[1].text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = data.Length / 7 - 1;
        enemyList.enemy = new Enemy[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            enemyList.enemy[i] = new Enemy();
            enemyList.enemy[i].name = data[7 * (i + 1)];
            enemyList.enemy[i].type = data[7 * (i + 1) + 1];
            enemyList.enemy[i].dmg = int.Parse(data[7 * (i + 1) + 2]);
            enemyList.enemy[i].hp = int.Parse(data[7 * (i + 1) + 3]);
            enemyList.enemy[i].exp = int.Parse(data[7 * (i + 1) + 4]);
            enemyList.enemy[i].stage = int.Parse(data[7 * (i + 1) + 5]);
            enemyList.enemy[i].speed = float.Parse(data[7 * (i + 1) + 6]);
        }
    }
}
