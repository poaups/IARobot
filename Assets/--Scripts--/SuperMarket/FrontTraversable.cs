using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontTraversable : MonoBehaviour
{
    [SerializeField] private TraversableObject traversableObject;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other != null && other.GetComponent<ThirdPersonController>() != null)
    //    {
    //        print("Collision Player via Front");
    //        traversableObject.IsTrigger();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other != null && other.GetComponent<ThirdPersonController>() != null)
    //    {
    //        print("Collision Player via Front");
    //        traversableObject.IsTrigger();
    //    }
    //}
}
