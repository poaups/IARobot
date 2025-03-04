using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Interactable goStocked = null;

    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;
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
    private RemoveItems removeItems;

    private Vector3 velocity;
    private bool isGrounded;
    private bool isPick;
    private bool isPickDown;
    private bool snowingMovement;

    private void Awake()
    {
        snowingMovement = false;
        animator = GetComponent<Animator>();
        input = GetComponentInParent<StarterAssetsInputs>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            snowingMovement = true;
            SetMoveSpeed(_moveSpeed/2);
        }

        if (Gamemanager.instance.CanMove)
        {
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

    public void SetMoveSpeed(float newValueSpeed)
    {
        _moveSpeed = newValueSpeed;
    }

    public void SetAnimationPick(bool ground)
    {
       isPick = ground;
    }

    public void SetAnimationPickDown(bool ground)
    {
        isPickDown = ground;
    }
    private void HandleAnimations()
    {
        float speed = new Vector2(velocity.x, velocity.z).magnitude;

        animator.SetBool("Sprint", input.Sprint);
        animator.SetFloat("Speed", speed);
        animator.SetBool("Pick", isPick);
        animator.SetBool("PickDown", isPickDown);
    }
    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        removeItems = other.GetComponent<RemoveItems>();

        if(interactable != null)
        {
            goStocked = interactable;
            //print(goStocked.gameObject);
        }

        if (removeItems != null)
        {
            removeItems.DisplayEffect();
            //print(goStocked.gameObject);
        }

        //print(other.gameObject + "Entree");
    }

    private void OnTriggerExit(Collider other)
    {
        removeItems = other.GetComponent<RemoveItems>();

        if (goStocked != null && other.GetComponent<Interactable>() == goStocked)
        {
            goStocked = null;
        }

        if (removeItems != null)
        {
            removeItems.UnDisplayEffect();
        }

        //print(other.gameObject + "Sortie");
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
        float inputX = input.Move.x;
        float inputZ = input.Move.y;

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * inputZ + right * inputX).normalized;
        Vector3 movement = moveDirection * _moveSpeed * (input.Sprint ? multiplySpeedRunning : 1f);

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
