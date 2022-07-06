using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundNode : BTBaseNode
{
    private AudioSource aSource;
    private AudioClip clip;

    public PlaySoundNode(AudioSource _aSource, AudioClip _clip)
    {
        aSource = _aSource;
        clip = _clip;

    }
    public override void OnEnter()
    {
    }

    public override TaskStatus Run()
    {
        aSource?.PlayOneShot(clip);
        return TaskStatus.Success;
    }
}
