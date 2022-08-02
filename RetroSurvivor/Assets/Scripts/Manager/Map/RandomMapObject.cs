using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapObject : MonoBehaviour
{
    public GameObject[] spawnables;
    public Vector2 bottomLeft, topRight;
    public int spawnablesCount;
    GameObject[] g;
    [SerializeField]List<Vector2> savePos;

    private void Awake()
    {
        Generate();
    }

    private void OnEnable()
    {
        ReTransform();
    }

    private void OnDisable()
    {
        ClearAll();
    }

    private void Generate()
    {
        spawnablesCount += Random.Range(0, 6);
        g = new GameObject[spawnablesCount];

        for (int i = 0; i < spawnablesCount; i++)
        {
            int spawnablesArrayIndex = Random.Range(0, spawnables.Length);
            Vector2 pos = new Vector2(x: Random.Range((int)bottomLeft.x, (int)topRight.x), y: Random.Range((int)bottomLeft.y, (int)topRight.y));

            if(savePos.Contains(pos))
                pos = new Vector2(x: Random.Range((int)bottomLeft.x, (int)topRight.x), y: Random.Range((int)bottomLeft.y, (int)topRight.y));

            savePos.Add(pos);
            g[i] = Instantiate(spawnables[spawnablesArrayIndex]);
            g[i].transform.parent = transform;
            g[i].transform.localPosition = pos;
        }
    }

    private void ReTransform()
    {
        for(int i = 0; i < spawnablesCount; i++)
        {
            Vector2 pos = new Vector2(x: Random.Range((int)bottomLeft.x, (int)topRight.x), y: Random.Range((int)bottomLeft.y, (int)topRight.y));

            if (savePos.Contains(pos))
                pos = new Vector2(x: Random.Range((int)bottomLeft.x, (int)topRight.x), y: Random.Range((int)bottomLeft.y, (int)topRight.y));

            savePos.Add(pos);
            g[i].transform.localPosition = pos;
            g[i].SetActive(true);
        }
    }

    private void ClearAll()
    {
        savePos.Clear();
        for (int i = 0; i < spawnablesCount; i++)
            g[i].SetActive(false);
    }
}
