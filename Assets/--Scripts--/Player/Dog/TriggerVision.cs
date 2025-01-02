using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DogInteraction;

public class TriggerVision : MonoBehaviour
{
    private DogInteraction _dogInteraction;
    private void Awake()
    {
        _dogInteraction = GetComponentInParent<DogInteraction>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other != null && other.gameObject.GetComponent<CanVision>() != null &&
            (_dogInteraction.currentBehaviors & DogBehaviors.Vision) != 0 && Input.GetKeyDown(KeyCode.R))
        {
            print("R");
            other.gameObject.GetComponent<CanVision>().AbleFoot();
        }
    }


}
