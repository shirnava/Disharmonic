using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantState : MonoBehaviour
{

    public static PersistantState Instance;
    public string data;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        data = "Town";
        DontDestroyOnLoad(gameObject);
    }
}
