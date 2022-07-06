using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfElseNode : BTBaseNode
{
    private BTBaseNode checkNode;
    public BTBaseNode  successNode;
    public BTBaseNode  failNode;


    public IfElseNode(BTBaseNode _checkNode, BTBaseNode _succesNode, BTBaseNode _failNode)
    {
        checkNode   = _checkNode;
        successNode = _succesNode;
        failNode = _failNode;
    }

    public override void OnEnter(){}

    public override TaskStatus Run()
    {
        if (checkNode.Run() == TaskStatus.Success) {
            successNode.Run();
            return TaskStatus.Success;
        }
        failNode.Run();
        return TaskStatus.Success;
    }
}

