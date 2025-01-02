using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;
    //public bool isInteracting;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    { 
            inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
            playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
            cameraManager.HandleAllCameraMovement();
    }

}
