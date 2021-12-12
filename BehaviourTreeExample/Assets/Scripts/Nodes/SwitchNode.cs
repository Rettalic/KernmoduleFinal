using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchNode : BTBaseNode
{
    BTBaseNode checkNode;
    BTBaseNode successNode;
    BTBaseNode failedNode;

    public SwitchNode(BTBaseNode _checkNode, BTBaseNode _successNode, BTBaseNode _failedNode)
    {
        checkNode   = _checkNode;
        successNode = _successNode;
        failedNode  = _failedNode;
    }

    public override void OnEnter(){}

    public override TaskStatus Run()
    {
        if (checkNode.Run() == TaskStatus.Success)
        {
            successNode.Run();
        }

        failedNode.Run();

        return TaskStatus.Success;
    }
}
