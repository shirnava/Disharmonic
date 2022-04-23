

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlsToggle : MonoBehaviour
{
    [SerializeField] GameObject ControlsWindow;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        ControlsWindow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(isActive == false)
            {
                 ControlsWindow.gameObject.SetActive(true);
                 isActive = true;
            }
            else
            {
                ControlsWindow.gameObject.SetActive(false);
                 isActive = false;
            }
        }
    }
}


