using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public Day_Vote_Tracker tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("DayTracker").GetComponent<Day_Vote_Tracker>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
          Restart();
        }
    }

    void Restart()
    {
        if (tracker.day == 1)
        {
            SceneManager.LoadScene("Town0");
        }
        else if (tracker.day == 2)
        {
            SceneManager.LoadScene("Town");
        }
    }
}
