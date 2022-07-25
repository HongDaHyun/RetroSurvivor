using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Sprite[] weaponSprites;

    public GameObject[] shortSwordPrefabs;
    public GameObject[] enemyPrefabs;
    public GameObject dropItemPrefab;

    GameObject[] basicShortSword = new GameObject[5];
    GameObject[] brokenKingShortSword = new GameObject[5];
    GameObject[] princeShortSword = new GameObject[5];
    GameObject[] plantShortSword = new GameObject[5];
    GameObject[] kitchenShortSword = new GameObject[5];
    GameObject[] blackShortSword = new GameObject[5];
    GameObject[] roundShortSword = new GameObject[5];
    GameObject[] woodenShortSword = new GameObject[5];

    GameObject[] greenSlime = new GameObject[100];
    GameObject[] blueSlime = new GameObject[100];
    GameObject[] redSlime = new GameObject[100];
    GameObject[] purpleSlime = new GameObject[100];
    GameObject[] redMushroom = new GameObject[100];
    GameObject[] yellowMushroom = new GameObject[100];
    GameObject[] skyblueMushroom = new GameObject[100];
    GameObject[] blackMushroom = new GameObject[100];

    GameObject[] dropItem = new GameObject[50];

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
        for (int i = 0; i < kitchenShortSword.Length; i++)
        {
            kitchenShortSword[i] = Instantiate(shortSwordPrefabs[4]);
            kitchenShortSword[i].SetActive(false);
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
        for (int i = 0; i < woodenShortSword.Length; i++)
        {
            woodenShortSword[i] = Instantiate(shortSwordPrefabs[7]);
            woodenShortSword[i].SetActive(false);
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

        //DropItem
        for (int i = 0; i < dropItem.Length; i++)
        {
            dropItem[i] = Instantiate(dropItemPrefab);
            dropItem[i].SetActive(false);
        }
    }

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
            case "PrinceShortSword":
                targetPool = princeShortSword;
                break;
            case "PlantShortSword":
                targetPool = plantShortSword;
                break;
            case "KitchenShortSword":
                targetPool = kitchenShortSword;
                break;
            case "BlackShortSword":
                targetPool = blackShortSword;
                break;
            case "RoundShortSword":
                targetPool = roundShortSword;
                break;
            case "WoodenShortSword":
                targetPool = woodenShortSword;
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

            case "DropItem":
                targetPool = dropItem;
                break;
        }
        for(int i = 0; i < targetPool.Length; i++)
        {
            if(!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }
        return null;
    }
}
