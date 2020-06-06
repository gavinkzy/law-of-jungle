using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class IdleTimer : MonoBehaviour
{
    [SerializeField] float timeElapsed;
    [SerializeField] TextMeshProUGUI displayTime;

    string display;

    // Start is called before the first frame update
    void Start()
    {
        displayTime.text = timeElapsed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStopwatch();
    }

    private void UpdateStopwatch()
    {
        timeElapsed += Time.deltaTime;
        display = timeElapsed.ToString("F1") + "s";
        displayTime.text = display;
    }
}
