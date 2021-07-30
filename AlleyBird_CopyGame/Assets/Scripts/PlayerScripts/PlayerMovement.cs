using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 100;

    private bool isLeftDirection = true;


    void Start()
    {

    }


    void Update()
    {
        int sign = isLeftDirection == true ? -1 : 1; ;
        transform.position = new Vector3(transform.position.x + (sign * speed / 10000), transform.position.y, transform.position.z);
    }

    void RotatePlayer()
    {        
        isLeftDirection = !isLeftDirection;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Block"))
            RotatePlayer();
    }
}
