using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.GetComponent<PlayerLocomotion>() != null)
        {
            print("Collision");
        }
    }
}
