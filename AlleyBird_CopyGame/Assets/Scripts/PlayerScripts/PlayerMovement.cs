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
    private string coinTag = "Coin";
    private string enemyTag = "Enemy";

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

    const float getDownInterval = 1.2f;
    const float getDownForce = 5f;
    const float speedConverter = 1000f;


    private bool canJump = true;
    const float banJumpTimer = 1.85f;


    [SerializeField]
    BlockSpawner spawner;

    bool shouldRespawn = false;
    int totalJumpCount = 0;

    [SerializeField]
    GameObject tutorialScreen;

    [SerializeField]
    PlayerScore playerScore;

    [SerializeField]
    CoinSpawner coinSpawner;

    [SerializeField]
    CoinCollecting coinCollecting;

    private bool isGameOnProgress = true;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Sprite deathPlayer;

    [SerializeField]
    SpriteRenderer spriteRender;

    [SerializeField]
    DeathMenuShow deathMenu;

    [SerializeField]
    EnemySpawner enemySpawner;

    void Start()
    {
        extraJumpCount = extraJumpCountValue;
    }

    void IncreaseSpeed()
    {
        speed = speed + (speed / 100.0f);
    }

    private void Update()
    {
        //if (isOnGround == true)
        //    extraJumpCount = extraJumpCountValue;

        ////latest check
        ////Input.GetKeyDown(KeyCode.Space) && extraJumpCount > 0

        //if (Input.GetKeyDown(KeyCode.Space) && extraJumpCount > 0)
        //{
        //    if (isOnGround == true)
        //        Debug.Log("�� �����������");

        //    rb.velocity = Vector2.up * jumpForce;
        //    extraJumpCount--;
        //    //Invoke("GetDown", getDownInterval);
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && extraJumpCount == 0 && isOnGround == true)
        //{

        //    rb.velocity = Vector2.up * jumpForce;
        //}

        if (isGameOnProgress)
        {
            if (!shouldRespawn && totalJumpCount > 3)
                shouldRespawn = true;


            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                tutorialScreen.SetActive(false);
                totalJumpCount++;
                rb.velocity = Vector2.up * jumpForce;
                canJump = false;
                Invoke("JumpAllow", banJumpTimer);
            }
        }
    }

    void JumpAllow()
    {
        IncreaseSpeed();
        playerScore.IncreaseScore();
        canJump = true;
        if(shouldRespawn)
            spawner.RespawnOneBlock();
    }

    //void GetDown()
    //{
    //    rb.velocity = Vector2.down * getDownForce * jumpForce;
    //}

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(coinTag))
            coinSpawner.RespawnOneCoin();
        if (collision.gameObject.CompareTag(enemyTag))
            Death();

    }


    void FixedUpdate()
    {
        if (isGameOnProgress)
        {
            isOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundDefinition);

            int sign = isLeftDirection == true ? -1 : 1; ;
            transform.position = new Vector3(transform.position.x + (sign * speed / speedConverter), transform.position.y, transform.position.z);
        }
    }

    void Death()
    {
        isGameOnProgress = false;
        animator.enabled = false;
        spriteRender.sprite = deathPlayer;
        RotateDeathPlayer();
        coinCollecting.RewriteTotalCoins();
        playerScore.RewriteMaxScore();

        deathMenu.enabled = true;
        deathMenu.PlayerDeath();
    }

    void RotateDeathPlayer()
    {
        transform.rotation = Quaternion.Euler(180, 0, 0);
    }
}
