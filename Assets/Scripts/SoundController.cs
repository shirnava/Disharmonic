using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SoundController : MonoBehaviour
{
    private Vector3 startPosition;
    public float soundRadius;
    public float idleSound = 2f;
    public float walkSound = 5f;
    public float runSound = 10f;
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
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; ;
        Gizmos.DrawWireSphere(transform.position, soundRadius);
    }
}
