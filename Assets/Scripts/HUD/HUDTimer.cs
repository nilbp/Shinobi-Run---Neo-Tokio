using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTimer : MonoBehaviour
{
    private Text timeText;

    private int minutes = 0;
    private float seconds = 0;

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(seconds < 10 && minutes < 10)
            timeText.text = "0" + minutes + ":0" + (int)seconds;
        else if(seconds < 10)
            timeText.text = minutes + ":0" + (int)seconds;
        else if(minutes < 10)
            timeText.text = "0" + minutes + ":" + (int)seconds;
        else
            timeText.text = minutes + ":" + (int)seconds;

        if (seconds>=60)
        {
            seconds = 0;
            minutes++;
        }

        seconds += Time.deltaTime;


    }
}
