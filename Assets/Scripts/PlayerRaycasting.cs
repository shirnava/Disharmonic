using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit whatIHit; 
    public GameObject player; 

    public bool ItHit = false;
    public bool ItHitTestCube = false;

    public bool loadFromStation = false;

    public Transform theDest;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCapsule");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        if (loadFromStation == true)
        {
            Debug.Log("look: " + player.transform.position);
            Vector3 pos = transform.position;
                        pos.x = 275.73f;
                        player.transform.position = pos;
        }
        
     
        try
        {
            if(whatIHit.collider.tag == null)
            {
            Debug.Log("its null");

            }
        }   
        catch
        {
            ItHit = false;
        }         
                    
                    
                    
           //     }  
        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
           
            if(whatIHit.collider.tag == "NPC")
                {                   
                    //Debug.Log("Hit NPC");
                    ItHit = true;
                    
                }  
                  
                 if(whatIHit.collider.tag != "NPC")
                {                   
                    //Debug.Log("Not NPC");
                    ItHit = false;
                    
                
                }  

                if(whatIHit.collider.tag == "TestThrowCube")
                {                   
                    //Debug.Log("Hit NPC");
                    ItHitTestCube = true;
                    
                }  
                  
                 if(whatIHit.collider.tag != "TestThrowCube")
                {                   
                    //Debug.Log("Not NPC");
                    ItHitTestCube = false;
                    
                
                }  
                 
            if(Input.GetKeyDown (KeyCode.E)) 
            //if(Input.GetMouseButtonDown(0))
            {      
                      
                if(whatIHit.collider.tag == "Keycards")
                {                   
                    if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.redCard)
                    {
                        
                        player.GetComponent<Inventory>().hasRedKey = true;
                        Debug.Log("Grabbed Key which will now vanish: " + whatIHit.collider.gameObject.name);
                        Destroy (whatIHit.collider.gameObject);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.greenCard)
                    {
                        player.GetComponent<Inventory>().hasGreenKey = true;
                        Debug.Log("Grabbed Key which will now vanish: " + whatIHit.collider.gameObject.name);
                        Destroy (whatIHit.collider.gameObject);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.blueCard)
                    {
                        player.GetComponent<Inventory>().hasBlueKey = true;
                        Debug.Log("Grabbed Key which will now vanish: " + whatIHit.collider.gameObject.name);
                        Destroy (whatIHit.collider.gameObject);
                    }
                }    
                if(whatIHit.collider.tag == "Doors")
                {                   
                    if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.redDoor)
                    {
                        if (player.GetComponent<Inventory>().hasRedKey == true)
                        {
                            player.GetComponent<Inventory>().hasRedKey = false;
                            Debug.Log("Clicked on the door will be destroyed: " + whatIHit.collider.gameObject.name);
                            Destroy (whatIHit.collider.gameObject);
                            
                             SceneManager.LoadScene("Town", LoadSceneMode.Single);
                             
                        }
                        else
                        {
                            Debug.Log("Find the red Key!!!"); 
                        }         
                    } 
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.policeStationDoor)
                    {
                        // Debug.Log("look: " + player.transform.position.x);
                        SceneManager.LoadScene("PoliceStation", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.schoolDoor)
                    {
                        // Debug.Log("look: " + player.transform.position.x);
                        SceneManager.LoadScene("School", LoadSceneMode.Single);
                    }
                     else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.insidePoliceStationDoor)
                    {
                        Vector3 pos = transform.position;
                        pos.x = 275.73f;
                        player.transform.position = pos;
                        loadFromStation = true;
                        SceneManager.LoadScene("Town", LoadSceneMode.Single);
                         
                         
                        //  player.transform.position.x = new Vector3(275.23f, 0, 0);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.greenDoor)
                    {
                        if (player.GetComponent<Inventory>().hasGreenKey == true)
                        {
                            player.GetComponent<Inventory>().hasGreenKey = false;
                            Debug.Log("Clicked on the door will be destroyed: " + whatIHit.collider.gameObject.name);
                            Destroy (whatIHit.collider.gameObject);
                            SceneManager.LoadScene("Town", LoadSceneMode.Single);
                        }
                        else
                        {
                            Debug.Log("Find the green Key!!!"); 
                        }
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.blueDoor)
                    {
                        if (player.GetComponent<Inventory>().hasBlueKey == true)
                        {
                            player.GetComponent<Inventory>().hasBlueKey = false;
                            Debug.Log("Clicked on the door will be destroyed: " + whatIHit.collider.gameObject.name);
                            Destroy (whatIHit.collider.gameObject);
                        }
                        else
                        {
                            Debug.Log("Find the blue Key!!!"); 
                        }
                    }  
                }    
            }
            
        }
    }
}
