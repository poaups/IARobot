using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class StarterAssetsInputs : MonoBehaviour
{
    public Paper PaperScript;

    [Header("Character Input Values")]

    public Vector2 Move;
    public Vector2 Look;

    public bool Jump;
    public bool Sprint;
    public bool Interaction;
    public bool LeftMouse;

    [Header("Mouse Cursor Settings")]
    public bool CursorLocked = true;
    public bool CursorInputForLook = true;



    //Each Action
    private InputAction interactionAction;
    private InputAction displayUi;
    private InputAction sprintAction;
    private InputAction jumpAction;
    private InputAction obeyAction;
    private KabotMovement kabotMovement;
    private PlayerMovement controller;

#if ENABLE_INPUT_SYSTEM
    private void Awake()
    {
        controller = GetComponent<PlayerMovement>();
        //kabotMovement = Gamemanager.instance.KabotMovementScript;
        var playerInput = GetComponent<PlayerInput>();

        sprintAction = playerInput.actions["Sprint"];
        interactionAction = playerInput.actions["Interaction"];
        jumpAction = playerInput.actions["Jump"];
        obeyAction = playerInput.actions["LeftMouse"];
        displayUi = playerInput.actions["DisplayUi"];

        interactionAction.performed += OnInteractionPerformed;
        interactionAction.canceled += OnInteractionCanceled;

        sprintAction.performed += OnSprintPerformed;
        sprintAction.canceled += OnSprintCanceled;

        jumpAction.performed += OnJumpPerformed;
        jumpAction.canceled += OnJumpCanceled;

        obeyAction.performed += OnLeftMousePerformed;
        obeyAction.canceled += OnLeftMouseCanceled;

        displayUi.performed += OnDisplayUIPerformed;
        displayUi.canceled += OnDisplayUICanceled;
    }
    private void OnInteractionPerformed(InputAction.CallbackContext context)
    {
        //PlayerMovement
        //Gamemanager.instance.SetCanMove(false);

       Interaction = true;

        #region Input Debug
        //print("E");
        // print("Qui est stocke ? " + controller.goStocked);
        #endregion

        if (controller.goStocked != null)
        {
            //controller.SetPick(true);
            controller.goStocked.Interact();
        }
    }
    private void OnInteractionCanceled(InputAction.CallbackContext context)
    {
        Interaction = false;
        //controller.SetPick(false);
    }
    private void OnDisplayUIPerformed(InputAction.CallbackContext context)
    {
        if(PaperScript != null)
        {
            PaperScript.SetDisplayPaper();
        }
        else
        {
            print("Pas de scrit paper");
        }
    }
    private void OnDisplayUICanceled(InputAction.CallbackContext context)
    {
        //F relased
    }

    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        Sprint = true;
    }

    private void OnSprintCanceled(InputAction.CallbackContext context)
    {
        Sprint = false;
    }

    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if (CursorInputForLook)
        {
            LookInput(value.Get<Vector2>());
        }
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Jump = true;
        //Si on veut un keyDown on met une variable true ici 
    }
    private void OnJumpCanceled(InputAction.CallbackContext context)
    {
        Jump = false;
        //Est false ici
    }

    private void OnLeftMousePerformed(InputAction.CallbackContext context)
    {
        LeftMouse = true;
        //kabotMovement.Obey();
    }
    private void OnLeftMouseCanceled(InputAction.CallbackContext context)
    {
        LeftMouse = false;
    }
#endif
    public void MoveInput(Vector2 newMoveDirection)
    {
        Move = newMoveDirection;
    }
    public void LookInput(Vector2 newLookDirection)
    {
        Look = newLookDirection;
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(CursorLocked);
    }
    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
