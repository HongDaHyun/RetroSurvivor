using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MapManager mapManager;
    public ObjectManager objectManager;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        StartCoroutine(Spawn("RedMushroom", 4f, 5));
    }

    IEnumerator Spawn(string name, float time, int maxSpawn)
    {
        while(true)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (monsterCount < maxSpawn)
            {
                GameObject entity = objectManager.MakeObj(name);
                entity.transform.position = GetRandomPos(10);
                yield return new WaitForSeconds(time);
            }
            else
                yield return null;
        }
    }

    public Vector3 GetRandomPos(int radius)
    {
        float a = player.transform.position.x;
        float b = player.transform.position.y;

        float x = Random.Range(-radius + a, radius + a);
        float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));
        y_b *= Random.Range(0, 2) == 0 ? -1 : 1;
        float y = y_b + b;

        Vector3 randomPos = new Vector3(x, y, 0);
        return randomPos;
    }
}