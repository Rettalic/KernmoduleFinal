using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolNode : BTBaseNode
{
    private BlackBoard blackBoard;
    private string valueName;
    private bool value;
    public SetBoolNode(BlackBoard _blackBoard, string _valueName, bool _value)
    {
        blackBoard = _blackBoard;
        valueName = _valueName;
        value = _value;
    }

    public override TaskStatus Run()
    {
        blackBoard.SetValue(valueName, value);
        return TaskStatus.Success;
    }

    public override void OnEnter()
    {
    } 
}
