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

    private string blockTag = "Block";
    private string coinTag = "Coin";
    private string enemyTag = "Enemy";

    [SerializeField]
    float jumpForce;

    const float getDownInterval = 1.2f;
    const float getDownForce = 5f;
    const float speedConverter = 1000f;


    private bool canJump = true;
    const float banJumpTimer = 1.85f;

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

    void IncreaseSpeed()
    {
        speed = speed + (speed / 100.0f);
    }

    private void Update()
    {
        if (isGameOnProgress)
        {
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
