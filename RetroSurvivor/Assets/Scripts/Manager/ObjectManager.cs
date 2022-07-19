using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Sprite[] weaponSprites;

    public GameObject[] shortSwordPrefabs;
    public GameObject[] enemyPrefabs;

    GameObject[] basicShortSword = new GameObject[5];
    GameObject[] brokenKingShortSword = new GameObject[5];
    GameObject[] princeShortSword = new GameObject[5];
    GameObject[] plantShortSword = new GameObject[5];
    GameObject[] kitchenShortSword = new GameObject[5];
    GameObject[] blackShortSword = new GameObject[5];
    GameObject[] roundShortSword = new GameObject[5];
    GameObject[] woodenShortSword = new GameObject[5];

    GameObject[] ghostPeopleEnemy = new GameObject[200];

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
        for (int i = 0; i < ghostPeopleEnemy.Length; i++)
        {
            ghostPeopleEnemy[i] = Instantiate(enemyPrefabs[0]);
            ghostPeopleEnemy[i].SetActive(false);
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
            case "GhostPeopleEnemy":
                targetPool = ghostPeopleEnemy;
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
