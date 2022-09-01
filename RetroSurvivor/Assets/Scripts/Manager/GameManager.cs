using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MapManager mapManager;
    public ObjectManager objectManager;

    public Player player;

    public int money;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        StartCoroutine(EnemySpawn("RedSlime", 4f, 5, 10));
        StartCoroutine(NPCSpawn(20f, 3, 20));
    }

    IEnumerator EnemySpawn(string name, float time, int maxSpawn, int radius)
    {
        while(true)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (monsterCount < maxSpawn)
            {
                GameObject entity = objectManager.MakeObj(name);
                entity.transform.position = GetRandomPos(radius);
                yield return new WaitForSeconds(time);
            }
            else
                yield return null;
        }
    }

    IEnumerator NPCSpawn(float time, int maxSpawn, int radius)
    {
        while(true)
        {
            int npcCount = (int)GameObject.FindGameObjectsWithTag("NPC").Length;
            if(npcCount < maxSpawn)
            {
                int rand = Random.Range(0, objectManager.npcs.Length);
                if (objectManager.npcs[rand].activeSelf)
                    yield return null;
                else
                {
                    objectManager.npcs[rand].SetActive(true);
                    objectManager.npcs[rand].transform.position = GetRandomPos(radius);
                    yield return new WaitForSeconds(time);
                }
            }
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