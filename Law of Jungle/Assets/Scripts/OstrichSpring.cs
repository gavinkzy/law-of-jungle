using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OstrichSpring : MonoBehaviour
{
    Animator myAnimator;
    public float springPower = 30f;
    Rigidbody2D playerRb;
    Rigidbody2D springRb;
    public bool isDead = false;

    public GameObject explosionEffect;
    public float explosionLifeTime = 3f;
    public float stunDuration = 0.5f;
    private float effectDuration;

    Player playerScript;

    public GameObject myCanvas;
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        springRb = GetComponent<Rigidbody2D>();
        effectDuration = 20f * Time.unscaledDeltaTime;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(isDead && playerScript.myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))))
        {
            Debug.Log("Hit");
            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.velocity = new Vector2(-springPower, springPower);
            isDead = true;
            StartCoroutine(TimeEffect(effectDuration));
            myAnimator.SetBool("dead", isDead);
            StartCoroutine(ExplosionEffect(explosionLifeTime));
            playerScript.ToggleMovement();
            springRb.velocity = new Vector2(playerRb.velocity.x + 3f, playerRb.velocity.y + 3f);
            playerScript.myAnimator.SetBool("victory", true);
            myCanvas.SetActive(true);
        }
    }
    private IEnumerator ExplosionEffect(float explosionLifeTime)
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(explosionLifeTime);
        Destroy(explosion);
    }
    private IEnumerator TimeEffect(float effectDuration)
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(effectDuration);
        Time.timeScale = 1.0f;
    }
}
