using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGauge : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other != null && other.gameObject.GetComponent<ImpulsionPanel>() != null)
        {
            print("coolll");
        }
    }
}
