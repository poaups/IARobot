using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private GameObject _Controller1;
    [SerializeField] private GameObject _Controller2;
    [SerializeField] private CameraManager _cameraManagerScripts;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DisableAbleController();
        }
    }

    public void DisableAbleController()
    {
        //if (_Controller1)
        //{
        //    _cameraManagerScripts.ChangeTarget(_Controller2);
        //}
        //else
        //{
        //    _cameraManagerScripts.ChangeTarget(_Controller1);
        //}

        _Controller1.SetActive(!_Controller1.activeSelf);
        _Controller2.SetActive(!_Controller2.activeSelf);

    }
}
