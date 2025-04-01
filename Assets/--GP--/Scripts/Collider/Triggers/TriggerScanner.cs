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
            actionScan.DisplayScan(other.gameObject);
            //other.GetComponent<ScannableObject>();
        }
    }

    private void OnTriggerExit  (Collider other)
    {
        if (other != null && other.GetComponent<ScannableObject>() != null)
        {
            actionScan.UnDisplay();
        }
    }
}
