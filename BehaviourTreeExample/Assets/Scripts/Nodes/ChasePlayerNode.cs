using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayerNode : BTBaseNode
{
    private Transform target;
    private NavMeshAgent agent;
    private bool debugBool = false;


    public ChasePlayerNode(NavMeshAgent _agent, Transform _target)
    {
        target = _target;
        agent = _agent;

    }
    public ChasePlayerNode(NavMeshAgent _agent, Transform _target, bool _debugBool)
    {
        target = _target;
        agent = _agent;
        debugBool = _debugBool;
    }


    public override void OnEnter(){}

    public override TaskStatus Run()
    {
        float distance = Vector3.Distance(target.position, agent.transform.position);
        if (debugBool)
        {

            //Debug.Log(distance);
        }
        
        
        if (distance > 4f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return TaskStatus.Running;
        }
        else
        {
            agent.isStopped = true;
            return TaskStatus.Success;
        }
    }
}
