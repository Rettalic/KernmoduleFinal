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
        if (isPickedUp)
        {
            return TaskStatus.Success;
        }
    
        weapon.SetActive(false);
        agent.isStopped = true;
        isPickedUp = true;
        return TaskStatus.Success;
    }
}
