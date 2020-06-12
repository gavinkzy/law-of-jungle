using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMaster : MonoBehaviour
{
    public float touchCount = 0;
    OstrichSpring MyOstrichSpring;
    bool allowWin = false;
    
    // Start is called before the first frame update
    void Start()
    {
        MyOstrichSpring = GameObject.Find("OstrichSpring").GetComponent<OstrichSpring>();
    }

    // Update is called once per frame
    void Update()
    {
        allowWin = MyOstrichSpring.isDead;
        Debug.Log(allowWin);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (allowWin == true)
        {
            Debug.Log("Player won.");
        }
    }
}
