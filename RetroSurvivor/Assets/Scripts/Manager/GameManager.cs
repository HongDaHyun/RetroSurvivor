using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public MapManager mapManager;
    public ObjectManager objectManager;

    GameObject player;

    public NavMeshSurface2d surface2D;

    public float sensitivity;
    private bool isScrolling;

    GameObject[,] stage = new GameObject[5, 5];

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        InitMap();
        surface2D.BuildNavMesh();

        StartCoroutine(Spawn("GhostPeopleEnemy", 4f));
    }

    private void Update()
    {
        MapScrolling();
        UpdateNav();
    }

    public void InitMap()
    {
        int[] r = { -2, -1, 0, 1, 2 };
        int[] c = { -2, -1, 0, 1, 2 };
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                stage[i, j] = mapManager.MakeMap();
                stage[i, j].transform.position = new Vector2(18 * r[j], 10 * c[i]);
            }
        }
    }

    public void MapScrolling()
    {
        Vector2 memory;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (player.transform.position.x - stage[i, j].transform.position.x > 54)
                {
                    memory = stage[i, j].transform.position;
                    stage[i, j].SetActive(false);
                    stage[i, j] = mapManager.MakeMap();
                    stage[i, j].transform.position = new Vector2(memory.x + 90, memory.y);
                    isScrolling = true;
                }
                if (player.transform.position.x - stage[i, j].transform.position.x < -54)
                {
                    memory = stage[i, j].transform.position;
                    stage[i, j].SetActive(false);
                    stage[i, j] = mapManager.MakeMap();
                    stage[i, j].transform.position = new Vector2(memory.x - 90, memory.y);
                    isScrolling = true;
                }
                if (player.transform.position.y - stage[i, j].transform.position.y > 30)
                {
                    memory = stage[i, j].transform.position;
                    stage[i, j].SetActive(false);
                    stage[i, j] = mapManager.MakeMap();
                    stage[i, j].transform.position = new Vector2(memory.x, memory.y + 50);
                    isScrolling = true;
                }
                if (player.transform.position.y - stage[i, j].transform.position.y < -30)
                {
                    memory = stage[i, j].transform.position;
                    stage[i, j].SetActive(false);
                    stage[i, j] = mapManager.MakeMap();
                    stage[i, j].transform.position = new Vector2(memory.x, memory.y - 50);
                    isScrolling = true;
                }
            }
        }
    }

    public void UpdateNav()
    {
        if (isScrolling)
        {
            surface2D.UpdateNavMesh(surface2D.navMeshData);
            isScrolling = false;
        }
    }

    IEnumerator Spawn(string name, float time)
    {
        while(true)
        {
            GameObject entity = objectManager.MakeObj(name);
            entity.transform.position = GetRandomPos(10);
            yield return new WaitForSeconds(time);
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