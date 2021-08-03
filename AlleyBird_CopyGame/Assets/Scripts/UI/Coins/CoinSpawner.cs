using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float delay = 0.01f;
    Vector2 increaseVector;

    private const float minSpawnRangeY = 2f;

    private const float minSpawnRangeX = -2.35f;
    private const float maxSpawnRangeX = 2.35f;

    [SerializeField]
    CoinCollecting coinCollecting;

    [SerializeField]
    GeneralObjectPool objectPool;

    void Start()
    {
        Invoke("FirstSpawn", delay);
    }
    
    void FirstSpawn()
    {
        for (int i = 0; i < objectPool.amountToPool; i++)
        {
            IncreasAxis();

            GameObject coin = objectPool.GetPooledObject();
            if (coin != null)
            {
                coin.transform.position = increaseVector;
                coin.SetActive(true);
            }
        }
    }

    void IncreasAxis()
    {
        increaseVector.x = Random.Range(minSpawnRangeX, maxSpawnRangeX);
        increaseVector.y += minSpawnRangeY * Random.Range(1, 4);
    }

    public void RespawnOneCoin()
    {
        coinCollecting.CollectOneCoin();

        objectPool.ReturnToPool();

        IncreasAxis();

        GameObject coin = objectPool.GetPooledObject();
        if (coin != null)
        {
            coin.transform.position = increaseVector;
            coin.SetActive(true);
        }
    }
}
