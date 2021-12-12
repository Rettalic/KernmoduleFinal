using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedNode : BTBaseNode
{
    Player player;
    bool isDamaged;

    public PlayerDamagedNode(Player _player, bool _isDamaged)
    {
        player = _player;
        isDamaged = _isDamaged;
    }
    public override void OnEnter(){}

    public override TaskStatus Run()
    {
      //  Debug.Log(player.currentHealth);
        if (player.currentHealth < 50)
        {
            isDamaged = true;
            
        }

        if (isDamaged == true)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failed;
        }
        
    }
}
