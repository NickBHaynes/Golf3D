using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
   // public Transform target;
    public NavMeshAgent agent;

    private bool playerFound;
    public LayerMask layerMask;

    [Header("Random movement")]
    public List<Transform> moveSpots = new List<Transform>();
    private int randomSpot;
    public float startWaitTime;
    private float waitTime;

    private void Start()
    {
        //EventsManager.instance.OnStartGame += StartGame;

      /*  if (FindObjectOfType<OfflinePlayer>() != null)
        {
            target = FindObjectOfType<OfflinePlayer>().transform;
        }
        */
        
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Count - 1);
    }

    // Update is called once per frame
    void Update()
    {

        // Blanked out to experiment with no player finding
        /*
        if (!playerFound)
            {
                SearchForPlayer();
            }

           */
        if (moveSpots != null)
        {
            Move();
        }
    }
/*
    void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

        */

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    /*
    private void SearchForPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, lookRadius, layerMask))
        {
            playerFound = true;
        }
    } */

    private void Move()
    {
       /* 
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && playerFound)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // attack here
                FaceTarget();
            }
        }
        else
        { */
            playerFound = false;
            agent.SetDestination(moveSpots[randomSpot].position);

            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < agent.stoppingDistance)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Count - 1);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
       // }
    }
}
