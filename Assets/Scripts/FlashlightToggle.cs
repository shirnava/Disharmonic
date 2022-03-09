using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    [SerializeField] GameObject Flashlight;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        Flashlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(isActive == false)
            {
                 Flashlight.gameObject.SetActive(true);
                 isActive = true;
            }
            else
            {
                 Flashlight.gameObject.SetActive(false);
                 isActive = false;
            }
        }
    }
}


