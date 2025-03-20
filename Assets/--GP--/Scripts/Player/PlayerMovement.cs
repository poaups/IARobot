using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Interactable goStocked = null;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float snowSpeed;
    [SerializeField] private float multiplySpeedRunning ;
    [SerializeField] private float rotationSpeed;

    [Range(0f, -5f)]
    [SerializeField] private float attractionForce; // Staying in floor

    [Header("Camera Settings")]
    [SerializeField] private Transform _cameraTransform;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float gravity;

    private CharacterController controller;
    private StarterAssetsInputs input;
    private Animator animator;
    private TakeObject takeableObject;

    private Vector3 velocity;
    private bool isGrounded;
    private bool isPick;
    private bool isPickDown;
    private bool isUpdate;
    private bool snowingMovement;
    private bool isFalling;

    private void Awake()
    {
        snowingMovement = false;
        animator = GetComponent<Animator>();
        input = GetComponentInParent<StarterAssetsInputs>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        #region Input test Snow Movement
        if (Input.GetKeyUp(KeyCode.O))
        {
            SetSnowMovement(true);
            SetMoveSpeed(snowSpeed);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            SetSnowMovement(false);
            SetMoveSpeed(moveSpeed);
        }
        #endregion

        if (Gamemanager.instance.CanMove)
        {
            //print("CanMove");
            CheckGround();
            HandleMovement();
        }
        else
        {
            velocity.x = 0;
            velocity.y = 0;
        }

        HandleAnimations();
    }

    public void SetSnowMovement(bool newType)
    {
        print("SetSnowMovement");
        snowingMovement = newType;
    }

    public void SetMoveSpeed(float newValueSpeed)
    {
        moveSpeed = newValueSpeed;
    }

    public void SetAnimationPick(bool ground)
    {
        print("SetAnimationPick");
       isPick = ground;
    }
    public void SetAnimationUpdate(bool update)
    {
        isUpdate = update;
    }
    public void SetAnimationPickDown(bool ground)
    {
        isPickDown = ground;
    }
    public void SetAnimationFalling(bool falling)
    {
        isFalling = falling;
    }
    private void HandleAnimations()
    {
        float speed = new Vector2(velocity.x, velocity.z).magnitude;

        animator.SetBool("Sprint", input.Sprint);
        animator.SetBool("SnowSprint", input.Sprint);

        animator.SetFloat("Speed", speed);
        animator.SetBool("Pick", isPick);
        animator.SetBool("PickDown", isPickDown);
        animator.SetBool("SnowIdle", snowingMovement);
        animator.SetBool("Update", isUpdate);
        animator.SetBool("Fall", isFalling);
    }
    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        takeableObject = other.GetComponent<TakeObject>();

        if(interactable != null)
        {
            goStocked = interactable;
            //print(goStocked.gameObject);
        }

        if (takeableObject != null)
        {
            takeableObject.DisplayEffect();
        }

        //print(other.gameObject + "Entree");
    }

    private void OnTriggerExit(Collider other)
    {
        takeableObject = other.GetComponent<TakeObject>();

        if (goStocked != null && other.GetComponent<Interactable>() == goStocked)
        {
            goStocked = null;
        }

        if (takeableObject != null)
        {
            takeableObject.UnDisplayEffect();
        }

        //print(other.gameObject + "Sortie");
    }

    public void SetTeleportation(Transform desiredPos)
    {
        print("SetTeleportation");

        controller.enabled = false; // Désactiver le CharacterController
        transform.position = desiredPos.position;
        controller.enabled = true; // Réactiver le CharacterController
    }
    private void CheckGround()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = attractionForce;
        }
    }
    private void HandleMovement()
    {
     //   print(input.Move);
        float inputX = input.Move.x;
        float inputZ = input.Move.y;

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * inputZ + right * inputX).normalized;
        Vector3 movement = moveDirection * moveSpeed * (input.Sprint ? multiplySpeedRunning : 1f);

        //Movement
        controller.Move(movement * Time.deltaTime);

        //Then gravity
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        velocity.x = movement.x;
        velocity.z = movement.z;
        
        //Rotation player
        if (moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
