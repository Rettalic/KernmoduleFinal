using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenadeNode : BTBaseNode
{
    private Transform player;
    private Transform guard;
    private GameObject grenade;
    private BlackBoard blackBoard;

    public ThrowGrenadeNode(Transform _player, Transform _guard, GameObject _grenade, BlackBoard _blackBoard)
    {
        player = _player;
        guard = _guard;
        grenade = _grenade;
        blackBoard = _blackBoard;

    }

    public override void OnEnter()
    {
    }

    public override TaskStatus Run()
    {
        Vector3 midPos = (player.position - (player.position - guard.position)/2);
        GameObject.Instantiate(grenade, midPos, Quaternion.identity);
        Debug.Log(midPos);
        return TaskStatus.Success;
    }

}
