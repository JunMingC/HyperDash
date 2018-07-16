using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public LevelControl levelControl;
    public GameObject slimePrefab;
    public GameObject rabbitPrefab;
    public float spawnRate;

    private List<GameObject> slimeList;
    private List<GameObject> rabbitList;
    private float spawnTimer;
    private int aliveCount;

    private void Start()
    {
        slimeList = new List<GameObject>();
        rabbitList = new List<GameObject>();
        AddEnemy("Slime", false);
        AddEnemy("Rabbit", false);
    }

    private void Update()
    {
        if (TimeControl.timeHealth > 0)
        {
            CheckAlive();
            SpawnEnemy();
        }
    }

    private void CheckAlive()
    {
        aliveCount = 0;

        for (int i = 0; i < slimeList.Count; i++)
        {
            if(slimeList[i].GetComponent<EnemyControl>().GetAlive())
            {
                aliveCount++;
            }
        }

        for (int i = 0; i < rabbitList.Count; i++)
        {
            if (rabbitList[i].GetComponent<EnemyControl>().GetAlive())
            {
                aliveCount++;
            }
        }
    }

    private void AddEnemy(string monsterType, bool alive)
    {
        if (monsterType == "Slime")
        {
            GameObject temp = Instantiate(slimePrefab, transform);
            temp.GetComponent<EnemyControl>().SetAlive(alive);
            slimeList.Add(temp);
        }
        else if (monsterType == "Rabbit")
        {
            GameObject temp = Instantiate(rabbitPrefab, transform);
            temp.GetComponent<EnemyControl>().SetAlive(alive);
            rabbitList.Add(temp);
        }
    }

    private void SpawnEnemy()
    {
        if(levelControl.maxEnemy > aliveCount)
        {
            if (spawnTimer < 0f)
            {
                int random = Random.Range(0, 10);
                if (random >= levelControl.rabbitRate) // spawn slime
                {
                    for (int i = 0; i < slimeList.Count; i++)
                    {
                        if (!slimeList[i].GetComponent<EnemyControl>().GetAlive())
                        {
                            slimeList[i].GetComponent<EnemyControl>().SetAlive(true);
                            spawnTimer = spawnRate;
                            break;
                        }
                        else if (i >= slimeList.Count - 1)
                        {
                            AddEnemy("Slime", true);
                            spawnTimer = spawnRate;
                            break;
                        }
                    }
                }
                else // spawn rabbit
                {
                    for (int i = 0; i < rabbitList.Count; i++)
                    {
                        if (!rabbitList[i].GetComponent<EnemyControl>().GetAlive())
                        {
                            rabbitList[i].GetComponent<EnemyControl>().SetAlive(true);
                            spawnTimer = spawnRate;
                            break;
                        }
                        else if (i >= rabbitList.Count - 1)
                        {
                            AddEnemy("Rabbit", true);
                            spawnTimer = spawnRate;
                            break;
                        }
                    }
                }
            }
            else
            {
                spawnTimer -= Time.deltaTime * TimeControl.timeMultiplier;
            }
        }
    }
}
