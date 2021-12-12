using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IsCoverAvailableNode : BTBaseNode
{
    private Cover[] avaliableCovers;
    private Transform target;
    private Rogue ai;

    public IsCoverAvailableNode(Cover[] _avaliableCovers, Transform _target, Rogue _ai)
    {
        avaliableCovers = _avaliableCovers;
        target = _target;
        ai = _ai;
    }

    public override void OnEnter() { }

    public override TaskStatus Run()
    {
        Transform bestSpot = FindBestCoverSpot();
        ai.SetBestCoverSpot(bestSpot);
        if(bestSpot != null)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failed;
    }

    private Transform FindBestCoverSpot()
    {
        if (ai.GetBestCoverSpot() != null)
        {
            if (CheckIfSpotIsValid(ai.GetBestCoverSpot()))
            {
                return ai.GetBestCoverSpot();
            }
        }
        float minAngle = 90;
        Transform bestSpot = null;
        for (int i = 0; i < avaliableCovers.Length; i++)
        {
            Transform bestSpotInCover = FindBestSpotInCover(avaliableCovers[i], ref minAngle);
            if (bestSpotInCover != null)
            {
                bestSpot = bestSpotInCover;
            }
        }
        return bestSpot;
    }

    private Transform FindBestSpotInCover(Cover cover, ref float minAngle)
    {
        Transform[] avaliableSpots = cover.GetCoverSpots();
        Transform bestSpot = null;
        for (int i = 0; i < avaliableSpots.Length; i++)
        {
            Vector3 direction = target.position - avaliableSpots[i].position;
            if (CheckIfSpotIsValid(avaliableSpots[i]))
            {
                float angle = Vector3.Angle(avaliableSpots[i].forward, direction);
                if (angle < minAngle)
                {
                    minAngle = angle;
                    bestSpot = avaliableSpots[i];
                }
            }
        }
        return bestSpot;
    }

    private bool CheckIfSpotIsValid(Transform spot)
    {
        RaycastHit hit;
        Vector3 direction = target.position - spot.position;
        if (Physics.Raycast(spot.position, direction, out hit))
        {
            if (hit.collider.transform != target)
            {
                return true;
            }
        }
        return false;
    }

}
