using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScanner : MonoBehaviour
{
    [SerializeField] private ActionScanTrigger actionScan;
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<ScannableObject>() != null)
        {
            print("Collision");
            actionScan.Instance(other.gameObject);
            //other.GetComponent<ScannableObject>();
        }
    }
}
