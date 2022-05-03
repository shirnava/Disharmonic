using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InvCopy : MonoBehaviour
{
    public GameObject player; 
    public bool hasRedKey, hasBlueKey, hasGreenKey, hasBookKey;
    public int count; 

    Scene currentScene;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCapsule");
        count = 1;
        

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("PlayerCapsule");
        currentScene = SceneManager.GetActiveScene();


        if(player!= null  )
        {
            if(currentScene.name == "Town" || currentScene.name == "Town0") //|| currentScene.name == "TP2" || currentScene.name == "TL1" ||
             //  currentScene.name == "TL2" || currentScene.name == "TD" ||  currentScene.name == "TC" || currentScene.name == "TS" ||
              // currentScene.name == "Town0" || currentScene.name == "0TP1" || currentScene.name == "0TP2" || currentScene.name == "0TL1" ||
              // currentScene.name == "0TL2" || currentScene.name == "0TD" ||  currentScene.name == "0TC" || currentScene.name == "0TS")
            {
                hasRedKey = player.GetComponent<Inventory>().hasRedKey;
                hasBlueKey = player.GetComponent<Inventory>().hasBlueKey;
                hasGreenKey = player.GetComponent<Inventory>().hasGreenKey;
                hasBookKey = player.GetComponent<Inventory>().hasBookKey;
                return;
            }
            else if (player.GetComponent<InvHolder>().active == true )
            {
                hasRedKey = player.GetComponent<Inventory>().hasRedKey;
                hasBlueKey = player.GetComponent<Inventory>().hasBlueKey;
                hasGreenKey = player.GetComponent<Inventory>().hasGreenKey;
                hasBookKey = player.GetComponent<Inventory>().hasBookKey;

               
            }
            

        }
        

    }
}