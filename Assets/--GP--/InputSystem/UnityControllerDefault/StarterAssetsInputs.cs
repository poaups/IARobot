using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class StarterAssetsInputs : MonoBehaviour
{
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

    [SerializeField] private TriggerBox triggerBox;
    [SerializeField] private ShelfManager shelfManager;
    [SerializeField] private LitleForward forwardTriggerPlayer;

    //Each Action
    private InputAction interactionAction;
    private InputAction sprintAction;
    private InputAction jumpAction;
    private InputAction obeyAction;
    private KabotMovement kabotMovement;
    private Controller controller;

#if ENABLE_INPUT_SYSTEM
    private void Awake()
    {
        controller = GetComponent<Controller>();
        kabotMovement = Gamemanager.instance.KabotMovementScript;
        var playerInput = GetComponent<PlayerInput>();

        sprintAction = playerInput.actions["Sprint"];
        interactionAction = playerInput.actions["Interaction"];
        jumpAction = playerInput.actions["Jump"];
        obeyAction = playerInput.actions["LeftMouse"];

        interactionAction.performed += OnInteractionPerformed;
        interactionAction.canceled += OnInteractionCanceled;

        sprintAction.performed += OnSprintPerformed;
        sprintAction.canceled += OnSprintCanceled;

        jumpAction.performed += OnJumpPerformed;
        jumpAction.canceled += OnJumpCanceled;

        obeyAction.performed += OnLeftMousePerformed;
        obeyAction.canceled += OnLeftMouseCanceled;
    }
    private void OnInteractionPerformed(InputAction.CallbackContext context)
    {
        Interaction = true;
        print("E");
        print("Qui est stocke ? " + controller.goStocked);

        if(controller.goStocked != null)
        {
            print("Stocke nest pas null");
            controller.goStocked.Interact();
        }

        if(triggerBox != null )
        {
            triggerBox.IsTakenBox();
        }
        if(shelfManager != null )
        {
            shelfManager.AbleAllShelf();
        }
       
    }
    private void OnInteractionCanceled(InputAction.CallbackContext context)
    {
        Interaction = false;
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
        kabotMovement.Obey();
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
