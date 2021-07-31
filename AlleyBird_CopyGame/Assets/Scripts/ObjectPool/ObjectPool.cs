using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    List<BlockView> pooledObjects;

    [SerializeField]
    BlockView objectToPool;

    [SerializeField]
    public int amountToPool;

    [SerializeField]
    Transform parent;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<BlockView>();
        BlockView tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, parent);
            tmp.prefab.tag = "Block";
            tmp.prefab.layer = 6;
            tmp.prefab.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public BlockView GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].prefab.activeInHierarchy)
                return pooledObjects[i];
        }

        return null;
    }

    public void ReturnToPool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (pooledObjects[i].prefab.activeInHierarchy)
            {
                pooledObjects[i].prefab.SetActive(false);
                break;
            }
        }
    }
}
