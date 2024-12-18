using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float verticalInput;
    public float horizontalInput;

    public float moveAmount;

    public bool b_Input;
    public bool jump_Input;

    public bool rightClickHeld;
    public bool LeftClickHeld;


    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerAction.B.performed += i => b_Input = true;
            playerControls.PlayerAction.B.canceled += i => b_Input = false;

            playerControls.PlayerAction.Jump.performed += i => jump_Input = true;

            playerControls.PlayerAction.MouseRight.performed += i => rightClickHeld = true;
            playerControls.PlayerAction.MouseRight.canceled += i => rightClickHeld = false;

            playerControls.PlayerAction.MouseLeft.performed += i => LeftClickHeld = true;
            playerControls.PlayerAction.MouseLeft.canceled += i => LeftClickHeld = false;
        }

        playerControls.Enable();
    }

    private void HandleSpacebarInput()
    {
        Debug.Log("Spacebar pressed!");
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpingInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;


        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if(b_Input && moveAmount >0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

    private void HandleJumpingInput()
    {
        if (jump_Input)
        {
            playerLocomotion.HandleJumping(); // Assurez-vous que cette fonction g�re le saut.
        }
    }
}
