using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawner : MonoBehaviour
{
    [SerializeField]
    EnemySpawner enemySpawner;

    [SerializeField]
    BlockSpawner blockSpawner;

    private const string enemyTag = "Enemy";
    private const string blockTag = "Block";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
            enemySpawner.RespawnSingleEnemy();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(blockTag))
            blockSpawner.RespawnOneBlock();
    }
}
