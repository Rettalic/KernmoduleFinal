using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    private BTBaseNode tree;
    private NavMeshAgent agent;
    private Animator animator;

    [SerializeField] Player playerScript;
    [SerializeField] GameObject player;
    [SerializeField] GameObject weapon;
    [SerializeField] private Transform[] target;
    [SerializeField] float distance;
    private bool isPickedUp;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        LayerMask targetMask = LayerMask.GetMask("player");
        LayerMask obstructionMask = LayerMask.GetMask("obstruction");
        float radius = 100f;
        float angle = 130;

        var patrolSequence = new Sequence(                                                           
                new MoveToNode(agent, target[0]),
                new CheckDistanceNode(agent, 0.2f),
                new WaitNode(Random.Range(1f, 2f)),
                new MoveToNode(agent, target[1]),
                new CheckDistanceNode(agent, 0.2f),
                new WaitNode(Random.Range(1f, 2f)),
                new MoveToNode(agent, target[2]),
                new CheckDistanceNode(agent, 0.2f),
                new WaitNode(Random.Range(1f, 2f)),
                new MoveToNode(agent, target[3]),
                new CheckDistanceNode(agent, 0.2f),
                new WaitNode(Random.Range(1f, 2f))
                );

        var shootPlayerSequence = new Sequence(                                                      
                new GetGunNode(weapon, agent, isPickedUp),
                new ChasePlayerNode(agent, player.transform),
                new AttackPlayerNode(agent, this, player.transform, targetMask, 1f, player, distance),
                new ChasePlayerNode(agent, player.transform)
                );

        var lookForPlayerNode = new LookNode(gameObject, targetMask, obstructionMask, radius, angle);

        tree = new SwitchNode(              //Node that switches between patrolling and chasing + getting gun + shooting player
               lookForPlayerNode,             
               shootPlayerSequence,                                                 
               patrolSequence                                                               
               );                                                                      
    }

    private void FixedUpdate()
    {
        tree?.Run();

    }
}
