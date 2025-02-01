using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool canTakeBox;

    public void SetTakeBox(bool newBool)
    {
        print("SetTakeBox" + canTakeBox);
        canTakeBox = newBool;
        print(canTakeBox + " apres fct");
    }
}
