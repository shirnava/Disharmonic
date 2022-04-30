using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField] GameObject InventoryWindow;
    [SerializeField] GameObject NoItemsText;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        InventoryWindow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(isActive == false)
            {
                 InventoryWindow.gameObject.SetActive(true);
                 isActive = true;
                
                 if(!NoItemsText){
                    Debug.Log("no items text is null!");
                 }
                 if(InvManager.Instance.Items.Count==0)
                 {
                    NoItemsText.gameObject.SetActive(true);
                 }
                 else
                 {
                    NoItemsText.gameObject.SetActive(false);
                 }

                 InvManager.Instance.ListItems();
            }
            else
            {
                InventoryWindow.gameObject.SetActive(false);
                 isActive = false;
            }
        }
    }
    
}


