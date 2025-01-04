using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private Material _newMat;
    [SerializeField] private List<GameObject> _cables;
    [SerializeField] private GameObject _bridge;
    [SerializeField] private Transform _endPos;
    [SerializeField] private GameObject _camForBridge;
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private DogInteraction _dogInteraction;

    private bool _canMove = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.GetComponent<PlayerLocomotion>() != null)
        {
            _dogInteraction._canOverloading = true;
        }
        else
        {
            _dogInteraction._canOverloading = false;
        }
    }
    private void Update()
    {
        if(_canMove)
        {
            _camForBridge.SetActive(true);
            _mainCamera.SetActive(false);
            _bridge.transform.position = Vector3.MoveTowards(_bridge.transform.position, _endPos.position, 0.03f);
            if(_bridge.transform.position == _endPos.position)
            {
                _mainCamera.SetActive(true);
                _camForBridge.SetActive(false);
               
            }
        }
           
    }

    public void OverLoadingMachine()
    {
        print("OverLoadingMachine");
        foreach (GameObject mat in _cables)
        {
            mat.GetComponent<MeshRenderer>().material = _newMat;
        }
        _canMove = true;
    }


}
