using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : BTBaseNode
{
    BTBaseNode[] inputNodes;
    private int currentIndex;
    private bool hasOnEntered = true;

    public Sequence(params BTBaseNode[] inputNodes)
    {
        this.inputNodes = inputNodes;
    }
    
    public override void OnEnter()
    {
        inputNodes[currentIndex].OnEnter();
    }

    public override TaskStatus Run()
    {
        
        for (; currentIndex < inputNodes.Length; currentIndex++)
        {
            if (hasOnEntered)
            {
                inputNodes[currentIndex].OnEnter();
                hasOnEntered = false;
            }

            TaskStatus result = inputNodes[currentIndex].Run();
            switch (result)
            {
                case TaskStatus.Failed:
                    currentIndex = 0;
                    hasOnEntered = true;
                    return TaskStatus.Failed;

                case TaskStatus.Success:
                    hasOnEntered = true;
                    continue;

                case TaskStatus.Running:
                    return TaskStatus.Running;
            }
        }
        
        currentIndex = 0;
        return TaskStatus.Success;
    }
}
