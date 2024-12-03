using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public bool isSprinting;
    private bool _isGrounded; 

    [Header("Movement Speeds")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 3;
    public float sprintSpeed = 4.5f;
    public float rotationSpeed = 15;

    [Header("Jump Settings")]
    public float jumpHeight = 3;
    public float gravityIntensity = -15;
    public bool isJumping;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
        HandleJumping(); // Gestion du saut
    }

    private void HandleMovement()
    {
        if (isJumping)
            return;

        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (isSprinting)
        {
            moveDirection *= sprintSpeed;
        }
        else
        {
            moveDirection *= inputManager.moveAmount >= 0.5f ? runningSpeed : walkingSpeed;
        }

        Vector3 movementVelocity = moveDirection;
        movementVelocity.y = playerRigidbody.velocity.y; // Conserver la vitesse verticale
        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        if (isJumping)
            return;

        Vector3 targetDirection = cameraObject.forward * inputManager.verticalInput +
                                  cameraObject.right * inputManager.horizontalInput;

        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    public void HandleJumping()
    {
        if (inputManager.jump_Input && IsGrounded()) // Assurez-vous que le joueur est au sol.
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            inputManager.jump_Input = false; // Réinitialisation pour éviter plusieurs sauts d'affilée.
        }
    }

    bool IsGrounded()
    {
        float rayLength = 1.0f; // Ajuste cette valeur selon la hauteur du joueur.
        Vector3 origin = transform.position + Vector3.down * 0.1f; // Position légèrement abaissée.
        Vector3 direction = Vector3.down;

        RaycastHit hit;
        bool isGrounded = Physics.Raycast(origin, direction, out hit, rayLength);

        Debug.DrawRay(origin, direction * rayLength, Color.red);

        return isGrounded;
    }
}