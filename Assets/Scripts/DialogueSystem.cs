using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using StarterAssets;

public class DialogueSystem: MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Image portrait;

    public GameObject dialogueGUI;
    public Transform dialogueBoxGUI;

    public float letterDelay = 0.05f; 
    public float letterMultiplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.F;

    public string Names;
    public Sprite spr;
    public string[] dialogueLines;

    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;

    public AudioClip audioClip;
    AudioSource audioSource;
       

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogueText.text = "";
        
        
    }

    void Update()
    {

    }

    public void EnterRangeOfNPC()
    {
        outOfRange = false;
        //dialogueGUI.SetActive(true);
        
        
        if (dialogueActive == true)
        {
            
            //dialogueGUI.SetActive(false);
        }
    }

    public void NPCName()
    {
        outOfRange = false;
        dialogueBoxGUI.gameObject.SetActive(true);
        nameText.text = Names;
        portrait.sprite = spr;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!dialogueActive)
            {
                dialogueActive = true;
                StartCoroutine(StartDialogue());
            }
        }
        StartDialogue();
    }

    private IEnumerator StartDialogue()
    {
        if (outOfRange == false)
        {
            int dialogueLength = dialogueLines.Length;
            int currentDialogueIndex = 0;

            while (currentDialogueIndex < dialogueLength || !letterIsMultiplied)
            {
                if (!letterIsMultiplied)
                {
                    letterIsMultiplied = true;
                    StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));

                    if (currentDialogueIndex >= dialogueLength)
                    {
                        dialogueEnded = true;
                    }
                }

                // Maybe put outside while loop? Test more if this causes a bug
                if(Input.GetKeyDown(KeyCode.R))
                {
                    stopTalking();
                    //Debug.Log("IT IS  R");

                    dialogueEnded = false;
                    dialogueActive = false;
                    DropDialogue();
                }

                yield return 0;
            }

            while (true)
            {
                
                if (Input.GetKeyDown(DialogueInput) && dialogueEnded == false)
                {
                    break;
                }

                if(Input.GetKeyDown(KeyCode.R))
                {
                    stopTalking();
                    //Debug.Log("IT IS  R");

                    dialogueEnded = false;
                    dialogueActive = false;
                    DropDialogue();
                }
                yield return 0;
            }
            dialogueEnded = false;
            dialogueActive = false;
            DropDialogue();
        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        if (outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";

            while (currentCharacterIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;

                if (currentCharacterIndex < stringLength)
                {
                    if (Input.GetKey(DialogueInput))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier);
                        playTalking();
                    }
                    else
                    {
                        yield return new WaitForSeconds(letterDelay);
                        playTalking();

                    }
                }
                else
                {
                    stopTalking();
                    dialogueEnded = false;
                    break;
                }
            }
            while (true)
            {
                if (Input.GetKeyDown(DialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterIsMultiplied = false;
            dialogueText.text = "";
        }
    }

    public void DropDialogue()
    {       
        stopTalking();
        //dialogueGUI.SetActive(false);
        // Debug.Log("Dropping Dialogue!");
        FindObjectOfType<FirstPersonController>().MoveSpeed = 4.0f;
        FindObjectOfType<FirstPersonController>().SprintSpeed = 6.0f;
        FindObjectOfType<FirstPersonController>().RotationSpeed = 5.0f;
        FindObjectOfType<FirstPersonController>().SpeedChangeRate = 10.0f;
        dialogueBoxGUI.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
        stopTalking();
        outOfRange = true;
        if (outOfRange == true)
        {
            //FindObjectOfType<PlayerRaycasting>().ItHit = false;
            letterIsMultiplied = false;
            dialogueActive = false;
            StopAllCoroutines();
            //dialogueGUI.SetActive(false);
            dialogueBoxGUI.gameObject.SetActive(false);
        }
    }

    public void playTalking()
    {
        switch (nameText.text)
        {
        case "Sarah (Police Deputy)":
            FindObjectOfType<AudioManager>().Play("TalkHigh");
            break;
        case "Lilith (Gravekeeper)":
            FindObjectOfType<AudioManager>().Play("TalkMedium");
            break;
        case "Lucas (Receptionist)":
            FindObjectOfType<AudioManager>().Play("TalkHigh");
            break;
        case "Ms. Maria (Teacher)":
            FindObjectOfType<AudioManager>().Play("TalkHigh");
            break;
        case "Rodney (Chief of Police)":
            FindObjectOfType<AudioManager>().Play("TalkLow");
            break;
        case "Janelle (Younger Student)":
            FindObjectOfType<AudioManager>().Play("TalkChild");
            break;
        case "Agnes (Librarian)":
            FindObjectOfType<AudioManager>().Play("TalkLow");
            break;
        case "Michael (Older Student)":
            FindObjectOfType<AudioManager>().Play("TalkMedium");
            break;
        case "Ms. Evans (Michael's Mother)":
            FindObjectOfType<AudioManager>().Play("TalkHigh");
            break;
        case "Clara (Waitress)":
            FindObjectOfType<AudioManager>().Play("TalkMedium");
            break;
        case "Father David (Pastor)":
            FindObjectOfType<AudioManager>().Play("TalkLow");
            break;
        default:
            FindObjectOfType<AudioManager>().Play("TalkLow");
            break;
        }
    }

    public void stopTalking()
    {
        switch (nameText.text)
        {
        case "Sarah (Police Deputy)":
            FindObjectOfType<AudioManager>().Stop("TalkHigh");
            break;
        case "Lilith (Gravekeeper)":
            FindObjectOfType<AudioManager>().Stop("TalkMedium");
            break;
        case "Lucas (Receptionist)":
            FindObjectOfType<AudioManager>().Stop("TalkHigh");
            break;
        case "Ms. Maria (Teacher)":
            FindObjectOfType<AudioManager>().Stop("TalkHigh");
            break;
        case "Rodney (Chief of Police)":
            FindObjectOfType<AudioManager>().Stop("TalkLow");
            break;
        case "Janelle (Younger Student)":
            FindObjectOfType<AudioManager>().Stop("TalkChild");
            break;
        case "Agnes (Librarian)":
            FindObjectOfType<AudioManager>().Stop("TalkLow");
            break;
        case "Michael (Older Student)":
            FindObjectOfType<AudioManager>().Stop("TalkMedium");
            break;
        case "Ms. Evans (Michael's Mother)":
            FindObjectOfType<AudioManager>().Stop("TalkHigh");
            break;
        case "Clara (Waitress)":
            FindObjectOfType<AudioManager>().Stop("TalkMedium");
            break;
        case "Father David (Pastor)":
            FindObjectOfType<AudioManager>().Stop("TalkLow");
            break;
        default:
            FindObjectOfType<AudioManager>().Stop("TalkLow");
            break;
        }
    }
}
