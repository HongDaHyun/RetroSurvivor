using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] shortSwordPrefabs;
    public GameObject[] MapFieldPrefabs;
    public GameObject[] enemyPrefabs;

    public GameObject fieldItemPrefab;

    public GameObject damageTextPrefab;

    #region ShortSword
    GameObject[] basicShortSword = new GameObject[5];
    GameObject[] brokenKingShortSword = new GameObject[5];
    GameObject[] kitchenShortSword = new GameObject[5];
    GameObject[] woodenShortSword = new GameObject[5];
    GameObject[] princeShortSword = new GameObject[5];
    GameObject[] plantShortSword = new GameObject[5];
    GameObject[] blackShortSword = new GameObject[5];
    GameObject[] roundShortSword = new GameObject[5];
    GameObject[] cactusShortSword = new GameObject[5];
    GameObject[] zeldaShortSword = new GameObject[5];
    GameObject[] riceCakeShortSword = new GameObject[5];
    GameObject[] doranShortSword = new GameObject[5];
    GameObject[] monsterShortSword = new GameObject[5];
    GameObject[] bloodShortSword = new GameObject[5];
    #endregion

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

    GameObject[] damageText = new GameObject[30];

    GameObject[] targetPool;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        //Weapon
        for(int i = 0; i < basicShortSword.Length; i++)
        {
            basicShortSword[i] = Instantiate(shortSwordPrefabs[0]);
            basicShortSword[i].SetActive(false);
        }
        for (int i = 0; i < brokenKingShortSword.Length; i++)
        {
            brokenKingShortSword[i] = Instantiate(shortSwordPrefabs[1]);
            brokenKingShortSword[i].SetActive(false);
        }
        for (int i = 0; i < kitchenShortSword.Length; i++)
        {
            kitchenShortSword[i] = Instantiate(shortSwordPrefabs[4]);
            kitchenShortSword[i].SetActive(false);
        }
        for (int i = 0; i < woodenShortSword.Length; i++)
        {
            woodenShortSword[i] = Instantiate(shortSwordPrefabs[7]);
            woodenShortSword[i].SetActive(false);
        }
        for (int i = 0; i < princeShortSword.Length; i++)
        {
            princeShortSword[i] = Instantiate(shortSwordPrefabs[2]);
            princeShortSword[i].SetActive(false);
        }
        for (int i = 0; i < plantShortSword.Length; i++)
        {
            plantShortSword[i] = Instantiate(shortSwordPrefabs[3]);
            plantShortSword[i].SetActive(false);
        }
        for (int i = 0; i < blackShortSword.Length; i++)
        {
            blackShortSword[i] = Instantiate(shortSwordPrefabs[5]);
            blackShortSword[i].SetActive(false);
        }
        for (int i = 0; i < roundShortSword.Length; i++)
        {
            roundShortSword[i] = Instantiate(shortSwordPrefabs[6]);
            roundShortSword[i].SetActive(false);
        }
        for (int i = 0; i < cactusShortSword.Length; i++)
        {
            cactusShortSword[i] = Instantiate(shortSwordPrefabs[8]);
            cactusShortSword[i].SetActive(false);
        }
        for (int i = 0; i < zeldaShortSword.Length; i++)
        {
            zeldaShortSword[i] = Instantiate(shortSwordPrefabs[9]);
            zeldaShortSword[i].SetActive(false);
        }
        for (int i = 0; i < riceCakeShortSword.Length; i++)
        {
            riceCakeShortSword[i] = Instantiate(shortSwordPrefabs[10]);
            riceCakeShortSword[i].SetActive(false);
        }
        for (int i = 0; i < doranShortSword.Length; i++)
        {
            doranShortSword[i] = Instantiate(shortSwordPrefabs[11]);
            doranShortSword[i].SetActive(false);
        }
        for (int i = 0; i < monsterShortSword.Length; i++)
        {
            monsterShortSword[i] = Instantiate(shortSwordPrefabs[12]);
            monsterShortSword[i].SetActive(false);
        }
        for (int i = 0; i < bloodShortSword.Length; i++)
        {
            bloodShortSword[i] = Instantiate(shortSwordPrefabs[13]);
            bloodShortSword[i].SetActive(false);
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
            case "BasicShortSword":
                targetPool = basicShortSword;
                break;
            case "BrokenKingShortSword":
                targetPool = brokenKingShortSword;
                break;
            case "KitchenShortSword":
                targetPool = kitchenShortSword;
                break;
            case "WoodenShortSword":
                targetPool = woodenShortSword;
                break;
            case "PrinceShortSword":
                targetPool = princeShortSword;
                break;
            case "PlantShortSword":
                targetPool = plantShortSword;
                break;
            case "BlackShortSword":
                targetPool = blackShortSword;
                break;
            case "RoundShortSword":
                targetPool = roundShortSword;
                break;
            case "CactusShortSword":
                targetPool = cactusShortSword;
                break;
            case "ZeldaShortSword":
                targetPool = zeldaShortSword;
                break;
            case "RiceCakeShortSword":
                targetPool = riceCakeShortSword;
                break;
            case "DoranShortSword":
                targetPool = doranShortSword;
                break;
            case "MonsterShortSword":
                targetPool = monsterShortSword;
                break;
            case "BloodShortSword":
                targetPool = bloodShortSword;
                break;

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
}
