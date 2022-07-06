using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBoolNode : BTBaseNode
{
    private BlackBoard blackBoard;
    private string valueName;
    public GetBoolNode(BlackBoard _blackBoard, string _valueName)
    {
        blackBoard = _blackBoard;
        valueName = _valueName;
    }

    public override TaskStatus Run()
    {
        bool boolean = blackBoard.GetValue<bool>(valueName);
        if (boolean)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failed;
    }

    public override void OnEnter()
    {
    }

}
