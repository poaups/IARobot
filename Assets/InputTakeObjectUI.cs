using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTakeObjectUI : MonoBehaviour
{
    private ButtonTake buttonTake;
    private void Awake()
    {
        buttonTake = GetComponent<ButtonTake>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            buttonTake.Take();
            print("T");
        }
    }
}
