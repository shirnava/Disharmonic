using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Starts with 10 minutes (600 seconds)
    [SerializeField]
    public float currTime;
    
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        // If there is still time on the clock
        if (currTime > 0)
        {
            // Remove the time the current frame took to execute
            currTime -= Time.deltaTime;
        }
        // If there is no time left
        else
        {
            // Lock the time to 0
            currTime = 0;
        }

        // Update text to reflect current time
        DisplayTime(currTime);
    }

    void DisplayTime(float time)
    {
        // Lock the time to minimum of 0
        if (time < 0)
        {
            time = 0;
        }

        // Extracts the number of minutes from time
        float minutes = Mathf.FloorToInt(time / 60);
        // Extracts the number of seconds from time
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
