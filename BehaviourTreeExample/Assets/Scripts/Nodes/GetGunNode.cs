using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetGunNode : BTBaseNode
{
    private GameObject weapon;
    private NavMeshAgent agent;
    private bool isPickedUp;

    public GetGunNode(GameObject _weapon, NavMeshAgent _agent, bool _isPickedUp)
    {
        weapon     = _weapon;
        agent      = _agent;
        isPickedUp = _isPickedUp;
        isPickedUp = false;
    }

    public override void OnEnter(){} 

    public override TaskStatus Run()
    {
        float distance = 0;
        if (isPickedUp)
        {
            return TaskStatus.Success;
        }

        distance = Vector3.Distance(weapon.transform.position, agent.transform.position);
        if (distance > 0.4f)
        {
            agent.isStopped = false;
            if (!isPickedUp)
            {
                agent.SetDestination(weapon.transform.position);
            }
            return TaskStatus.Running;
        }
        else
        {
            weapon.SetActive(false);
            agent.isStopped = true;
            isPickedUp = true;
            distance = 0.1f;
            return TaskStatus.Success;
        }

    }
}
