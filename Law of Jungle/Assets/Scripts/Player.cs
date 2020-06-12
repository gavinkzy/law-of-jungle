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
    Animator myAnimator;
    Collider2D myFeetCollider;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.velocity = new Vector2(-1 * moveSpeed, playerRb.velocity.y);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            myAnimator.SetBool("walk", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.velocity = new Vector2(1 * moveSpeed, playerRb.velocity.y);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            myAnimator.SetBool("walk", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            myAnimator.SetBool("walk", false);
        }
        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector3 playerVelocity = new Vector2(playerRb.velocity.x, jumpSpeed);
            playerRb.velocity = playerVelocity;
            myAnimator.SetBool("jump", true);
        }
        if (!(playerRb.velocity.y > 0))
        {
            myAnimator.SetBool("jump", false);
        }
    }

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
    