using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEntrance : MonoBehaviour
{
    public string lastExitName;
    string currentScene;
    public bool enemyMarker;
    public bool soccerThrowable; 
    public bool playerMarker; 
    public bool libMarker;
    public GameObject player;

  
    IEnumerator waiter()
    {
        currentScene = SceneManager.GetActiveScene().name;

        // if((PlayerPrefs.GetString("LastExitName") == lastExitName) && (currentScene == "Town"))
        // {
        //     if(soccerThrowable == true)
        //     {
        //         GameObject.FindWithTag("TestThrowCube").transform.position = GameObject.FindWithTag("BallMarker").transform.position;
        //         GameObject.FindWithTag("TestThrowCube").transform.eulerAngles = GameObject.FindWithTag("BallMarker").transform.eulerAngles;     
        //     }
        // }
        
        if(PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            GameObject.Find("GameManager").GetComponent<EnemyManager>().enemy = GameObject.FindWithTag("Enemy");
            if (enemyMarker == true)
            {
                    Debug.Log("im in here");
                    Debug.Log("the enemy transform position : " + GameObject.FindWithTag("EnemyMarker").transform.position);
                  

                    yield return new WaitForSeconds(1);
                    GameObject.FindWithTag("Enemy").transform.position = GameObject.FindWithTag("EnemyMarker").transform.position;
                    GameObject.FindWithTag("Enemy").transform.eulerAngles = GameObject.FindWithTag("EnemyMarker").transform.eulerAngles;
                     
            Debug.Log("the enemy player now position : " + GameObject.FindWithTag("Enemy").transform.position);
            }
            else
            {
                Debug.Log("the transform position : " + transform.position + " the transform is: " + transform);

                GameObject.FindWithTag("Player").transform.position = transform.position; // if its in the x,y,z of the map? 
                
                yield return new WaitForSeconds(0.001f);
       
                Debug.Log("in trigger");
                Debug.Log("The player is: " + GameObject.FindWithTag("Player"));

                GameObject.FindWithTag("Player").transform.position = transform.position;

                Debug.Log("the player now position : " + GameObject.FindWithTag("Player").transform.position);

                GameObject.FindWithTag("CinemachineTarget").transform.position = transform.position;
                GameObject.FindWithTag("Player").transform.eulerAngles = transform.eulerAngles;
                GameObject.FindWithTag("CinemachineTarget").transform.eulerAngles = transform.eulerAngles;

                yield return new WaitForSeconds(1);

                GameObject.FindWithTag("Enemy").transform.position = GameObject.FindWithTag("EnemyMarker").transform.position;
                GameObject.FindWithTag("Enemy").transform.eulerAngles = GameObject.FindWithTag("EnemyMarker").transform.eulerAngles;      
            }
        }
    }
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        StartCoroutine(waiter());
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}