using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObjectPool : MonoBehaviour
{
    public static GeneralObjectPool SharedInstance;
    List<GameObject> pooledObjects;

    [SerializeField]
    GameObject objectToPool;

    [SerializeField]
    public int amountToPool;

    [SerializeField]
    Transform parent;

    [SerializeField]
    string tagName;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, parent);
            tmp.tag = tagName;
            tmp.layer = 10;
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        return null;
    }

    int counterPooledObject = 0;

    public void ReturnToPool()
    {
        if (counterPooledObject >= amountToPool)
            counterPooledObject = 0;

        pooledObjects[counterPooledObject].SetActive(false);
        counterPooledObject++;
    }
}
