using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private DogInteraction _dogInteraction;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void CheckForCost()
    {
        if(Gamemanager.instance.Scraps >= _cost)
        {
            print("Tu peux acheter");
            Gamemanager.instance.Scraps -= _cost;
            //_dogInteraction.Impulsion = 1;

        }
    }
}
