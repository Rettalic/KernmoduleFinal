using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToNode : BTBaseNode
{
    private Transform target;
    private NavMeshAgent agent;
    private float distance;


    public MoveToNode(NavMeshAgent _agent, Transform _target, float _distance)
    {
        target = _target;
        agent = _agent;
        distance = _distance;
    }

    public override void OnEnter(){}

    public override TaskStatus Run()
    {
        if (agent.remainingDistance < distance && !agent.pathPending)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
