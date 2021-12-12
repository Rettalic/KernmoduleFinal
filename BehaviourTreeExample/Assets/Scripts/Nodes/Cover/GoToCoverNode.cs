using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToCoverNode : BTBaseNode
{
    private NavMeshAgent agent;
    private Rogue ai;

    public GoToCoverNode(NavMeshAgent agent, Rogue ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    public override void OnEnter() { }

    public override TaskStatus Run()
    {
        
        Transform coverSpot = ai.GetBestCoverSpot();
        if (coverSpot == null)
            return TaskStatus.Failed;

        float distance = Vector3.Distance(coverSpot.position, agent.transform.position);
        Debug.Log("distance                         "  +distance);
        if (distance > 0.3f)
        {
            //agent.isStopped = false;
            agent.SetDestination(coverSpot.position);
            return TaskStatus.Running;
        }
        else
        {
            //agent.isStopped = true;
            return TaskStatus.Success;
        }
    }
}
