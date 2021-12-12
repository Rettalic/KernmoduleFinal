using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookNode : BTBaseNode
{
    FieldOfView fov;
    
    public LookNode(GameObject _gameObject, LayerMask _targetMask, LayerMask _obstructionMask, float _radius, float _angle)
    {
        fov = new FieldOfView(_gameObject, _targetMask, _obstructionMask, _radius, _angle);
    }

    public override void OnEnter(){}

    public override TaskStatus Run()
    {
        fov.Update();
        if (fov.canSeeTarget)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failed;
    }
}

public class FieldOfView 
{
    private float radius = 120f;
    private float angle = 130;

    public bool canSeeTarget;
    public Transform target;
    public List<Transform> targetList = new List<Transform>();

    private GameObject gameObject;
    private int frameCount;
    private LayerMask targetMask;
    private LayerMask obstructionMask;

    private bool returnList;

    public FieldOfView(GameObject _gameObject, LayerMask _targetMask, LayerMask _obstructionMask, float _radius, float _angle)
    {
        gameObject = _gameObject;
        targetMask = _targetMask;
        obstructionMask = _obstructionMask;
        radius = _radius;
        angle = _angle;
    }

    public FieldOfView(){}

    public void Update()
    {
        if (frameCount % 20 == 0)
        {
            FieldofViewCheck();
        }
        frameCount++;
    }

    private void FieldofViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(gameObject.transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - gameObject.transform.position).normalized;

            if (Vector3.Angle(gameObject.transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(gameObject.transform.position, target.position);

                if (!Physics.Raycast(gameObject.transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeeTarget = true;
                }
                else
                {
                    canSeeTarget = false;
                }
            }
            else
            {
                canSeeTarget = false;
            }
        }
        else if (canSeeTarget)
        {
            canSeeTarget = false;
        }
    }
}