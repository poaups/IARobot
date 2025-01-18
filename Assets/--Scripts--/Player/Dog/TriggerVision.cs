using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVision : MonoBehaviour
{
    private DogInteraction _dogInteraction;
    //private bool _canVision = false;
    [HideInInspector] public List<GameObject> _goDetected;

    private void Awake()
    {
        _goDetected = new List<GameObject>();
        _dogInteraction = GetComponentInParent<DogInteraction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.GetComponent<CanVision>() != null)
        {
            if (!_goDetected.Contains(other.gameObject))
            {
                _goDetected.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject.GetComponent<CanVision>() != null)
        {
            if (_goDetected.Contains(other.gameObject))
            {
                _goDetected.Remove(other.gameObject);
            }
        }
    }
}
