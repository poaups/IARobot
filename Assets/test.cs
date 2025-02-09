using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
   
    public bool CanMove { get; private set; } = true;
    private bool IsSprinting => canSprint && Input.GetKey(sprintKey);
    private bool ShouldJump => Input.GetKeyDown(jumpKey) && characterController.isGrounded;
    private bool ShouldCrouch => Input.GetKeyDown(crouchKey) && !duringCrouchAnimation && characterController.isGrounded;


    [Header("Functional Options")]
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canCrouch = true;
    [SerializeField] private bool canUseHeadBob = true;
    [SerializeField] private bool WillSlideOnSlopes = true;
    [SerializeField] private bool canZoom = true;
    [SerializeField] private bool canInteract = true;

    [Header("Controls")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode crouchKey = KeyCode.LeftControl;
    [SerializeField] private KeyCode zoomKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode interactKey = KeyCode.Mouse1;

    [Header("Movement Parameters")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintSpeed = 6.0f;
    [SerializeField] private float crouchSpeed = 1.5f;
    [SerializeField] private float slopeSpeed = 8f;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLooklimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLooklimit = 80.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float gravity = 30.0f;

    [Header("Crouch Parameters")]
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0, 0, 0);
    private bool isCrouching;
    private bool duringCrouchAnimation;

    [Header("HeadBob Parameters")]
    [SerializeField] private float walkBobSpeed = 13f;
    [SerializeField] private float walkBobAmount = 0.05f;
    [SerializeField] private float sprintBobSpeed = 18f;
    [SerializeField] private float sprintBobAmount = 0.11f;
    [SerializeField] private float crouchBobSpeed = 8f;
    [SerializeField] private float crouchBobAmount = 0.025f;
    private float defaultYpos = 0;
    private float timer;

    [Header("Zoom Parameters")]
    [SerializeField] private float timeToZoom = 0.3f;
    [SerializeField] private float zoomFOV = 30f;
    private float defaultFOV;
    private Coroutine zoomRoutine;

    //Parametres de slide
    private Vector3 hitPointNormal;

    private bool IsSliding
    {
        get
        {
            if (characterController.isGrounded && Physics.Raycast(transform.position, Vector3.down, out RaycastHit slopeHit, 2f))
            {
                hitPointNormal = slopeHit.normal;
                return Vector3.Angle(hitPointNormal, Vector3.up) > characterController.slopeLimit;
            }
            else
            {
                return false;
            }
        }
    }

    [Header("Interactions")]
    [SerializeField] private Vector3 interectionRayPoint = default;
    [SerializeField] private float interectionDistance = default;
    [SerializeField] private LayerMask interectionLayer = default;
    //private Interactable currentInterrectable;


    //private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;
    private float rotationY = 0;

    void Awake()
    {
       // playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
       // defaultYpos = playerCamera.transform.localPosition.y;
        //defaultFOV = playerCamera.fieldOfView;
        // Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        // // Récupère les coordonnées de la souris dans l'espace écran
        // Vector3 mousePositionScreen = Input.mousePosition;

        // // Convertit les coordonnées de l'écran en coordonnées dans le monde
        // Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        // // Affiche les coordonnées de la souris dans le monde
        // Debug.Log("Position de la souris dans le monde : " + mousePositionWorld);
        //print(defaultYpos + "defauktYpos");
        //print(Playertest.transform.position.x + "x via le player");
        //print(Playertest.transform.position.y + "y via le player");
        //print(Playertest.transform.position.z + "z via le player");
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Bouton4.GetComponent<Button_Wheel_4>().Hide = true;
        //}

        if (CanMove)
        {
            HandleMovementInput();
            HandleMouseLook();
            if (canJump)
                HandleJump();
            if (canCrouch)
                HandleCrouch();
            if (canUseHeadBob)
                //HandleHeadBob();
            //if (canZoom)
            //    HandleZoom();
            if (canInteract)
            {
                //HandleInterectionCheck();
                //HandleInterectionInput();
            }
            ApplyFinalMovements();
        }
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2((IsSprinting ? sprintSpeed : isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Vertical"), (IsSprinting ? sprintSpeed : isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleMouseLook()
    {
        //if (Wheel.activeSelf)
        //{
        //    return;
        //}
        //else
        //{
            //print("ActiveSelf");
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
            rotationX = Mathf.Clamp(rotationX, -upperLooklimit, lowerLooklimit);
            // rotationY -= Input.GetAxis("Mouse X") * lookSpeedY;
            // rotationY = Mathf.Clamp(rotationX, -upperLooklimit, lowerLooklimit);

            //playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
        //}


    }

    private void HandleJump()
    {
        if (ShouldJump)
            moveDirection.y = jumpForce;
    }

    private void HandleCrouch()
    {
        if (ShouldCrouch)
            StartCoroutine(CrouchStand());
    }

    //private void HandleHeadBob()
    //{
    //    if (!characterController.isGrounded) return;

    //    if (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
    //    {
    //        timer += Time.deltaTime * (isCrouching ? crouchBobSpeed : IsSprinting ? sprintBobSpeed : walkBobSpeed);
    //        //playerCamera.transform.localPosition = new Vector3(
    //           // playerCamera.transform.localPosition.x,
    //            defaultYpos + Mathf.Sin(timer) * (isCrouching ? crouchBobAmount : IsSprinting ? sprintBobAmount : walkBobAmount),
    //           // playerCamera.transform.localPosition.z);
    //    }
    //}

    //private void HandleZoom()
    //{
    //    if (Input.GetKeyDown(zoomKey))
    //    {
    //        if (zoomRoutine != null)
    //        {
    //            StopCoroutine(zoomRoutine);
    //            zoomRoutine = null;
    //        }

    //        zoomRoutine = StartCoroutine(ToggleZoom(true));
    //    }

    //    if (Input.GetKeyUp(zoomKey))
    //    {
    //        if (zoomRoutine != null)
    //        {
    //            StopCoroutine(zoomRoutine);
    //            zoomRoutine = null;
    //        }

    //        zoomRoutine = StartCoroutine(ToggleZoom(false));
    //    }
    //}

    //private void HandleInterectionCheck()
    //{
    //    if(Physics.Raycast(playerCamera.ViewportPointToRay(interectionRayPoint), out RaycastHit hit, interectionDistance))
    //    {
    //        if(hit.collider.gameObject.layer == 9 && (currentInterrectable == null || hit.collider.gameObject.GetInstanceID() != currentInterrectable.GetInstanceID()))
    //        {
    //            hit.collider.TryGetComponent(out currentInterrectable);

    //            if(currentInterrectable)
    //                currentInterrectable.OnFocus();
    //        }
    //    }
    //    else if (currentInterrectable)
    //    {
    //        currentInterrectable.OnLoseFocus();
    //        currentInterrectable = null;
    //    }
    //}

    //private void HandleInterectionInput()
    //{
    //    if(Input.GetKeyDown(interactKey) && currentInterrectable != null && Physics.Raycast(playerCamera.ViewportPointToRay(interectionRayPoint), out RaycastHit hit,interectionDistance,interectionLayer))
    //    {
    //        currentInterrectable.OnInteract();
    //    }
    //}

    private void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        if (WillSlideOnSlopes && IsSliding)
            moveDirection += new Vector3(hitPointNormal.x, -hitPointNormal.y, hitPointNormal.z) * slopeSpeed;

        characterController.Move(moveDirection * Time.deltaTime);

    }

    private IEnumerator CrouchStand()
    {
       // if (isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f))
            yield break;

        duringCrouchAnimation = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standingHeight : crouchHeight;
        float currentHeight = characterController.height;
        Vector3 targeCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = characterController.center;

        while (timeElapsed < timeToCrouch)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / timeToCrouch);
            characterController.center = Vector3.Lerp(currentCenter, targeCenter, timeElapsed / timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        characterController.height = targetHeight;
        characterController.center = targeCenter;

        isCrouching = !isCrouching;

        duringCrouchAnimation = false;
    }
    //private IEnumerator ToggleZoom(bool isEnter)
    //{
    //    float targetFOV = isEnter ? zoomFOV : defaultFOV;
    //  //  float startingFOV = playerCamera.fieldOfView;
    //    float timeElapsed = 0;

    //    while (timeElapsed < timeToZoom)
    //    {
    //       // playerCamera.fieldOfView = Mathf.Lerp(startingFOV, targetFOV, timeElapsed / timeToZoom);
    //        timeElapsed += Time.deltaTime;
    //        yield return null;
    //    }

    //    playerCamera.fieldOfView = targetFOV;
    //    zoomRoutine = null;
    //}
}