using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("The item not destroyed in PlayerManager is: " + gameObject);
           // Destroy(gameObject);
        }
        else{
           
            instance = this;
        }
        //instance = this;
    }

    #endregion

    public GameObject player;
}
