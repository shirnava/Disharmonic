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

    public Transform theDest;

 
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);
        
       // if(Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee) )
         //       {       
             try{
if(whatIHit.collider.tag == null)
                    {
                    Debug.Log("its null");

                    }
             }   
             catch
             {
                                     //Debug.Log("its rly null");
                                    // Debug.Log("it hit is: " + ItHit);
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

        //     if(whatIHit.collider.tag == "TestThrowCube")
        //     {
        //         //Debug.Log("I hit it here");
        //         Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
        //         if (Input.GetMouseButtonDown(1))
        //         {
        //             Debug.Log("mouse click wored");
        //             GetComponent<Collider>().enabled = false;
        //             GetComponent<Rigidbody>().useGravity = false;
        //             this.transform.position = theDest.position; 
        //             this.transform.parent = GameObject.Find("Destination").transform;
        //         }
        //         // void OnMouseDown() 
        //         // {
                    

        //         // }
        //         //  void OnMouseUp() 
        //         //     {
        //         //         this.transform.parent = null;
        //         //     GetComponent<BoxCollider>().enabled = true;
        //         //     GetComponent<Rigidbody>().useGravity = true;
        //         // }
        //     }
                 
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
                        SceneManager.LoadScene("PoliceStation", LoadSceneMode.Single);
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
