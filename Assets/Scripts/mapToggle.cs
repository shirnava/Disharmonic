using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapToggle : MonoBehaviour
{
   [SerializeField] GameObject mapWindow;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        mapWindow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(isActive == false)
            {
                 mapWindow.gameObject.SetActive(true);
                 isActive = true;
            }
            else
            {
                mapWindow.gameObject.SetActive(false);
                 isActive = false;
            }
        }
    }
}
