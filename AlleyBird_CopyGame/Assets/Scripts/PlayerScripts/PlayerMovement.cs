using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 100;

    private bool isLeftDirection = true;

    [SerializeField]
    private Rigidbody2D rb;
    //[SerializeField]
    //private BoxCollider2D boxCollider;

    private string blockTag = "Block";

    private bool isOnGround = true;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask groundDefinition;


    int extraJumpCount;
    [SerializeField]
    int extraJumpCountValue;
    [SerializeField]
    float jumpForce;

    void Start()
    {
        extraJumpCount = extraJumpCountValue;
    }

    private void Update()
    {
        if (isOnGround == true)
            extraJumpCount = extraJumpCountValue;

        if (Input.GetKeyDown(KeyCode.Space) && extraJumpCount > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumpCount--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumpCount == 0 && isOnGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
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
        if (!collision.gameObject.CompareTag(blockTag))
            RotatePlayer();
    }

    void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundDefinition);

        int sign = isLeftDirection == true ? -1 : 1; ;
        transform.position = new Vector3(transform.position.x + (sign * speed / 1000), transform.position.y, transform.position.z);
    }
}
