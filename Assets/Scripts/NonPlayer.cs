using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonPlayer : MonoBehaviour
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            float setRandom = 30;
            agent.SetDestination(new Vector3(Random.Range(-setRandom, setRandom), 0, Random.Range(-setRandom, setRandom)));
        }
    }
}
