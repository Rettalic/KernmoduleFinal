using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUINode : BTBaseNode
{
    UINPC UInpc;
    eUI eUI;

    public UpdateUINode(UINPC _UI, eUI _eUI)
    {
        UInpc = _UI;
        eUI = _eUI;
    }

    public override void OnEnter()
    {
        
    }

    public override TaskStatus Run()
    {
        UInpc.UpdateText(eUI);
        return TaskStatus.Success;

    }
}
