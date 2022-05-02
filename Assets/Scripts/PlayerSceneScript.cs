using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static PlayerSceneScript instance;
    
    void Start()
    {
        if(instance != null )
        {
            // Debug.Log("Destroyed in PlayerSceneScript: " + gameObject);
           // Destroy(gameObject);
        }
        else{
           
            instance = this;
        }

        DontDestroyOnLoad(instance);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

