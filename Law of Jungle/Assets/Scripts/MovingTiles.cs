using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTiles : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    public float travelTime = 3f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FlipDelay(travelTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FlipDelay(float travelTime)
    {
        while (true)
        {
            moveSpeed = -moveSpeed;
            rb.velocity = new Vector2(moveSpeed, 0f);
            yield return new WaitForSeconds(travelTime);
        }
    }
}
