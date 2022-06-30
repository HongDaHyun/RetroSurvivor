using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject shortSwordPrefab;

    GameObject[] shortSword = new GameObject[20];

    GameObject[] targetPool;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        for(int i = 0; i < shortSword.Length; i++)
        {
            shortSword[i] = Instantiate(shortSwordPrefab);
            shortSword[i].SetActive(false);
        }
    }

    public GameObject MakeObj(string name)
    {
        switch(name)
        {
            case "ShortSword":
                targetPool = shortSword;
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
