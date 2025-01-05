using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerBreakable : MonoBehaviour
{
    [SerializeField] private Transform _parentPos;
    private void OnTriggerStay(Collider other)
    {
        if (other != null && other.gameObject.GetComponent<CanBreakable>() != null && GetComponentInParent<DogInteraction>()._canImpulse == true)
        {
            if (other.gameObject.GetComponent<CanBreakable>()._alreadyBreak == false)
            {
                print("Trigger TriggerBreakable");
                other.gameObject.GetComponent<CanBreakable>().Impulsion(_parentPos.position);
            }
         
        }

        //if (other != null && other.gameObject.GetComponent<CanBreakable>() != null)
        //{
        //    print("col");
        //}
    }
}
