using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    [Header("Camera Settings")]
    public Transform cameraFollowTarget;
    public float rotationSpeed = 10f;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleGravity();
        HandleRotation();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDirection = Quaternion.Euler(0f, cameraFollowTarget.eulerAngles.y, 0f) * direction;
            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

            characterController.Move(moveDirection * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void HandleGravity()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void HandleRotation()
    {
        Vector3 forward = cameraFollowTarget.forward;
        forward.y = 0f;

        if (forward.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
