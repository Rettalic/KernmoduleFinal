using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToNode : BTBaseNode
{
    private Transform target;
    private NavMeshAgent agent;

    public MoveToNode(NavMeshAgent agent, Transform target)
    {
        this.target = target;
        this.agent = agent;
    }

    public override void OnEnter(){}

    public override TaskStatus Run()
    {
        agent.SetDestination(target.position);
        return TaskStatus.Success;
    }
}
