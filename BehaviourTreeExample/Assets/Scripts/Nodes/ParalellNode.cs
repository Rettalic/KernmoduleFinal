using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalellNode : BTBaseNode
{
    private BTBaseNode[] nodesToEx;

    public ParalellNode(params BTBaseNode[] _nodesToEx)
    {
        nodesToEx = _nodesToEx;
    }
    
    public override void OnEnter()
    {
    }

    public override TaskStatus Run()
    {
        foreach (var node in nodesToEx)
        {
            node.Run();
        }

        return TaskStatus.Success;
        
    }
}

