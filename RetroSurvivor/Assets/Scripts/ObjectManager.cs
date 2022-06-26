using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    public GameObject perfab;
    public int count;
}

public class ObjectManager : MonoBehaviour
{
    public ObjectInfo[] objectInfos = null;

    public GameObject[,] stage1 = new GameObject[12, 9];

    GameObject[] targetPool;

    private void Awake()
    {
        for(int i = 0; i < objectInfos.Length; i++)
        {
            for(int j = 0; j < objectInfos[i].count; j++)
            {
                stage1[i, j] = Instantiate(objectInfos[i].perfab);
                stage1[i, j].SetActive(false);
            }
        }
    }

    public GameObject MakeObj(string type)
    {
        switch(type)
        {
            case "Stage1":
                int rand = Random.Range(0, objectInfos.Length);
                for(int i = 0; i < objectInfos[i].count; i++)
                    if(!stage1[rand, i].activeSelf)
                    {
                        stage1[rand, i].SetActive(true);
                        return stage1[rand, i];
                    }
                targetPool = null;
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
