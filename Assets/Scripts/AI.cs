using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour{


    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start(){
        startPosition = transform.position;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update(){
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(RoamPosition());
        }
    }

    private Vector3 RoamPosition()
    {
       return startPosition + GetRandomPosition() * Random.Range(10f, 30f);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f)).normalized;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red; ;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
