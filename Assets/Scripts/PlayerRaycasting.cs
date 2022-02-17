using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit whatIHit; 
    public GameObject player; 
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);
        
        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
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
                        }
                        else
                        {
                            Debug.Log("Find the red Key!!!"); 
                        }         
                    } 
                    else if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.greenDoor)
                    {
                        if (player.GetComponent<Inventory>().hasGreenKey == true)
                        {
                            player.GetComponent<Inventory>().hasGreenKey = false;
                            Debug.Log("Clicked on the door will be destroyed: " + whatIHit.collider.gameObject.name);
                            Destroy (whatIHit.collider.gameObject);
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
