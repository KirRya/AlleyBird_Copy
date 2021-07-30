using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private Transform _transform;

    [SerializeField]
    private float speed = 100;


    void Start()
    {
        _transform = player.transform;
    }


    void Update()
    {
        _transform.position = new Vector3(_transform.position.x - (speed / 10000), 0, 0);
    }

    void RotatePlayer()
    {
        Vector3 theScale = _transform.localScale;
        theScale.x *= -1;
        _transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 collPosition = collision.transform.position;

        
    }
}
