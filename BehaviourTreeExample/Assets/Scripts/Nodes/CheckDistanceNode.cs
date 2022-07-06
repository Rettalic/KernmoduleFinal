using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceNode : BTBaseNode
{
    private Transform agentTransform;
    private GameObject theObject;
    private float distance;

    public CheckDistanceNode(Transform _agentTransform, GameObject _theObject, float _distance)
    {
        agentTransform = _agentTransform;
        theObject      = _theObject;
        distance       = _distance;
    }

    public override void OnEnter()
    {

    }

    public override TaskStatus Run()
    {
        if(Vector3.Distance(agentTransform.position, theObject.transform.position) <= distance)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failed;
    }
}
