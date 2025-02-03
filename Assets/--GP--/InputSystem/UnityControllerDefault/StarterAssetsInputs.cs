using UnityEngine;
using UnityEngine.InputSystem;

public class StarterAssetsInputs : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;
    public bool isInteracting { get; private set; }  // Track if interaction key is pressed

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

    // Référence à l'Action 'Interaction' dans le Input System
    private InputAction interactionAction;

#if ENABLE_INPUT_SYSTEM
    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();

        //Ajouter une nouvelle input ou on a besoin de savoir si elle est declanche ou non
        interactionAction = playerInput.actions["Interaction"]; //-> nom de l'input dans l'input system
    }

    private void Update()
    {
        if (interactionAction.triggered)
        {
            isInteracting = true;
            Debug.Log("Interaction déclenchée !");
        }
        else
        {
            isInteracting = false;
        }
        Debug.Log("Interaction actuelle: " + isInteracting);
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

    public void OnJump(InputValue value)
    {
        JumpInput(true);
    }

    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
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

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
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
