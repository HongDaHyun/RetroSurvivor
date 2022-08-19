using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public ItemDatabase itemdatabase;
    public GameObject[] MapFieldPrefabs;
    public GameObject[] enemyPrefabs;

    public GameObject fieldItemPrefab;
    public GameObject boxPrefab;

    public GameObject damageTextPrefab;

    public GameObject[] shortSwords;
    public GameObject[] longSwords;

    GameObject[] stage1 = new GameObject[25];

    GameObject[] greenSlime = new GameObject[100];
    GameObject[] blueSlime = new GameObject[100];
    GameObject[] redSlime = new GameObject[100];
    GameObject[] purpleSlime = new GameObject[100];
    GameObject[] redMushroom = new GameObject[100];
    GameObject[] yellowMushroom = new GameObject[100];
    GameObject[] skyblueMushroom = new GameObject[100];
    GameObject[] blackMushroom = new GameObject[100];

    GameObject[] fieldItem = new GameObject[100];
    GameObject[] box = new GameObject[20];

    GameObject[] damageText = new GameObject[30];

    GameObject[] targetPool;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        //Weapon
        int sCount = itemdatabase.WeaponCount(EquipmentType.ShortSword);
        int lCount = itemdatabase.WeaponCount(EquipmentType.LongSword);
        shortSwords = new GameObject[sCount];
        longSwords = new GameObject[lCount];

        for(int i = 0; i < sCount; i++)
        {
            shortSwords[i] = Instantiate(itemdatabase.equipmentDB[i].prefab);
            shortSwords[i].SetActive(false);
        }
        for (int i = 0; i < lCount; i++)
        {
            longSwords[i] = Instantiate(itemdatabase.equipmentDB[i + sCount].prefab);
            longSwords[i].SetActive(false);
        }

        //MapField
        for (int i = 0; i < stage1.Length; i++)
        {
            stage1[i] = Instantiate(MapFieldPrefabs[0]);
            stage1[i].SetActive(false);
        }

        //Enemy
        for (int i = 0; i < greenSlime.Length; i++)
        {
            greenSlime[i] = Instantiate(enemyPrefabs[0]);
            greenSlime[i].SetActive(false);
        }
        for (int i = 0; i < blueSlime.Length; i++)
        {
            blueSlime[i] = Instantiate(enemyPrefabs[1]);
            blueSlime[i].SetActive(false);
        }
        for (int i = 0; i < redSlime.Length; i++)
        {
            redSlime[i] = Instantiate(enemyPrefabs[2]);
            redSlime[i].SetActive(false);
        }
        for (int i = 0; i < purpleSlime.Length; i++)
        {
            purpleSlime[i] = Instantiate(enemyPrefabs[3]);
            purpleSlime[i].SetActive(false);
        }
        for (int i = 0; i < redMushroom.Length; i++)
        {
            redMushroom[i] = Instantiate(enemyPrefabs[4]);
            redMushroom[i].SetActive(false);
        }
        for (int i = 0; i < yellowMushroom.Length; i++)
        {
            yellowMushroom[i] = Instantiate(enemyPrefabs[5]);
            yellowMushroom[i].SetActive(false);
        }
        for (int i = 0; i < skyblueMushroom.Length; i++)
        {
            skyblueMushroom[i] = Instantiate(enemyPrefabs[6]);
            skyblueMushroom[i].SetActive(false);
        }
        for (int i = 0; i < blackMushroom.Length; i++)
        {
            blackMushroom[i] = Instantiate(enemyPrefabs[7]);
            blackMushroom[i].SetActive(false);
        }

        //FieldItem
        for (int i = 0; i < fieldItem.Length; i++)
        {
            fieldItem[i] = Instantiate(fieldItemPrefab);
            fieldItem[i].SetActive(false);
        }
        for (int i = 0; i < box.Length; i++)
        {
            box[i] = Instantiate(boxPrefab);
            box[i].SetActive(false);
        }

        //DamageText
        for (int i = 0; i < damageText.Length; i++)
        {
            damageText[i] = Instantiate(damageTextPrefab);
            damageText[i].SetActive(false);
        }
    }

    int k;
    public GameObject MakeObj(string name)
    {
        switch(name)
        {
            case "Stage1":
                targetPool = stage1;
                break;

            case "GreenSlime":
                targetPool = greenSlime;
                break;
            case "BlueSlime":
                targetPool = blueSlime;
                break;
            case "RedSlime":
                targetPool = redSlime;
                break;
            case "PurpleSlime":
                targetPool = purpleSlime;
                break;
            case "RedMushroom":
                targetPool = redMushroom;
                break;
            case "YellowMushroom":
                targetPool = yellowMushroom;
                break;
            case "SkyblueMushroom":
                targetPool = skyblueMushroom;
                break;
            case "BlackMushroom":
                targetPool = blackMushroom;
                break;

            case "FieldItem":
                targetPool = fieldItem;
                break;
            case "Box":
                targetPool = box;
                break;

            case "DamageText":
                targetPool = damageText;
                break;
        }
        for(int i = 0; i < targetPool.Length; i++)
        {
            if(targetPool == fieldItem)
            {
                if (k > 300)
                    k = 0;
                targetPool[k].SetActive(true);
                k++;
                return targetPool[k - 1];
            }
            if(!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }
        return null;
    }

    public GameObject MakeWeapon(EquipmentType equipmentType, int i)
    {
        switch(equipmentType)
        {
            case EquipmentType.ShortSword:
                shortSwords[i].SetActive(true);
                return shortSwords[i];
            case EquipmentType.LongSword:
                longSwords[i].SetActive(true);
                return longSwords[i];
        }
        return null;
    }
}
