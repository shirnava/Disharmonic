using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvHolder : MonoBehaviour
{
    public GameObject player; 
    public GameObject oldInventory; 
    public bool active = false; 


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCapsule");
        oldInventory = GameObject.Find("SpawnInv");
        


    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("PlayerCapsule");
        oldInventory = GameObject.Find("SpawnInv");


        if(player!=null)
        {   
            active = true;
            player.GetComponent<Inventory>().hasRedKey = oldInventory.GetComponent<InvCopy>().hasRedKey;
            player.GetComponent<Inventory>().hasGreenKey = oldInventory.GetComponent<InvCopy>().hasGreenKey;
            player.GetComponent<Inventory>().hasBlueKey = oldInventory.GetComponent<InvCopy>().hasBlueKey;
            player.GetComponent<Inventory>().hasBookKey = oldInventory.GetComponent<InvCopy>().hasBookKey;

            //oldInventory.GetComponent<InvCopy>.count += 1;
            return;
        }
        

    }
}