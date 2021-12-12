using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : BTBaseNode
{
    private Guard ai;
    private float threshold;

    public HealthNode(Guard ai, float threshold)
    {
        this.ai = ai;
        this.threshold = threshold;
    } 

    public override void OnEnter(){}

    public override TaskStatus Run()
    {
        /*if(ai.currentHealth < threshold)
        {
            return TaskStatus.Failed;
        }*/
        return TaskStatus.Success;
        //return ai.currentHealth <= threshold ? TaskStatus.Success: TaskStatus.Failed;
    }
}
