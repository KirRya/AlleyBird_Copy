using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float delay = 0.01f;
    Vector2 increaseVector;

    private const float minSpawnRangeY = 2f;

    private const float minSpawnRangeX = -2.35f;
    private const float maxSpawnRangeX = 2.1f;

    [SerializeField]
    GeneralObjectPool objectPool;

    private const float enemyOffset = 0.18f;

    private void Start()
    {
        Invoke("FirstSpawn", delay);
    }
    void GenerateAxisX()
    {
        if (Random.Range(1, 3) == 1)
            increaseVector.x = minSpawnRangeX;
        else
            increaseVector.x = maxSpawnRangeX;
    }

    void IncreasAxis()
    {
        GenerateAxisX();
        increaseVector.y += (minSpawnRangeY * Random.Range(2, 3)) - enemyOffset;
    }

    private void FirstSpawn()
    {
        for (int i = 0; i < objectPool.amountToPool; i++)
        {
            IncreasAxis();

            GameObject enemy = objectPool.GetPooledObject();
            if (enemy != null)
            {
                enemy.transform.position = increaseVector;
                increaseVector.y += enemyOffset;
                enemy.SetActive(true);
            }
        }
    }

    public void RespawnSingleEnemy()
    {
        objectPool.ReturnToPool();

        IncreasAxis();

        GameObject enemy = objectPool.GetPooledObject();
        if (enemy != null)
        {
            enemy.transform.position = increaseVector;
            enemy.SetActive(true);
        }

        increaseVector.y += enemyOffset;
    }
}
