using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private Material _newMat;
    [SerializeField] private List<GameObject> _cables;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.GetComponent<PlayerLocomotion>() != null)
        {
            print("Collision");
        }
    }

    public void OverLoadingMachine()
    {
        print("OverLoadingMachine");
        foreach (GameObject mat in _cables)
        {
            mat.GetComponent<MeshRenderer>().material = _newMat;
        }
    }
}
