using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private Transform target;

    public void SetDestination (Transform Target)
    {
        target = Target;
    }

    private void Start ()
    {
        agent = GetComponent<NavMeshAgent> ();
    }

    private void Update ()
    {
        if (target != null)
            agent.SetDestination (target.position);
    }
}