using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidBody2D;
    public float travelTime = 3f;
    bool flip = false;
    Rigidbody2D player;
    [SerializeField] float knockBackDist = 50f;
    [SerializeField] float knockUpDist = 25f;
    public GameObject explosionEffect;
    public float explosionLifeTime = 3f;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        StartCoroutine(FlipDelay(travelTime));
    }

    void Update()
    {

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
        player = collision.gameObject.GetComponent<Rigidbody2D>();
        //checks if player is on the left
        bool playerOnTheLeft = player.position.x < transform.position.x;
        if (playerOnTheLeft)
        {
            player.velocity = new Vector2(-knockBackDist, knockUpDist);
            Debug.Log("Player knocked back to the left.");
            StartCoroutine(ExplosionEffect(explosionLifeTime));
        }

        //checks if player is on the right
        bool playerOnTheRight = player.position.x > transform.position.x;
        if (playerOnTheRight)
        {
            player.velocity = new Vector2(knockBackDist, knockUpDist);
            Debug.Log("Player knocked back to the right.");
            StartCoroutine(ExplosionEffect(explosionLifeTime));
        }
    }

    private IEnumerator ExplosionEffect(float explosionLifeTime)
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(explosionLifeTime);
        Destroy(explosion);
    }
}
