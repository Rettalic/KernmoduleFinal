using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetFurthestPositionNode : BTBaseNode
{
    private Vector3[] allPos;
    private Vector3 AIPos;
    private BlackBoard blackBoard;
    private string valName;

    public GetFurthestPositionNode(Vector3 _aIPos, Vector3[] _allPos, BlackBoard _blackBoard, string _valName)
    {
        AIPos      = _aIPos;
        allPos     = _allPos;
        blackBoard = _blackBoard;
        valName    = _valName;
    }
    public override void OnEnter()
    {
    }

    public override TaskStatus Run()
    {
        float maxDis = 0;
        Vector3 maxVec = Vector3.zero;
        foreach (var pos in allPos)
        {
            float distance = Vector3.Distance(pos, AIPos);
            if (distance > maxDis)
            {
                maxDis = distance;
                maxVec = pos;
            }
        }
        blackBoard.SetValue(valName, maxVec);
        //Debug.Log("VEC"+ maxVec);

        return TaskStatus.Success;
    }
}
