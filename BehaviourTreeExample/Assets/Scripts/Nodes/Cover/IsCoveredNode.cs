using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCoveredNode : BTBaseNode
{
    private Transform target;
    private Transform origin;

    public IsCoveredNode(Transform target, Transform origin)
    {
        this.target = target;
        this.origin = origin;
    }

    public override void OnEnter() { }

    public override TaskStatus Run()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin.position, target.position - origin.position, out hit))
        {
            if (hit.collider.transform != target)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failed;
    }
}
