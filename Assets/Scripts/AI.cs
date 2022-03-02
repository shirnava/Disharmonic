using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour{


    public float lookRadius = 10f;
    public float hearRadius = 20f;
    Transform target;
    NavMeshAgent agent;
    private Vector3 startPosition;
    [Range(1, 10)] public float walkRadius;
    public bool waiting = false;
    public float moveDelay = 5f;
    public Vector3 centerSearch;

    public enum State { Wander, Searching, Hunting }

    // Start is called before the first frame update
    void Start(){
        startPosition = transform.position;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(RoamPosition());
        
    }

    // Update is called once per frame
    void Update(){
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
        else if(distance <= hearRadius)
        {
            centerSearch = target.position;
            agent.SetDestination(centerSearch);
        }
        else
        {
            if(agent != null && agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(RoamPosition());
            waiting = true;
            StartCoroutine(Wait());
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
    }
}
