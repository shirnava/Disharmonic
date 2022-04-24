using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sunenabled : MonoBehaviour
{
    UnityEngine.GameObject sunLight;

    // Start is called before the first frame update
    void Start()
    {
        sunLight = GameObject.Find("SunLight");
    }

    // Update is called once per frame
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != "Town")
        {
            sunLight.SetActive(false);
        }
        if (currentScene == "Town")
        {
            sunLight.SetActive(true); 
        } 
    }
}
