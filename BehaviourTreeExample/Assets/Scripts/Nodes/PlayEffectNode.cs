using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffectNode : BTBaseNode
{
    private ParticleSystem pSystem;

    public PlayEffectNode(ParticleSystem _pSystem)
    {
        pSystem = _pSystem;
    }

    public override void OnEnter()
    {
    }

    public override TaskStatus Run()
    {
        pSystem?.Play();
        return TaskStatus.Success;
    }
}
