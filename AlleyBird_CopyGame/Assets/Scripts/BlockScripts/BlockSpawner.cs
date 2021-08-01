using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject firstBlock;

    private float delay = 0.01f;

    private float increaseAxisY;

    private const float spawnerRange = 2.0f;

    void Start()
    {
        increaseAxisY = firstBlock.transform.position.y;
        Invoke("FirstSpawn", delay);
    }

    public void FirstSpawn()
    {
        for (int i = 0; i < ObjectPool.SharedInstance.amountToPool; i++)
        {
            increaseAxisY += spawnerRange;

            BlockView block = ObjectPool.SharedInstance.GetPooledObject();
            if (block != null)
            {
                block.prefab.transform.position = new Vector2(0, increaseAxisY);
                block.prefab.SetActive(true);
            }
        }
    }

    public void RespawnOneBlock()
    {
        ObjectPool.SharedInstance.ReturnToPool();

        increaseAxisY += spawnerRange;

        BlockView block = ObjectPool.SharedInstance.GetPooledObject();
        if (block != null)
        {
            block.prefab.transform.position = new Vector2(0, increaseAxisY);
            block.prefab.SetActive(true);
        }
    }
}
