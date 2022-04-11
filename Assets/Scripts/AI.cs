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
    [Range(1, 5)] public float walkRadius;
    public bool waiting = false;
    public float moveDelay = 5;
    public Vector3 centerSearch;
    public Vector3 talkingSearch;
    public AIState currentState;
    [HideInInspector] AIState nextState;
    public float huntSpeed = 5f;
    public float walkSpeed = 3f;
    public SoundController playerSound;
    public PlayerHealth playerHealth;
    public bool playerTalking;

    public enum AIState { Wander, Searching, Hunting, Talking }

    protected void setState(AIState state)
    {
        nextState = state;
        if (nextState != currentState) {
            currentState = nextState;
        }
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
        }
    }


    // Start is called before the first frame update
    void Start() {
        startPosition = transform.position;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(RoamPosition());
        playerSound = GameObject.Find("PlayerCapsule").GetComponent<SoundController>();
        playerHealth = GameObject.Find("PlayerCapsule").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update() {
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

        runState();
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
    float attackTime = 0;
    float attackDelay = 10;

    agent.speed = huntSpeed;
    agent.SetDestination(target.position);

        if (distance <= attackRadius)
        {
            if (Time.time - attackTime < attackDelay)
            {
                return;
            }
            else
            {
                playerHealth.currentHealth -= 50;
                attackTime = Time.time;
            }
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
