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

                if(whatIHit.collider.tag == "ThrowableObject")
                {                   
                    //Debug.Log("Hit NPC");
                    ItHitTestCube = true;
                    
                }  
                  
                 if(whatIHit.collider.tag != "ThrowableObject")
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
                        InvManager.Instance.Add(whatIHit.collider.gameObject.GetComponent<ItemController>().Item);
                        player.GetComponent<Inventory>().hasRedKey = true;
                        Debug.Log("Grabbed Key which will now vanish: " + whatIHit.collider.gameObject.name);
                        Destroy (whatIHit.collider.gameObject);
                        InvManager.Instance.ListItems();
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.greenCard)
                    {
                        InvManager.Instance.Add(whatIHit.collider.gameObject.GetComponent<ItemController>().Item);
                        player.GetComponent<Inventory>().hasGreenKey = true;
                        Debug.Log("Grabbed Key which will now vanish: " + whatIHit.collider.gameObject.name);
                        Destroy (whatIHit.collider.gameObject);
                        InvManager.Instance.ListItems();
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.blueCard)
                    {
                        InvManager.Instance.Add(whatIHit.collider.gameObject.GetComponent<ItemController>().Item);
                        player.GetComponent<Inventory>().hasBlueKey = true;
                        Debug.Log("Grabbed Key which will now vanish: " + whatIHit.collider.gameObject.name);
                        Destroy (whatIHit.collider.gameObject);
                        InvManager.Instance.ListItems();
                    }
                     else if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.bookCard)
                    {
                        InvManager.Instance.Add(whatIHit.collider.gameObject.GetComponent<ItemController>().Item);
                        player.GetComponent<Inventory>().hasBookKey = true;
                        Debug.Log("Grabbed Key which will now vanish: " + whatIHit.collider.gameObject.name);
                        Destroy (whatIHit.collider.gameObject);
                        InvManager.Instance.ListItems();
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
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.policeStationDoor2)
                    {
                      
                        SceneManager.LoadScene("PoliceStation2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.TP1)
                    {
                      
                        SceneManager.LoadScene("TP1", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.TP2)
                    {
                      
                        SceneManager.LoadScene("TP2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.insidePoliceStationDoor)
                    {
                     
                        SceneManager.LoadScene("TownLeavingPoliceStation", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.schoolDoor)
                    {
                      
                        SceneManager.LoadScene("School", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.churchDoor)
                    {
                        SceneManager.LoadScene("ChurchScene2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.libraryDoor)
                    {                      
                        SceneManager.LoadScene("Library", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.libraryDoor2)
                    {                      
                        SceneManager.LoadScene("Library2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.TL1)
                    {                      
                        SceneManager.LoadScene("TL1", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.TL2)
                    {                      
                        SceneManager.LoadScene("TL2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.TD)
                    {                      
                        SceneManager.LoadScene("TD", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.TS)
                    {                      
                        SceneManager.LoadScene("TS", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.TC)
                    {                      
                        SceneManager.LoadScene("TC", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.dinerDoor)
                    {                      
                        SceneManager.LoadScene("DinerOnly", LoadSceneMode.Single);
                    }




                    // Day 0 Spawning 
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.day0LibraryDoor)
                    {                      
                        SceneManager.LoadScene("Library0", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.day0LibraryDoor2)
                    {                      
                        SceneManager.LoadScene("Library0-2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.day0PoliceStationDoor)
                    {                      
                        SceneManager.LoadScene("PoliceStation0", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.day0PoliceStationDoor2)
                    {                      
                        SceneManager.LoadScene("PoliceStation0-2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.day0ChurchDoor)
                    {                      
                        SceneManager.LoadScene("Church0", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.day0DinerDoor)
                    {                      
                        SceneManager.LoadScene("DinerOnly0", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.day0SchoolDoor)
                    {                      
                        SceneManager.LoadScene("School0", LoadSceneMode.Single);
                    }


                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.Day0TP1)
                    {                      
                        SceneManager.LoadScene("0TP1", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.Day0TP2)
                    {                      
                        SceneManager.LoadScene("0TP2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.Day0TL1)
                    {                      
                        SceneManager.LoadScene("0TL1", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.Day0TL2)
                    {                      
                        SceneManager.LoadScene("0TL2", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.Day0TD)
                    {                      
                        SceneManager.LoadScene("0TD", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.Day0TC)
                    {                      
                        SceneManager.LoadScene("0TC", LoadSceneMode.Single);
                    }
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.Day0TS)
                    {                      
                        SceneManager.LoadScene("0TS", LoadSceneMode.Single);
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
