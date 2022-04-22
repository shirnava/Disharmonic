using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SoundController : MonoBehaviour
{
    private Vector3 startPosition;
    public float soundRadius;
    public float attackRadius = 15f;
    public float idleSound = 3f;
    public float walkSound = 20f;
    public float runSound = 35f;
    public bool inRange;
    public bool withinAttack;
    Transform target;
    public FirstPersonController player;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<FirstPersonController>();
        startPosition = transform.position;
        target = EnemyManager.instance.enemy.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {

        
            float distance = Vector3.Distance(target.position, transform.position);

            if (player.isRunning == true)
            {
                soundRadius = runSound;
            }
            else if (player.isWalking == true)
            {
                soundRadius = walkSound;
            }
            else if (player.isIdle == true)
            {
                soundRadius = idleSound;
            }


            if(distance <= soundRadius)
            {
                inRange = true;

                if(distance <= attackRadius)
                {
                    withinAttack = true;
                }
                else if(distance > attackRadius)
                {
                    withinAttack = false;
                }
            }

            else
            {
                inRange = false;
                withinAttack = false;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; ;
        Gizmos.DrawWireSphere(transform.position, soundRadius);
    }
}
