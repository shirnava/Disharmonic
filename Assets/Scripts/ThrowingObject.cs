using UnityEngine;
using System.Collections;

public class ThrowingObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    public int dmg;
    private bool touched = false;

    public int touchedButton = 0;

    void Start()
    {
      
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 2.5f)
        {
           if(Input.GetMouseButtonDown(1))
            {
                
                hasPlayer = true;
                touchedButton += 1;
            }
            
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer )
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
              
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(0))
                {
                   // Debug.Log("down 0 rn throwing ball");
                    GetComponent<Rigidbody>().isKinematic = false;
                    transform.parent = null;
                    beingCarried = false;
                     hasPlayer = false;
                     touchedButton = 0;
                    GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
                }
                else if (Input.GetMouseButtonDown(1) && touchedButton == 2)
                {
                   // Debug.Log("in 1  dropping ball ");
                    GetComponent<Rigidbody>().isKinematic = false;
                    transform.parent = null;
                    beingCarried = false;
                    hasPlayer = false;
                     GetComponent<Rigidbody>().AddForce(playerCam.forward * 0);
                     touchedButton = 0;
                }
            }
        }
   void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
    }