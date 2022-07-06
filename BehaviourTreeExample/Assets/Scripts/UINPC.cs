using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum eText
{
    Patrolling   = 0,
    Noticing     = 1,
    Attack       = 2,
    Following    = 3,
    RunningAway  = 4 ,
    ThrowingGrenade = 5
}
public class UINPC : MonoBehaviour
{
    public TMP_Text text;

    public void UpdateText(eText eText)
    {
        switch (eText)
        {
            case eText.Noticing:
                text.text = "?";
                break;
            case eText.Patrolling:
                text.text = "0";
                break;
            case eText.Attack:
                text.text = "!";
                break;
            case eText.Following:
                text.text = ":)";
                break;
            case eText.RunningAway:
                text.text = ":O";
                break;
            case eText.ThrowingGrenade:
                text.text = ">:)";
                break;
        }
    }
}
