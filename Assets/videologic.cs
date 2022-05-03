using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class videologic : MonoBehaviour
{
    VideoPlayer video;
    Scene a;
    void Awake()
    {
        a = SceneManager.GetActiveScene();
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
 
         
    }
 
 
     void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        if (a.name == "OutroCutscene" || a.name == "OutroCutscene1")
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("Town0", LoadSceneMode.Single);
    }
}

