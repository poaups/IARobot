using StarterAssets;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float multiplySpeedRunning;
    [SerializeField] private float rotationSpeed;

    [Header("Camera Settings")]
    [SerializeField] private Transform _cameraTransform;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;

    [Header("Slide Settings")]
    [SerializeField] private bool enableSliding = true; // Active/désactive la glisse
    [SerializeField] private float slopeLimit = 45f;
    [SerializeField] private float slideSpeed = 8f;
    [SerializeField] private float dragrb;

    private float savedrag;
    private Rigidbody _rb;
    private StarterAssetsInputs input;
    private float currentRunSpeed;
    private bool isGrounded;
    private Vector3 hitPointNormal;

    private void Awake()
    {
        savedrag = dragrb;
        currentRunSpeed = multiplySpeedRunning;
        input = GetComponentInParent<StarterAssetsInputs>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!IsRunning()) multiplySpeedRunning = 1;
        else multiplySpeedRunning = currentRunSpeed;
        /*
        if (IsSliding())
        {
            // Si glisse, désactiver les mouvements horizontaux
            input.move = Vector2.zero;

            // Appliquer un mouvement dans la direction de la pente
            Vector3 slideDirection = new Vector3(hitPointNormal.x, -hitPointNormal.y, hitPointNormal.z).normalized;
            _rb.velocity += slideDirection * slideSpeed * Time.deltaTime;
        }
        else*/
        {
            /*if (input.move == Vector2.zero)
                _rb.velocity = new Vector2(0, _rb.velocity.y);
            else*/
            HandleMovement();
        }

        IsGrounded();
        InputGroundCheck();

        print("x : "+ _rb.velocity.x + " | y : "    + _rb.velocity.y);
    }

    private bool IsSliding()
    {
        print(isGrounded + "isgrounded");
        if (!enableSliding || !isGrounded) return false;

        print("ici");
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance))
        {
            hitPointNormal = hit.normal;
            float slopeAngle = Vector3.Angle(hitPointNormal, Vector3.up);
            return slopeAngle > slopeLimit;
        }

        return false;
    }

    private bool IsRunning()
    {
        return input.sprint;
    }

    public bool GetGround()
    {
        return isGrounded;
    }

    private void IsGrounded()
    {
        float rayLength = groundCheckDistance;
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down;

        if (Physics.Raycast(origin, direction, rayLength))
        {
            isGrounded = true;
            Debug.DrawRay(origin, direction * rayLength, Color.green);
        }
        else
        {
            isGrounded = false;
            Debug.DrawRay(origin, direction * rayLength, Color.red);
        }
    }

    private void InputGroundCheck()
    {
        if (input.jump && GetGround())
        {
            input.jump = false;
            Jump();
        }
        else
        {
            input.JumpInput(false);
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
    }

    private void HandleMovement()
    {
        if (input.move == Vector2.zero)
        { _rb.velocity = new Vector2(0, _rb.velocity.y);/* _rb.drag = dragrb;*/ return; }

        dragrb = savedrag;
        float inputX = input.move.x;
        float inputZ = input.move.y;

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * inputZ + right * inputX).normalized;
        Vector3 movement = (moveDirection * _moveSpeed) * multiplySpeedRunning;
        _rb.velocity = new Vector3(movement.x, _rb.velocity.y, movement.z);

        if (moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
