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

    #region ShortSword
    GameObject[] basicShortSword = new GameObject[5];
    GameObject[] brokenKingShortSword = new GameObject[5];
    GameObject[] kitchenShortSword = new GameObject[5];
    GameObject[] woodenShortSword = new GameObject[5];
    GameObject[] blackShortSword = new GameObject[5];
    GameObject[] plantShortSword = new GameObject[5];
    GameObject[] princeShortSword = new GameObject[5];
    GameObject[] roundShortSword = new GameObject[5];
    GameObject[] cactusShortSword = new GameObject[5];
    GameObject[] saberShortSword = new GameObject[5];
    GameObject[] spineShortSword = new GameObject[5];
    GameObject[] zeldaShortSword = new GameObject[5];
    GameObject[] doranShortSword = new GameObject[5];
    GameObject[] levatainShortSword = new GameObject[5];
    GameObject[] quadrupleShortSword = new GameObject[5];
    GameObject[] riceCakeShortSword = new GameObject[5];
    GameObject[] bloodShortSword = new GameObject[5];
    GameObject[] monsterShortSword = new GameObject[5];
    #endregion
    #region LongSword
    GameObject[] bigBrokenLongSword = new GameObject[5];
    GameObject[] jackLongSword = new GameObject[5];
    GameObject[] militaryLongSword = new GameObject[5];
    GameObject[] rulerLongSword = new GameObject[5];
    GameObject[] candleLongSword = new GameObject[5];
    GameObject[] cutterLongSword = new GameObject[5];
    GameObject[] darkSoulLongSword = new GameObject[5];
    GameObject[] redLongSword = new GameObject[5];
    GameObject[] thornLongSword = new GameObject[5];
    GameObject[] bigBlackLongSword = new GameObject[5];
    GameObject[] bigKitchenLongSword = new GameObject[5];
    GameObject[] dragonLongSword = new GameObject[5];
    GameObject[] fairyLongSword = new GameObject[5];
    GameObject[] coolLongSword = new GameObject[5];
    GameObject[] gunLongSword = new GameObject[5];
    GameObject[] lazerLongSword = new GameObject[5];
    GameObject[] devilLongSword = new GameObject[5];
    GameObject[] iceLongSword = new GameObject[5];
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
    GameObject[] box = new GameObject[20];

    GameObject[] damageText = new GameObject[30];

    GameObject[] targetPool;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        //ShortSword
        for(int i = 0; i < basicShortSword.Length; i++)
        {
            basicShortSword[i] = Instantiate(itemdatabase.equipmentDB[0].prefab);
            basicShortSword[i].SetActive(false);
        }
        for (int i = 0; i < brokenKingShortSword.Length; i++)
        {
            brokenKingShortSword[i] = Instantiate(itemdatabase.equipmentDB[1].prefab);
            brokenKingShortSword[i].SetActive(false);
        }
        for (int i = 0; i < kitchenShortSword.Length; i++)
        {
            kitchenShortSword[i] = Instantiate(itemdatabase.equipmentDB[2].prefab);
            kitchenShortSword[i].SetActive(false);
        }
        for (int i = 0; i < woodenShortSword.Length; i++)
        {
            woodenShortSword[i] = Instantiate(itemdatabase.equipmentDB[3].prefab);
            woodenShortSword[i].SetActive(false);
        }
        for (int i = 0; i < blackShortSword.Length; i++)
        {
            blackShortSword[i] = Instantiate(itemdatabase.equipmentDB[4].prefab);
            blackShortSword[i].SetActive(false);
        }
        for (int i = 0; i < plantShortSword.Length; i++)
        {
            plantShortSword[i] = Instantiate(itemdatabase.equipmentDB[5].prefab);
            plantShortSword[i].SetActive(false);
        }
        for (int i = 0; i < princeShortSword.Length; i++)
        {
            princeShortSword[i] = Instantiate(itemdatabase.equipmentDB[6].prefab);
            princeShortSword[i].SetActive(false);
        }
        for (int i = 0; i < roundShortSword.Length; i++)
        {
            roundShortSword[i] = Instantiate(itemdatabase.equipmentDB[7].prefab);
            roundShortSword[i].SetActive(false);
        }
        for (int i = 0; i < cactusShortSword.Length; i++)
        {
            cactusShortSword[i] = Instantiate(itemdatabase.equipmentDB[8].prefab);
            cactusShortSword[i].SetActive(false);
        }
        for (int i = 0; i < saberShortSword.Length; i++)
        {
            saberShortSword[i] = Instantiate(itemdatabase.equipmentDB[9].prefab);
            saberShortSword[i].SetActive(false);
        }
        for (int i = 0; i < spineShortSword.Length; i++)
        {
            spineShortSword[i] = Instantiate(itemdatabase.equipmentDB[10].prefab);
            spineShortSword[i].SetActive(false);
        }
        for (int i = 0; i < zeldaShortSword.Length; i++)
        {
            zeldaShortSword[i] = Instantiate(itemdatabase.equipmentDB[11].prefab);
            zeldaShortSword[i].SetActive(false);
        }
        for (int i = 0; i < doranShortSword.Length; i++)
        {
            doranShortSword[i] = Instantiate(itemdatabase.equipmentDB[12].prefab);
            doranShortSword[i].SetActive(false);
        }
        for (int i = 0; i < levatainShortSword.Length; i++)
        {
            levatainShortSword[i] = Instantiate(itemdatabase.equipmentDB[13].prefab);
            levatainShortSword[i].SetActive(false);
        }
        for (int i = 0; i < quadrupleShortSword.Length; i++)
        {
            quadrupleShortSword[i] = Instantiate(itemdatabase.equipmentDB[14].prefab);
            quadrupleShortSword[i].SetActive(false);
        }
        for (int i = 0; i < riceCakeShortSword.Length; i++)
        {
            riceCakeShortSword[i] = Instantiate(itemdatabase.equipmentDB[15].prefab);
            riceCakeShortSword[i].SetActive(false);
        }
        for (int i = 0; i < bloodShortSword.Length; i++)
        {
            bloodShortSword[i] = Instantiate(itemdatabase.equipmentDB[16].prefab);
            bloodShortSword[i].SetActive(false);
        }
        for (int i = 0; i < monsterShortSword.Length; i++)
        {
            monsterShortSword[i] = Instantiate(itemdatabase.equipmentDB[17].prefab);
            monsterShortSword[i].SetActive(false);
        }

        //LongSword
        for (int i = 0; i < bigBrokenLongSword.Length; i++)
        {
            bigBrokenLongSword[i] = Instantiate(itemdatabase.equipmentDB[18].prefab);
            bigBrokenLongSword[i].SetActive(false);
        }
        for (int i = 0; i < jackLongSword.Length; i++)
        {
            jackLongSword[i] = Instantiate(itemdatabase.equipmentDB[19].prefab);
            jackLongSword[i].SetActive(false);
        }
        for (int i = 0; i < militaryLongSword.Length; i++)
        {
            militaryLongSword[i] = Instantiate(itemdatabase.equipmentDB[20].prefab);
            militaryLongSword[i].SetActive(false);
        }
        for (int i = 0; i < rulerLongSword.Length; i++)
        {
            rulerLongSword[i] = Instantiate(itemdatabase.equipmentDB[21].prefab);
            rulerLongSword[i].SetActive(false);
        }
        for (int i = 0; i < candleLongSword.Length; i++)
        {
            candleLongSword[i] = Instantiate(itemdatabase.equipmentDB[22].prefab);
            candleLongSword[i].SetActive(false);
        }
        for (int i = 0; i < cutterLongSword.Length; i++)
        {
            cutterLongSword[i] = Instantiate(itemdatabase.equipmentDB[23].prefab);
            cutterLongSword[i].SetActive(false);
        }
        for (int i = 0; i < darkSoulLongSword.Length; i++)
        {
            darkSoulLongSword[i] = Instantiate(itemdatabase.equipmentDB[24].prefab);
            darkSoulLongSword[i].SetActive(false);
        }
        for (int i = 0; i < redLongSword.Length; i++)
        {
            redLongSword[i] = Instantiate(itemdatabase.equipmentDB[25].prefab);
            redLongSword[i].SetActive(false);
        }
        for (int i = 0; i < thornLongSword.Length; i++)
        {
            thornLongSword[i] = Instantiate(itemdatabase.equipmentDB[26].prefab);
            thornLongSword[i].SetActive(false);
        }
        for (int i = 0; i < bigBlackLongSword.Length; i++)
        {
            bigBlackLongSword[i] = Instantiate(itemdatabase.equipmentDB[27].prefab);
            bigBlackLongSword[i].SetActive(false);
        }
        for (int i = 0; i < bigKitchenLongSword.Length; i++)
        {
            bigKitchenLongSword[i] = Instantiate(itemdatabase.equipmentDB[28].prefab);
            bigKitchenLongSword[i].SetActive(false);
        }
        for (int i = 0; i < dragonLongSword.Length; i++)
        {
            dragonLongSword[i] = Instantiate(itemdatabase.equipmentDB[29].prefab);
            dragonLongSword[i].SetActive(false);
        }
        for (int i = 0; i < fairyLongSword.Length; i++)
        {
            fairyLongSword[i] = Instantiate(itemdatabase.equipmentDB[30].prefab);
            fairyLongSword[i].SetActive(false);
        }
        for (int i = 0; i < coolLongSword.Length; i++)
        {
            coolLongSword[i] = Instantiate(itemdatabase.equipmentDB[31].prefab);
            coolLongSword[i].SetActive(false);
        }
        for (int i = 0; i < gunLongSword.Length; i++)
        {
            gunLongSword[i] = Instantiate(itemdatabase.equipmentDB[32].prefab);
            gunLongSword[i].SetActive(false);
        }
        for (int i = 0; i < lazerLongSword.Length; i++)
        {
            lazerLongSword[i] = Instantiate(itemdatabase.equipmentDB[33].prefab);
            lazerLongSword[i].SetActive(false);
        }
        for (int i = 0; i < devilLongSword.Length; i++)
        {
            devilLongSword[i] = Instantiate(itemdatabase.equipmentDB[34].prefab);
            devilLongSword[i].SetActive(false);
        }
        for (int i = 0; i < iceLongSword.Length; i++)
        {
            iceLongSword[i] = Instantiate(itemdatabase.equipmentDB[35].prefab);
            iceLongSword[i].SetActive(false);
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
            case "SpineShortSword":
                targetPool = spineShortSword;
                break;
            case "SaberShortSword":
                targetPool = saberShortSword;
                break;
            case "LevatainShortSword":
                targetPool = levatainShortSword;
                break;
            case "QuadrupleShortSword":
                targetPool = quadrupleShortSword;
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

            case "BigBrokenLongSword":
                targetPool = bigBrokenLongSword;
                break;
            case "JackLongSword":
                targetPool = jackLongSword;
                break;
            case "MilitaryLongSword":
                targetPool = militaryLongSword;
                break;
            case "RulerLongSword":
                targetPool = rulerLongSword;
                break;
            case "CandleLongSword":
                targetPool = candleLongSword;
                break;
            case "CutterLongSword":
                targetPool = cutterLongSword;
                break;
            case "DarkSoulLongSword":
                targetPool = darkSoulLongSword;
                break;
            case "RedLongSword":
                targetPool = redLongSword;
                break;
            case "ThornLongSword":
                targetPool = thornLongSword;
                break;
            case "BigBlackLongSword":
                targetPool = bigBlackLongSword;
                break;
            case "BigKitchenLongSword":
                targetPool = bigKitchenLongSword;
                break;
            case "DragonLongSword":
                targetPool = dragonLongSword;
                break;
            case "FairyLongSword":
                targetPool = fairyLongSword;
                break;
            case "CoolLongSword":
                targetPool = coolLongSword;
                break;
            case "GunLongSword":
                targetPool = gunLongSword;
                break;
            case "LazerLongSword":
                targetPool = lazerLongSword;
                break;
            case "DevilLongSword":
                targetPool = devilLongSword;
                break;
            case "IceLongSword":
                targetPool = iceLongSword;
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
}
