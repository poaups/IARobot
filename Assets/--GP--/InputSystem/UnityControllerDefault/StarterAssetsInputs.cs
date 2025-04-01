using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class StarterAssetsInputs : MonoBehaviour
{
    public Paper PaperScript;

    [Header("Reference")]
    [SerializeField] private GameObject canvaPause;


    [Header("Character Input Values")]

    public Vector2 Move;
    public Vector2 Look;

    public bool Jump;
    public bool Sprint;
    public bool Interaction;
    public bool LeftMouse;
    public bool RightMouse;

    [Header("Mouse Cursor Settings")]
    public bool CursorLocked = true;
    public bool CursorInputForLook = true;

    //Each Action
    private InputAction interactionAction;
    private InputAction displayUi;
    private InputAction sprintAction;
    private InputAction Escape;
    private InputAction jumpAction;
    private InputAction LeftAction;
    private InputAction RightAction;
    private KabotMovement kabotMovement;
    private PlayerMovement controller;
    private Interaction interaction;


#if ENABLE_INPUT_SYSTEM
    private void Awake()
    {
        controller = GetComponent<PlayerMovement>();
        interaction = Gamemanager.instance.InteractionPlayer;
        kabotMovement = Gamemanager.instance.KabotMovementScript;
        var playerInput = GetComponent<PlayerInput>();

        sprintAction = playerInput.actions["Sprint"];
        interactionAction = playerInput.actions["Interaction"];
        jumpAction = playerInput.actions["Jump"];
        LeftAction = playerInput.actions["LeftMouse"];
        RightAction = playerInput.actions["RightMouse"];
        displayUi = playerInput.actions["DisplayUi"];
        Escape = playerInput.actions["ESC"];

        interactionAction.performed += OnInteractionPerformed;
        interactionAction.canceled += OnInteractionCanceled;

        sprintAction.performed += OnSprintPerformed;
        sprintAction.canceled += OnSprintCanceled;

        jumpAction.performed += OnJumpPerformed;
        jumpAction.canceled += OnJumpCanceled;

        LeftAction.performed += OnLeftMousePerformed;
        LeftAction.canceled += OnLeftMouseCanceled;

        RightAction.performed += OnRightMousePerformed;
        RightAction.canceled += OnRightMouseCanceled;

        displayUi.performed += OnDisplayUIPerformed;
        displayUi.canceled += OnDisplayUICanceled;

        Escape.performed += OnESCPerformed;
        Escape.canceled += OnESCCanceled;
    }
    private void OnInteractionPerformed(InputAction.CallbackContext context)
    {

       Interaction = true;

        #region Input Debug
       // print("E");
       // print("Qui est stocke ? " + controller.goStocked);
        #endregion

        if (controller.goStocked != null)
        {
            //controller.SetPick(true);
            controller.goStocked.Interact();
        }

        if(interaction.GoToThrow != null)
        {
            interaction.Throw();
        }

        //IsMemories start subtitles
        if (Gamemanager.instance.powerUpTxt.IsMemories)
        {
          //  print("E Subtitles");
            Gamemanager.instance.Memories.StartCoroutine(Gamemanager.instance.Memories.WaitBetweenChar());
            Gamemanager.instance.PlayerAnimation.SetAnimMemories(true);
            Gamemanager.instance.powerUpTxt.SetMemories(false);
            //Gamemanager.instance.PlayerMovementScript.goStocked = null;
        }

        if(Gamemanager.instance.InteractionPlayer.GetPliers())
        {
            Gamemanager.instance.InteractionPlayer.UsePliers();
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
           // print("Pas de scrit paper");
        }
    }
    private void OnDisplayUICanceled(InputAction.CallbackContext context)
    {
        //F relased
    }

    private void OnESCPerformed(InputAction.CallbackContext context)
    {
        if (canvaPause != null)
        {
            canvaPause.SetActive(!canvaPause.activeSelf);
            Gamemanager.instance.SetCanMove(!canvaPause.activeSelf);

            Gamemanager.instance.SetCursor(canvaPause.activeSelf);
            Gamemanager.instance.SetPause(canvaPause.activeSelf);
        }
        else
        {
            print("Pas d'objet canvaPause");
        }
    }

    private void OnESCCanceled(InputAction.CallbackContext context)
    {
       //ESC relased
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
        if(Gamemanager.instance.InteractionPlayer.CanObey)
        {
            kabotMovement.Obey();
        }

    }
    private void OnLeftMouseCanceled(InputAction.CallbackContext context)
    {
        LeftMouse = false;
      
    }

    private void OnRightMousePerformed(InputAction.CallbackContext context)
    {
        print("OnRightMousePerformed");
        RightMouse = true;
        kabotMovement.ComeBack();
    }
    private void OnRightMouseCanceled(InputAction.CallbackContext context)
    {
        RightMouse = false;
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
        //SetCursorState(CursorLocked);
    }
    private void SetCursorState(bool newState)
    {
        //Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
