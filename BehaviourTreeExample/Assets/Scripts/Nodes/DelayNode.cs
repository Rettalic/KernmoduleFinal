using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayNode : BTBaseNode 
{
    private float delayTime;
    private BlackBoard blackBoard;
    private string name;
    private bool onOff;

    private float theTime;
    
    public DelayNode(BlackBoard _blackBoard ,float _delayTime, string _name, bool _onOff)
    {
        delayTime = _delayTime;
        name = _name;
        onOff = _onOff;
        blackBoard = _blackBoard;
        
    }

    public override void OnEnter()
    {
        theTime = Time.time+ delayTime;
    }

    public override TaskStatus Run()
    {
        if (Time.time >= theTime)
        {
            theTime = Time.time + delayTime;
            blackBoard.SetValue(name, onOff);
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }

    
}
