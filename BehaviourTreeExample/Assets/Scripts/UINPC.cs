using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum eUI
{
    Patrolling   = 0,
    Attack       = 1,
    Following    = 2,
    Searching    = 3 

}
public class UINPC : MonoBehaviour
{
    public TMP_Text text;

    public void UpdateText(eUI eUI)
    {
        switch (eUI)
        {
            case eUI.Patrolling:
                text.text = "Just Patrolling around";
                break;
            case eUI.Attack:
                text.text = "I GOT YOU, RUFFIAN!";
                break;
            case eUI.Following:
                text.text = "I am coming for you!";
                break;
            case eUI.Searching:
                text.text = "Let me get a weapon!";
                break;
        }
    }
}
