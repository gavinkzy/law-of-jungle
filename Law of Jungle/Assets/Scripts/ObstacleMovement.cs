using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidBody2D;
    public float travelTime = 3f;
    bool flip = false;
    Rigidbody2D playerRb;
    [SerializeField] float knockBackDist = 50f;
    [SerializeField] float knockUpDist = 25f;
    public GameObject explosionEffect;
    public float explosionLifeTime = 3f;
    public float stunDuration = 0.5f;
    Player playerScript;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        StartCoroutine(FlipDelay(travelTime));
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        FlipSprite();
    }

    IEnumerator FlipDelay(float travelTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(travelTime);
            moveSpeed = -moveSpeed;
            rigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        //playerScript = collision.gameObject.GetComponent<Player>();
        //checks if player is on the left
        bool playerOnTheLeft = playerRb.position.x < transform.position.x;
        if (playerOnTheLeft)
        {
            playerRb.velocity = new Vector2(-knockBackDist, knockUpDist);
            //Debug.Log("Player knocked back to the left.");
            playerScript.ToggleMovement();
            StartCoroutine(ExplosionEffect(explosionLifeTime));
        }

        //checks if player is on the right
        bool playerOnTheRight = playerRb.position.x > transform.position.x;
        if (playerOnTheRight)
        {
            playerRb.velocity = new Vector2(knockBackDist, knockUpDist);
            //Debug.Log("Player knocked back to the right.");
            playerScript.ToggleMovement();
            StartCoroutine(ExplosionEffect(explosionLifeTime));
        }
    }

    private IEnumerator ExplosionEffect(float explosionLifeTime)
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(explosionLifeTime);
        Destroy(explosion);
    }

    private void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rigidBody2D.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(rigidBody2D.velocity.x), transform.localScale.y);
        }
    }
}
