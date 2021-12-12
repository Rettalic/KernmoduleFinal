using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class Rogue : MonoBehaviour
{
    private BTBaseNode tree;
    [SerializeField] private NavMeshAgent rogue;
    private Animator animator;

    [SerializeField] GameObject player;
    [SerializeField] Player playerScript;

    private bool isDamaged;

    [SerializeField] private Cover[] avaliableCovers;
    private Transform bestCoverSpot;
    private Rogue rogueScript;

    [SerializeField] private GameObject enemy;

    private void Awake()
    {
        rogue = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        LayerMask targetMask = LayerMask.GetMask("player");
        LayerMask obstructionMask = LayerMask.GetMask("obstruction");
        float radius = 100f;
        float angle = 130;

        var lookForPlayerNode = new LookNode(gameObject, targetMask, obstructionMask, radius, angle);

        var followPlayerSequence = new Sequence(
            new DebugNode("Follow"),
            new ChasePlayerNode(rogue, player.transform, true)
            );

        var smokeBombSequence = new Sequence(
            new DebugNode("Smoke"),
            new IsCoverAvailableNode(avaliableCovers, enemy.transform, this),
            new DebugNode(" raaa"),
            new GoToCoverNode(rogue, this),
            new DebugNode("EEEEEEEEEEEEEEEEE"),
            new IsCoveredNode(enemy.transform, transform)
            );

   

        tree = new SwitchNode(                              //Node that switches between patrolling and chasing + getting gun + shooting player
               new PlayerDamagedNode(playerScript, isDamaged),
               smokeBombSequence,
               followPlayerSequence
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
