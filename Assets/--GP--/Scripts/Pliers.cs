using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pliers : MonoBehaviour, IInteraction
{
   /* [HideInInspector]*/ public bool HasPliers = false;
    public void OnInteract()
    {
        HasPliers = true;
    }
    public void UsePliers()
    {
        print("UsePliers");
    }
}
