using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public float distance;
    Transform target;
    NavMeshAgent agent;
    private Vector3 startPosition;
    [Range(1, 5)] public float walkRadius = 5;
    public bool waiting = false;
    public float moveDelay = 5;
    public Vector3 centerSearch;
    public Vector3 talkingSearch;
    public Vector3 distractedSearch;
    public AIState currentState;
    [HideInInspector] AIState nextState;
    public float huntSpeed = 4f;
    public float walkSpeed = 2.75f;
    public float cooldownSpeed = 2f;
    public float distractedRange = 25f;
    public SoundController playerSound;
    public PlayerHealth playerHealth;
    public DistractionSystem distractObj;
    public GameObject [] throwableObjects;
    public bool playerTalking = false;
    public int waitTime; 

    public enum AIState { Wander, Searching, Hunting, Talking, Distracted }

    protected void setState(AIState state)
    {
        
        nextState = state;
        if (nextState != currentState) {
            currentState = nextState;
        }

        if(state == AIState.Distracted)
        {
            Distracted();
    }

    protected void runState()
    {
        switch (currentState)
        {
            case AIState.Wander:
                Wander();
                break;

            case AIState.Searching:
                Searching();
                break;

            case AIState.Hunting:
                Hunting();
                break;

            case AIState.Talking:
                Talking();
                break;

            case AIState.Distracted:
                Distracted();
                break;
        }
    }


    // Start is called before the first frame update
    void Start() {
        StartCoroutine(waiter());
       
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(waitTime);

        FindObjectOfType<AudioManager>().PlayIfOff("static");
        startPosition = transform.position;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(RoamPosition());
        playerSound = GameObject.Find("PlayerCapsule").GetComponent<SoundController>();
        playerHealth = GameObject.Find("PlayerCapsule").GetComponent<PlayerHealth>();
        throwableObjects = GameObject.FindGameObjectsWithTag("ThrowableObject");
    }
    
    // Update is called once per frame
    void Update() {
        if(target != null)
        {

        foreach(GameObject distraction in throwableObjects)
        {
        if (distraction.GetComponent<DistractionSystem>().noiseMade == true && Vector3.Distance(distraction.GetComponent<DistractionSystem>().location, transform.position) <= distractedRange)
        {
            distractObj = distraction.GetComponent<DistractionSystem>();
            setState(AIState.Distracted);

        }
        }
        
        distance = Vector3.Distance(target.position, transform.position);

        if(playerTalking == true)
        {
            setState(AIState.Talking);
        }

        else if ((playerSound.inRange == true) && (playerSound.withinAttack == true))
        {
            setState(AIState.Hunting);
        }
        else if ((playerSound.inRange == true) && (playerSound.withinAttack == false))
        {
            setState(AIState.Searching);
        }
        else
        {
            setState(AIState.Wander);

        }

        // Modify volume of static based on distance
        if (distance != 0)
        {
            FindObjectOfType<AudioManager>().ChangeVolume("static", 4 * (1.0f / distance));
        }

        runState();
        }
    }

    private void Distracted()
    {
        agent.speed = walkSpeed;
        distractedSearch = distractObj.location;
        agent.SetDestination(distractedSearch);
        distractObj.noiseMade = false;
    }

    private void Talking()
    {
        agent.speed = 2f;
        talkingSearch = target.position;
        agent.SetDestination(talkingSearch);
    }

    private void Wander()
    {
        agent.speed = walkSpeed;
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(RoamPosition());
        waiting = true;
        StartCoroutine(Wait());
    }

    private void Searching()
    {
        agent.speed = walkSpeed;
        centerSearch = target.position;
        agent.SetDestination(centerSearch);
    }

    private void Hunting()
    {
    float attackTime = -9999;
    float attackDelay = 10000;

    if(playerHealth.attackDisabled == true)
        {
            agent.speed = cooldownSpeed;
        }
    else if(playerHealth.attackDisabled == false)
        {
            agent.speed = huntSpeed;
        }
    agent.SetDestination(target.position);

        if (distance <= attackRadius)
        {
            playerHealth.takeDamage();
        }

    }

    private Vector3 RoamPosition()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        if(NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(moveDelay);
        waiting = false;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red; ;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
