using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject shortSwordPrefab;

    GameObject[] basicShortSword = new GameObject[5];

    GameObject[] targetPool;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        for(int i = 0; i < basicShortSword.Length; i++)
        {
            basicShortSword[i] = Instantiate(shortSwordPrefab);
            basicShortSword[i].SetActive(false);
        }
    }

    public GameObject MakeObj(string name)
    {
        switch(name)
        {
            case "BasicShortSword":
                targetPool = basicShortSword;
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
