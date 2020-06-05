using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] float springPower = 12f;
    Rigidbody2D gameObjectRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        gameObjectRb = collision.gameObject.GetComponent<Rigidbody2D>();
        gameObjectRb.velocity = new Vector2(gameObjectRb.velocity.x, springPower) ;
    }
}
