using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //config
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    public bool playerStunned;
    public float stunDuration = 1f;

    //cached references
    Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!playerStunned)
        {
            Move();
            Jump();
        }
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.velocity = new Vector2(-1 * moveSpeed, playerRb.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.velocity = new Vector2(1 * moveSpeed, playerRb.velocity.y);
        }
        
    }

    /*private void Move()
    {
        float x = Input.GetAxis("Horizontal");

        Vector3 playerVelocity = new Vector2(x, playerRb.velocity.y);
        playerVelocity = playerVelocity.normalized * moveSpeed * Time.deltaTime; // framerate independent, normalize to return magnitude of 1 with direction
        playerRb.MovePosition(playerRb.transform.position + playerVelocity);
    }*/

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 playerVelocity = new Vector2(playerRb.velocity.x, jumpSpeed);
            playerRb.velocity = playerVelocity;
        }
    }

    /* private void Move()
     {
         float translation = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
         transform.Translate(translation, 0, 0);


     } */

    private IEnumerator StunHandler(float stunDuration)
    {
        playerStunned = true;
        Debug.Log("Player stunned.");
        yield return new WaitForSeconds(stunDuration);
        playerStunned = false;
        Debug.Log("Player no longer stunned.");
    }

    public void StunPlayer()
    {
        StartCoroutine(StunHandler(stunDuration));
    }
}
    