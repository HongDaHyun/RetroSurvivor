using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapInfo
{
    public GameObject perfab;
    public int count;
}

public class MapManager : MonoBehaviour
{
    public MapInfo[] mapInfos = null;

    public GameObject[,] stage1 = new GameObject[12, 9];

    GameObject[] targetPool;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < mapInfos.Length; i++)
        {
            for (int j = 0; j < mapInfos[i].count; j++)
            {
                stage1[i, j] = Instantiate(mapInfos[i].perfab);
                stage1[i, j].SetActive(false);
            }
        }
    }

    public GameObject MakeMap()
    {
        int rand = Random.Range(0, mapInfos.Length);
        for (int i = 0; i < mapInfos[i].count; i++)
            if (!stage1[rand, i].activeSelf)
            {
                stage1[rand, i].SetActive(true);
                return stage1[rand, i];
            }
        return null;
    }

}