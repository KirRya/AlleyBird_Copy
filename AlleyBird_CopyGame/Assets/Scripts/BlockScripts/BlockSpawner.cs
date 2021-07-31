using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private float delay = 0.01f;

    private float increaseAxisY;

    void Start()
    {
        Invoke("FirstSpawn", delay);
    }

    void Update()
    {
        
    }

    public void FirstSpawn()
    {
        increaseAxisY = player.transform.position.y;

        GameObject block = ObjectPool.SharedInstance.GetPooledObject();
        if(block != null)
        {
            block.transform.position = new Vector2(0, increaseAxisY + 1.5f);
            block.SetActive(true);
        }
    }
}
