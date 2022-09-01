using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapObject : MonoBehaviour
{
    public GameObject[] fieldGameObject, objGameObject;
    public Vector2 bottomLeft, topRight;
    public int fieldCount, objCount;
    GameObject[] field, obj;
    [SerializeField]List<Vector2> savePos;

    private void Awake()
    {
        GenerateField();
        GenerateObj();
    }

    private void OnEnable()
    {
        ReTransform();
    }

    private void OnDisable()
    {
        ClearAll();
    }

    private void GenerateField()
    {
        fieldCount += Random.Range(0, 6);
        field = new GameObject[fieldCount];

        for (int i = 0; i < fieldCount; i++)
        {
            int spawnablesArrayIndex = Random.Range(0, fieldGameObject.Length);
            Vector2 pos = new Vector2(x: Random.Range((int)bottomLeft.x, (int)topRight.x), y: Random.Range((int)bottomLeft.y, (int)topRight.y));

            if(savePos.Contains(pos))
            {
                i--;
                continue;
            }

            savePos.Add(pos);
            field[i] = Instantiate(fieldGameObject[spawnablesArrayIndex]);
            field[i].transform.parent = transform;
            field[i].transform.localPosition = pos;
        }
    }

    private void GenerateObj()
    {
        objCount += Random.Range(0, 6);
        obj = new GameObject[objCount];

        for (int i = 0; i < objCount; i++)
        {
            int spawnablesArrayIndex = Random.Range(0, objGameObject.Length);
            Vector2 pos = new Vector2(x: Random.Range((int)bottomLeft.x, (int)topRight.x), y: Random.Range((int)bottomLeft.y, (int)topRight.y));

            if (savePos.Contains(pos))
                if (savePos.Contains(pos))
                {
                    i--;
                    continue;
                }

            savePos.Add(pos);
            obj[i] = Instantiate(objGameObject[spawnablesArrayIndex]);
            obj[i].transform.parent = transform;
            obj[i].transform.localPosition = pos;
        }
    }

    private void ReTransform()
    {
        for (int i = 0; i < fieldCount; i++)
        {
            Vector2 pos = new Vector2(x: Random.Range((int)bottomLeft.x, (int)topRight.x), y: Random.Range((int)bottomLeft.y, (int)topRight.y));

            if (savePos.Contains(pos))
                if (savePos.Contains(pos))
                {
                    i--;
                    continue;
                }

            savePos.Add(pos);
            field[i].transform.localPosition = pos;
            field[i].SetActive(true);
        }
        for (int i = 0; i < objCount; i++)
        {
            Vector2 pos = new Vector2(x: Random.Range((int)bottomLeft.x, (int)topRight.x), y: Random.Range((int)bottomLeft.y, (int)topRight.y));

            if (savePos.Contains(pos))
                if (savePos.Contains(pos))
                {
                    i--;
                    continue;
                }

            savePos.Add(pos);
            obj[i].transform.localPosition = pos;
            obj[i].SetActive(true);
        }
    }

    private void ClearAll()
    {
        savePos.Clear();
        for (int i = 0; i < fieldCount; i++)
            field[i].SetActive(false);
        for (int i = 0; i < objCount; i++)
            obj[i].SetActive(false);
    }
}
