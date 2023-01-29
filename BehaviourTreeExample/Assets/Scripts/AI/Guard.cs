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

    [SerializeField] ParticleSystem particleSystem;

    [SerializeField] AudioSource aSource;
    [SerializeField] AudioClip clip;
    private bool isPickedUp;
    public BlackBoard blackBoard;

    [SerializeField] UINPC UInpc;
    [SerializeField] eUI eUI;
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        blackBoard = new BlackBoard();
        blackBoard.SetValue("hasWeapon", false);
    }

    private void Start()
    {
        LayerMask targetMask       = LayerMask.GetMask("player");
        LayerMask obstructionMask  = LayerMask.GetMask("obstruction");

        float radius = 100f;
        float angle = 130;

        var patrolSequence = new Sequence(      
                new DebugNode("PATROL"),
                new UpdateUINode(UInpc, eUI.Patrolling),
                new MoveToNode(agent, target[0], 0.4f),
                new MoveToNode(agent, target[1], 0.4f),
                new MoveToNode(agent, target[2], 0.4f),
                new MoveToNode(agent, target[3], 0.4f)
                );

        var shootPlayerSequence = new Sequence(
                new DebugNode("SHOOT"),
                new IfElseNode(
                  new GetBoolNode(blackBoard, "hasWeapon"),                //statement
                  new Sequence(                                            //if true
                    new UpdateUINode(UInpc, eUI.Following),
                    new DebugNode("true"),
                    new ChasePlayerNode(agent, player.transform),
                    new PlaySoundNode(aSource, clip),
                    new PlayEffectNode(particleSystem),
                     new UpdateUINode(UInpc, eUI.Attack),
                    new AttackPlayerNode(agent, this, player.transform, targetMask, 2f, player, distance),
                    new SetBoolNode(blackBoard, "isPickingUp", false),
                    new SetBoolNode(blackBoard, "isShooting", true),
                    new WaitNode(0.3f)
                    ),
                new Sequence(                                              //if false
                    new UpdateUINode(UInpc, eUI.Searching),
                    new DebugNode("false"),
                    new SetBoolNode(blackBoard, "isPickingUp", true),
                    new MoveToObjectNode(weapon, agent),
                    new GetGunNode(weapon, agent, isPickedUp),
                    new SetBoolNode(blackBoard, "hasWeapon",   true)
                    )
                )
            );

        Selector lookForPlayerNode = new Selector(
            new LookNode(gameObject, targetMask, obstructionMask, radius, angle, blackBoard),
            new GetBoolNode(blackBoard, "isPickingUp")
            );

        tree = new ParalellNode(
                new IfElseNode(              
                   lookForPlayerNode,                                    //statement
                   new IfElseNode(                                      //true
                       new GetBoolNode(blackBoard, "hasBombed"),            //state
                       patrolSequence,                                     //true
                       shootPlayerSequence                                   //false
                       ),
                   patrolSequence                                       //false                                              
               ),
            new DelayNode(blackBoard, 6f, "hasBombed", false)
 
        );                                                                      
    }

    private void FixedUpdate()
    {
        tree?.Run();
    }
}
