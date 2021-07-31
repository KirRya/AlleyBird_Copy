using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private float delay = 0.01f;

    private float increaseAxisY;

    private const float spawnerRange = 1.5f;

    void Start()
    {
        increaseAxisY = player.transform.position.y;
        Invoke("FirstSpawn", delay);
        //Invoke("Check", 1f);
    }

    void Update()
    {
        
    }

    public void FirstSpawn()
    {
        for (int i = 0; i < ObjectPool.SharedInstance.amountToPool; i++)
        {
            increaseAxisY += spawnerRange;

            GameObject block = ObjectPool.SharedInstance.GetPooledObject();
            if (block != null)
            {
                block.transform.position = new Vector2(0, increaseAxisY);
                block.SetActive(true);
            }
        }
    }
    
    //public void Check()
    //{
    //    ObjectPool.SharedInstance.TryToOffRB();
    //}

    
}
