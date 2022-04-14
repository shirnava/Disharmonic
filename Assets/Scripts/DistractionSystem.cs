using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionSystem : MonoBehaviour
{
    public Vector3 location;
    public bool noiseMade;

    void OnCollisionEnter(Collision distraction)
    {
        if(distraction.relativeVelocity.magnitude > 2)
        {
            noiseMade = true;
            ContactPoint contact = distraction.contacts[0];
            location = contact.point;
        }
    }

}
