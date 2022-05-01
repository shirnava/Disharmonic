using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using StarterAssets;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    public string Name;
    public Sprite pict;

    [TextArea(5, 10)]
    public string[] sentences;
    public GameObject player;
    public GameObject enemy;
    public AI talk;



    void Start () {
        
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        player = GameObject.FindWithTag("Player");
        if(GameObject.Find("Enemy") != null)
        {
            talk = GameObject.Find("Enemy").GetComponent<AI>();
        }
       
    }

    void Update () {
        if(GameObject.Find("Enemy") != null)
        {
            talk = GameObject.Find("Enemy").GetComponent<AI>();
        }
        
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y = 575;
        Pos.x = 575;
        ChatBackGround.position = Pos;
          
    }

    public void OnTriggerStay(Collider other)
    {
                
       
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            if(FindObjectOfType<PlayerRaycasting>().ItHit == true)
            {
                
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                dialogueSystem.spr = pict;
                FindObjectOfType<DialogueSystem>().NPCName();
                //Debug.Log("its hit");

                if(talk != null)
                {
                    talk.playerTalking = true;
                }
               

                FindObjectOfType<FirstPersonController>().MoveSpeed = 0.0f;
                FindObjectOfType<FirstPersonController>().SprintSpeed = 0.0f;
                FindObjectOfType<FirstPersonController>().RotationSpeed = 0.0f;
                FindObjectOfType<FirstPersonController>().SpeedChangeRate = 0.0f;

               

            }
            
        }
        
    }

    public void OnTriggerExit()
    {  
        if(talk != null)
        {
            talk.playerTalking = false;
        }

        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;

        FindObjectOfType<FirstPersonController>().MoveSpeed = 4.0f;
        FindObjectOfType<FirstPersonController>().SprintSpeed = 6.0f;
        FindObjectOfType<FirstPersonController>().RotationSpeed = 5.0f;
        FindObjectOfType<FirstPersonController>().SpeedChangeRate = 10.0f;
        

        
    }
}

