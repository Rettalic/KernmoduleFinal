using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayerNode : BTBaseNode
{
    private NavMeshAgent agent;
    private Guard ai;
    private Transform target;

    private Vector3 currentVelocity;
    private float smoothDamp;
    private LayerMask mask;
    private float damage;
    GameObject player;
    float distance;


    public AttackPlayerNode(NavMeshAgent _agent, Guard _ai, Transform _target, LayerMask _mask, float _damage, GameObject _player, float _distance)
    {
        agent = _agent;
        ai = _ai;
        target = _target;
        smoothDamp = 1f;
        mask = _mask;
        damage = _damage;
        player = _player;
        distance = _distance;

    }

    public override void OnEnter() { }

    public override TaskStatus Run()
    {
        agent.isStopped = true;

        Vector3 direction = target.position - ai.transform.position;
        Vector3 currentDirection = Vector3.SmoothDamp(ai.transform.forward, direction, ref currentVelocity, smoothDamp);
        Quaternion rotation = Quaternion.LookRotation(currentDirection, Vector3.up);
        ai.transform.rotation = rotation;

        RaycastHit hit;
        if (Physics.Raycast(agent.transform.position, agent.transform.forward, out hit, mask))
        {
            Player tplayer = hit.collider.GetComponent<Player>();
            var playerLocal = player.GetComponent<Player>();

            
            if (playerLocal != null)
            {
                playerLocal.TakeDamage(damage);
            }
            if (playerLocal.currentHealth == 0)
            {
                return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Running;
            }

        }
        else
        {
            return TaskStatus.Failed;
        }
   

    }


}
