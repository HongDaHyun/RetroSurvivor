using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MapManager mapManager;
    public ObjectManager objectManager;

    public Player player;
    public GameObject[] npcPrefab;
    GameObject[] npcs;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GenerateNPC();
    }

    private void Start()
    {
        StartCoroutine(EnemySpawn("RedSlime", 4f, 5, 10));
        StartCoroutine(NPCSpawn(20f, 5, 20));
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

    private void GenerateNPC()
    {
        npcs = new GameObject[npcPrefab.Length];

        for(int i = 0; i < npcPrefab.Length; i++)
        {
            GameObject entity = Instantiate(npcPrefab[i]);
            entity.SetActive(false);
            npcs[i] = entity;
        }
    }

    IEnumerator NPCSpawn(float time, int maxSpawn, int radius)
    {
        while(true)
        {
            int npcCount = (int)GameObject.FindGameObjectsWithTag("NPC").Length;
            if(npcCount < maxSpawn)
            {
                int rand = Random.Range(0, npcs.Length);
                if (npcs[rand].activeSelf)
                    yield return null;
                else
                {
                    npcs[rand].SetActive(true);
                    npcs[rand].transform.position = GetRandomPos(radius);
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