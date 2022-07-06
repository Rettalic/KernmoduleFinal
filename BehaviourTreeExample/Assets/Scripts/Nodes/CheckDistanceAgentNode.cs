using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckDistanceAgentNode : BTBaseNode
{
    private NavMeshAgent agent;
    private float distance;

    public CheckDistanceAgentNode(NavMeshAgent agent, float distance)
    {
        this.agent = agent;
        this.distance = distance;

    }
    public override void OnEnter(){}

    public override TaskStatus Run()
    {
       if (agent.remainingDistance < distance && !agent.pathPending)  
       {
           return TaskStatus.Success;
       }

        return TaskStatus.Running;
    }
}
