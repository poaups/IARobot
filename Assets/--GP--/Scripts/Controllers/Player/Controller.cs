using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float multiplySpeedRunning;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private TextMeshProUGUI txtSpeedhorizontal;
    [SerializeField] private TextMeshProUGUI txtSpeedVertical;

    [Header("Camera Settings")]
    [SerializeField] private Transform _cameraTransform;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float gravity;

    [Header("Slide Settings")]
    [SerializeField] private bool enableSliding = true;
    [SerializeField] private float slopeLimit = 45f;
    [SerializeField] private float slideSpeed = 8f;
    [SerializeField] private float dragrb;


    private float savedrag;
    private Rigidbody _rb;
    private StarterAssetsInputs input;
    private float currentRunSpeed;
    private float currentVelocityX;
    private float currentVelocityY;
    private bool isGrounded;
    private Vector3 hitPointNormal;
    private Animator animator;

    private void Awake()
    {
        savedrag = dragrb;
        currentRunSpeed = multiplySpeedRunning;
        animator = GetComponent<Animator>();
        input = GetComponentInParent<StarterAssetsInputs>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!IsRunning()) multiplySpeedRunning = 1;
        else multiplySpeedRunning = currentRunSpeed;

       
        UpdateVelocity();
        SetAnimation();
        ShowVelocityTxt();
        HandleMovement();
        IsGrounded();
        InputGroundCheck();
        if(!GetGround())
        {
            _rb.AddForce(Vector3.down * 2 * 2 * Time.deltaTime, ForceMode.Force);
        }
    }
    void SetAnimation()
    {
        animator.SetBool("Sprint", input.GetSprint());
        animator.SetFloat("Speed", currentVelocityX);
    }
    void UpdateVelocity()
    {
       // print("currentVelocityX" + currentVelocityX);
        currentVelocityX = Mathf.Abs(Mathf.Round((_rb.velocity.x + _rb.velocity.z) * 10) / 10f);
        currentVelocityY = Mathf.Abs(Mathf.Round(_rb.velocity.y * 10) / 10f);
    }
    void ShowVelocityTxt()
    {
        txtSpeedhorizontal.text = "Hspeed" + _rb.velocity.x.ToString("F1") + " " + _rb.velocity.z.ToString("F1");
        txtSpeedVertical.text = "Vspeed " + _rb.velocity.y.ToString("F1");
    }
    private bool IsSliding()
    {
        //print(isGrounded + "isgrounded");
        if (!enableSliding || !isGrounded) return false;

        //print("ici");
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
        {
            _rb.velocity =  new Vector2(0,_rb.velocity.y);

           //return;
        }

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

        // Garder la vitesse Y intacte, ne pas la remplacer, elle doit être influencée par la gravité
        _rb.velocity = new Vector3(movement.x, _rb.velocity.y, movement.z);

        if (moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Appliquer la gravité manuellement si nécessaire
        if (!isGrounded)
        {
            _rb.AddForce(Vector3.down * gravity * Time.deltaTime, ForceMode.Force);
        }
    }
}
