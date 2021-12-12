using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugNode : BTBaseNode
{
    string printString;
    public DebugNode(string _printString)
    {
        printString = _printString;
    }

    public override void OnEnter(){}

    public override TaskStatus Run()
    {
        Debug.Log("debug " + printString);
        return TaskStatus.Success;
    }
}
