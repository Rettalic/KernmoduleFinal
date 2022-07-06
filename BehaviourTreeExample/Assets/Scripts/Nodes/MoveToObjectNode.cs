using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObjectNode : BTBaseNode
{
    private GameObject theObject;
    private NavMeshAgent agent;

    public MoveToObjectNode(GameObject _theObject, NavMeshAgent _agent)
    {
        theObject = _theObject;
        agent = _agent;
    }

    public override void OnEnter()
    {
    }

    public override TaskStatus Run()
    {
        agent.SetDestination(theObject.transform.position);
        if (agent.remainingDistance < 0.6f)
        {
            return TaskStatus.Success;

        }
        else
        {
            agent.isStopped = false;
            return TaskStatus.Running;
        }
    }
}
