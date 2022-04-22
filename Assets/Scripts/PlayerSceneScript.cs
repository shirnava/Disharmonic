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
            Debug.Log("Destroyed in PlayerSceneScript: " + gameObject);
            Destroy(gameObject);
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

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerSceneScript : MonoBehaviour
// {
//     // Start is called before the first frame update
    
//     public static PlayerSceneScript instance;
//     public int count = 0;
//     public GameObject player; 



// IEnumerator waiter()
// {
//     PlayerSceneScript[] playerScripts = player.GetComponents<PlayerSceneScript>();
//      foreach (PlayerSceneScript playerScript in playerScripts) {
//          Debug.Log("Im HEREEEE in foreach");
//      }
//     
//     if(PlayerPrefs.GetString("LastExitName") == player.GetComponent<SceneEntrance>().lastExitName)
//     {
//         Debug.Log("its TIMEEEE");
//     }
//     if(instance != null)
//         {
//             Debug.Log("destroyed: " + gameObject);
//             // yield return new WaitForSeconds(2);
            
//             Destroy(gameObject);
//         }
//         else{
           
//             instance = this;
//         }

    
//         DontDestroyOnLoad(instance);
//     //Rotate 90 deg
//     // transform.Rotate(new Vector3(90, 0, 0), Space.World);

//     // //Wait for 4 seconds
//     // yield return new WaitForSeconds(4);

//     // //Rotate 40 deg
//     // transform.Rotate(new Vector3(40, 0, 0), Space.World);

//     // //Wait for 2 seconds
//     // yield return new WaitForSeconds(2);

//     // //Rotate 20 deg
//     // transform.Rotate(new Vector3(20, 0, 0), Space.World);
// }
    
//     void Start()
//     {
//         // if(instance != null )
//         // {
//         //     Debug.Log("destroyed: " + gameObject);
//         //     Destroy(gameObject);
//         // }
//         // else{
           
//         //     instance = this;
//         // }


//         // DontDestroyOnLoad(instance);
//          player = GameObject.FindWithTag("Player");
        
//          StartCoroutine(waiter());
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
 
//Z