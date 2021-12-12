using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode : BTBaseNode
{
    float waitTime;
    float startTime;

    public WaitNode(float _waitTime)
    {
        waitTime = _waitTime;
        startTime = Time.time;
    }

    public override void OnEnter()
    {
        startTime = Time.time;
    }

    public override TaskStatus Run()
    {
        //Debug.Log(Time.time + "         " + startTime);
        if(Time.time - startTime >= waitTime)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
        
    }
}
