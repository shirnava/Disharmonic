using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Vote_Tracker : MonoBehaviour
{

    public int day = 1;
    public int correctVotes = 0;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
