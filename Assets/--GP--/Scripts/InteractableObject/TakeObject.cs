using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private bool isUp;

    [Header("Variables")]
    [SerializeField] private bool keys;
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
        WichVariablesIncrease();
    }

    void WichVariablesIncrease()
    {
        if(keys)
        {
            Gamemanager.instance.SetPaw(true);
        }
    }
}
