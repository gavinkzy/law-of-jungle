using UnityEngine;
using TMPro;


public class IdleTimer : MonoBehaviour
{
    [SerializeField] float timeElapsed;
    [SerializeField] TextMeshProUGUI displayTime;

    string display;
    bool playerIdle;
    
    Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        displayTime.text = timeElapsed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TimeIdle();
    }

    private void TimeIdle()
    {
        if (playerIdle = playerRb.velocity.magnitude == 0)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
        }

        display = timeElapsed.ToString("F1") + "s";
        displayTime.text = display;
    }

}
