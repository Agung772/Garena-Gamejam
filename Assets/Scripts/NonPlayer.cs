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
        if (!agent.enabled) return;
        if (agent.remainingDistance < 0.5f)
        {
            float setRandom = 30;

            Vector3 target = new Vector3(Random.Range(-setRandom, setRandom), 0, Random.Range(-setRandom, setRandom));
            agent.SetDestination(target);

            if (transform.position.x > target.x)
            {
                GetComponent<NonPlayerFlip>().SetFlip("Left");
            }
            else
            {
                GetComponent<NonPlayerFlip>().SetFlip("Right");
            }
        }
    }

    public void Active(bool value)
    {
        agent.enabled = value;
    }
}
