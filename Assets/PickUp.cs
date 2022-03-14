// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUp : MonoBehaviour {

//  float throwForce = 600;
//  Vector3 objectPos;
//  float distance;

//  public bool canHold = true;
//  public GameObject item;
//  public GameObject tempParent;
//  public bool isHolding = false;

//  // Update is called once per frame
//  void Update () {

//      distance = Vector3.Distance (item.transform.position, tempParent.transform.position);
     
//      if (distance >= 1f) 
//     {
//          isHolding = false;
//     }

//     if ( FindObjectOfType<PlayerRaycasting>().ItHitTestCube == true && Input.GetMouseButtonDown(1) && isHolding == false)
//     {
//         Debug.Log("Found the object to pick up");
//         if (distance <= 1f)
//         {
//             isHolding = true;
//             Debug.Log("Holding the object");
//             item.GetComponent<Rigidbody> ().useGravity = false;
//             item.GetComponent<Rigidbody> ().detectCollisions = true;
//             // item.GetComponent<Rigidbody> ().velocity = Vector3.zero;
//             // item.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
//             //item.transform.SetParent (tempParent.transform);
//         }

//     }
//     if (isHolding == true)
//     {
//         item.GetComponent<Rigidbody> ().velocity = Vector3.zero;
//         item.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
//         item.transform.SetParent (tempParent.transform);
//         objectPos = item.transform.position;
           

//     }
//     if (isHolding == true && Input.GetMouseButtonDown(0))
//         {
//             Debug.Log("Throwing the object");
//             item.GetComponent<Rigidbody> ().AddForce (tempParent.transform.forward * throwForce);
//             objectPos = item.transform.position;
//             item.transform.SetParent (null);
//             item.GetComponent<Rigidbody> ().useGravity = true;
//             item.transform.position = objectPos;
//             isHolding = false;
//         }

  
//  }

//  void OnMouseDown() 
//  {
//   if (distance <= 1f)
//   {
//    isHolding = true;
//    item.GetComponent<Rigidbody> ().useGravity = false;
//    item.GetComponent<Rigidbody> ().detectCollisions = true;
//   }
//  }
//  void OnMouseUp() 
//  {
//   isHolding = false;
//  }
// }




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

 public Transform theDest;
  bool amIHolding = false;

 

void Update()
{

    
    if ( FindObjectOfType<PlayerRaycasting>().ItHitTestCube == true && Input.GetMouseButtonDown(1) && amIHolding == false)
    {
        Debug.Log("Picking up object");
        amIHolding = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = theDest.position; 
        this.transform.parent = GameObject.Find("Destination").transform;

        
    }
    if (amIHolding == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Throwing object");
            GetComponent<Rigidbody> ().AddForce (this.transform.forward * 600) ;
            // GetComponent<Rigidbody> ().AddForce (this.transform.up * 200) ;
            this.transform.parent = null;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
            amIHolding = false;
        }
}
 void OnMouseDown() 
 {
  GetComponent<BoxCollider>().enabled = false;
  GetComponent<Rigidbody>().freezeRotation = false;
  GetComponent<Rigidbody>().useGravity = false;
  this.transform.position = theDest.position; 
  this.transform.parent = GameObject.Find("Destination").transform;

 }
 void OnMouseUp() 
 {
     this.transform.parent = null;
     GetComponent<BoxCollider>().enabled = true;
     GetComponent<Rigidbody>().useGravity = true;
 }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Pickup : MonoBehaviour {

//  float throwForce = 600;
//  Vector3 objectPos;
//  float distance;

//  public bool canHold = true;
//  public GameObject item;
//  public GameObject tempParent;
//  public bool isHolding = false;

//  // Update is called once per frame
//  void Update () {

//   distance = Vector3.Distance (item.transform.position, tempParent.transform.position);
//   Debug.Log("distance is: " + distance);
//   if (distance >= 1f) 
//   {
//    isHolding = false;
//   }
//   //Check if isholding
//   if (isHolding == true) {
//    item.GetComponent<Rigidbody> ().velocity = Vector3.zero;
//    item.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
//    item.transform.SetParent (tempParent.transform);

//    if (Input.GetMouseButtonDown (1)) {
//     item.GetComponent<Rigidbody> ().AddForce (tempParent.transform.forward * throwForce);
//     isHolding = false;
//    }
//   }
//   else 
//   {
//    objectPos = item.transform.position;
//    item.transform.SetParent (null);
//    item.GetComponent<Rigidbody> ().useGravity = true;
//    item.transform.position = objectPos;
//   }
//  }

//  void OnMouseDown() 
//  {
//   if (distance <= 1f)
//   {
//    isHolding = true;
//    item.GetComponent<Rigidbody> ().useGravity = false;
//    item.GetComponent<Rigidbody> ().detectCollisions = true;
//   }
//  }
//  void OnMouseUp() 
//  {
//   isHolding = false;
//  }
// }