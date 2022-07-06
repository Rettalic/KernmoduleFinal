using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStateNode : BTBaseNode
{
    private UINPC UInpc;
    private string state;
    private eText eText;
    public SwitchStateNode(UINPC _UInpc, eText _eText)
    {
        UInpc = _UInpc;
        eText = _eText;

    }

    public override void OnEnter()
    {
    }

    public override TaskStatus Run()
    {
        UInpc.UpdateText(eText);
        return TaskStatus.Success;
    }


}
