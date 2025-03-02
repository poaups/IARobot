using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private bool isUp;
    public void Took()
    {
        if(isUp)
        {
            Gamemanager.instance.ControllerPlayer.SetAnimationPick(true);
        }
        else
        {
            Gamemanager.instance.ControllerPlayer.SetAnimationPickDown(true);
            print("Down");
        }
        Gamemanager.instance.SetCanMove(false);
    }
}
