using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using System.Linq;

public class Rogue : MonoBehaviour
{
    private BTBaseNode tree;
    [SerializeField] private NavMeshAgent rogue;
    private Animator animator;

    [SerializeField] GameObject player;
    [SerializeField] Player playerScript;

    [SerializeField] private Transform[] availableCovers;
    private Transform bestCoverSpot;
    private Rogue rogueScript;

    [SerializeField] private GameObject enemy;

    [SerializeField] BlackBoard blackBoard;
    [SerializeField] Guard guard;

    [SerializeField] GameObject grenade;

    private void Awake()
    {
        rogue = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        blackBoard = guard.blackBoard;
        LayerMask targetMask = LayerMask.GetMask("player");
        LayerMask obstructionMask = LayerMask.GetMask("obstruction");
        float radius = 100f;
        float angle = 130;

       // var lookForPlayerNode = new LookNode(gameObject, targetMask, obstructionMask, radius, angle, blackBoard);

        var followPlayerSequence = new Sequence(
            new DebugNode("Follow"),
            new ChasePlayerNode(rogue, player.transform, true)
            );

        var smokeBombSequence = new Sequence(
            new GetFurthestPositionNode(rogue.transform.position, availableCovers.Select(point => point.position).ToArray(), blackBoard, "furthest"),
            new MoveToBlackboardNode(blackBoard, rogue, 0.5f, "furthest"),
            new ThrowGrenadeNode(player.transform, guard.transform, grenade, blackBoard),
            new SetBoolNode(blackBoard, "isShooting", false),
            new SetBoolNode(blackBoard, "hasBombed",  true)
            ) ;

   

        tree = new IfElseNode(                            //Statement
               new GetBoolNode(blackBoard, "isShooting"),
               smokeBombSequence,                         //if true
               followPlayerSequence                       //if false
               );
    }

    private void FixedUpdate()
    {
        tree?.Run();

    }

    public void SetBestCoverSpot(Transform bestCoverSpot)
    {
        this.bestCoverSpot = bestCoverSpot;
    }

    public Transform GetBestCoverSpot()
    {
        return bestCoverSpot;
    }
}
