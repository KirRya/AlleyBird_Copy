using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject firstBlock;

    private float delay = 0.01f;

    private float increaseAxisY;

    private const float spawnerRange = 2.0f;

    [SerializeField]
    GeneralObjectPool objectPool;

    void Start()
    {
        increaseAxisY = firstBlock.transform.position.y;
        Invoke("FirstSpawn", delay);
    }

    public void FirstSpawn()
    {
        for (int i = 0; i < objectPool.amountToPool; i++)
        {
            increaseAxisY += spawnerRange;

            GameObject block = objectPool.GetPooledObject();
            if (block != null)
            {
                block.transform.position = new Vector2(0, increaseAxisY);
                block.SetActive(true);
            }
        }
    }

    public void RespawnOneBlock()
    {
        objectPool.ReturnToPool();

        increaseAxisY += spawnerRange;

        GameObject block = objectPool.GetPooledObject();
        if (block != null)
        {
            block.transform.position = new Vector2(0, increaseAxisY);
            block.SetActive(true);
        }
    }
}
