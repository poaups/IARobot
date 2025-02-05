using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class StarterAssetsInputs : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;
    public bool interaction;
    public bool isInteracting { get; private set; }  // Track if interaction key is pressed

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

    //Each Action
    private InputAction interactionAction;
    private InputAction sprintAction;
    private InputAction jumpAction;


#if ENABLE_INPUT_SYSTEM
    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();

        sprintAction = playerInput.actions["Sprint"];
        interactionAction = playerInput.actions["Interaction"];
        jumpAction = playerInput.actions["Jump"];

        interactionAction.performed += OnInteractionPerformed;
        interactionAction.canceled += OnInteractionCanceled;

        sprintAction.performed += OnSprintPerformed;
        sprintAction.canceled += OnSprintCanceled;

        jumpAction.performed += OnJumpPerformed;
        jumpAction.canceled += OnJumpCanceled;
    }

    private void Update()
    {
        print(sprint);
    }
    public bool GetSprint()
    {
        return sprint;
    }

    public bool GetInteraction()
    {
        return interaction;
    }
    private void OnInteractionPerformed(InputAction.CallbackContext context)
    {
        interaction = true;
        Debug.Log("Interaction déclenchée !");
    }
    private void OnInteractionCanceled(InputAction.CallbackContext context)
    {
        interaction = false;
        Debug.Log("Interaction terminée !");
    }

    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        sprint = true;
        Debug.Log("Sprint déclenchée !");
    }

    private void OnSprintCanceled(InputAction.CallbackContext context)
    {
        sprint = false;
        Debug.Log("Sprint terminée !");
    }


    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if (cursorInputForLook)
        {
            LookInput(value.Get<Vector2>());
        }
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        jump = true;
        //Si on veut un keyDown on met une variable true ici 
        Debug.Log("Saut appuyé");
    }
    private void OnJumpCanceled(InputAction.CallbackContext context)
    {
        jump = false;
        //Est false ici
        Debug.Log("Saut relâché");
    }
    
#endif

    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
