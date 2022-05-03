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
        switch(currentScene)
        {
            case "Town":
            case "Town0":
            case "TC":
            case "TD":
            case "TL1":
            case "TL2":
            case "TP1":
            case "TP2":
            case "TS":
            case "0TC":
            case "0TD":
            case "0TL1":
            case "0TL2":
            case "0TP1":
            case "0TP2":
            case "0TS":
                sunLight.SetActive(true);
            break;
            default:
                sunLight.SetActive(false);
            break;
        }
    }
}
