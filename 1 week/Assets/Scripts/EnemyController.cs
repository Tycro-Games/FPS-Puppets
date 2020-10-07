using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    // Start is called before the first frame update
    private void Start ()
    {
        agent = GetComponent<NavMeshAgent> ();
        agent.updateRotation = false;
        character = GetComponent<ThirdPersonCharacter> ();
    }

    // Update is called once per frame
    private void Update ()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move (agent.desiredVelocity, false, false);
        else
            character.Move (Vector3.zero, false, false);
    }
}