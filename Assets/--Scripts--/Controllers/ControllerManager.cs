using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private GameObject _Controller0;
    [SerializeField] private GameObject _Controller1;
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
        //_Controller1.SetActive(!_Controller1.activeSelf);
        //_Controller2.SetActive(!_Controller2.activeSelf);

        Gamemanager.instance.AbleDisableControllers();


        if (Gamemanager.instance._manager[0].enabled == true)
        {
            print("if");
            _cameraManagerScripts.ChangeTarget(_Controller0);
        }
        
        if(Gamemanager.instance._manager[1].enabled == true)
        {
            print("else");
            _cameraManagerScripts.ChangeTarget(_Controller1);
        }



    }
}
