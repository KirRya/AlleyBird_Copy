using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    public BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = prefab.GetComponent<BoxCollider2D>();   
    }
}
