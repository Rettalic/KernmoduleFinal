using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToBlackboardNode : BTBaseNode
{
    private BlackBoard blackboard;
    private NavMeshAgent agent;
    private float distance;
    private string value;

    public MoveToBlackboardNode(BlackBoard _blackBoard, NavMeshAgent _agent, float _distance, string _value)
    {
        blackboard = _blackBoard;
        agent    = _agent;
        distance = _distance;
        value = _value;
    }

    public override void OnEnter()
    {
    }

    public override TaskStatus Run()
    {
        Debug.Log(blackboard.GetValue<Vector3>("furthest"));
        Debug.Log(agent.pathPending);
        agent.SetDestination(blackboard.GetValue<Vector3>("furthest"));
        if (agent.remainingDistance < distance && !agent.pathPending)
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
