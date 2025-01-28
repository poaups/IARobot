using StarterAssets;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class TPSController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float multiplySpeedRunning;
    [SerializeField] private float rotationSpeed;

    [Header("Camera Settings")]
    [SerializeField] private Transform _cameraTransform;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;      // Force du saut
    [SerializeField] private float groundCheckDistance = 1.2f;  // Distance de vérification du sol
    [SerializeField] private LayerMask groundLayer;     // Layer du sol pour détection

    private Rigidbody _rb;
    private StarterAssetsInputs input;
    private float currentRunSpeed;
    private bool isGrounded;

    private void Awake()
    {
        currentRunSpeed = multiplySpeedRunning;

        input = GetComponentInParent<StarterAssetsInputs>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Gestion de la course (multiplication de la vitesse si on court)
        if (!IsRunning()) multiplySpeedRunning = 1;
        else { multiplySpeedRunning = currentRunSpeed; }

        // Arrêter les déplacements si aucun input n'est donné
        if (input.move == Vector2.zero)
            _rb.velocity = new Vector2(0, _rb.velocity.y);  // La vitesse verticale reste inchangée
        else
            HandleMovement();

        // Vérification du sol
        IsGrounded();

        // Saut (lorsque la touche de saut est pressée)
        if (input.jump && isGrounded)
        {
            print("Jump");
            Jump();
        }
        else
        {
            print("No jump");
        }
    }

    bool IsRunning()
    {
        return input.sprint;
    }

    public bool GetGround()
    {
        return isGrounded;
    }

    void Jump()
    {
        // Appliquer une force vers le haut pour effectuer le saut
        _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
        print("Jump applied!");
    }

    void IsGrounded()
    {
        // Raycast pour vérifier si on est au sol
        float rayLength = groundCheckDistance;
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down;

        if (Physics.Raycast(origin, direction, rayLength, groundLayer))
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

    void HandleMovement()
    {
        // Obtenir les entrées du clavier
        float inputX = input.move.x;
        float inputZ = input.move.y;

        // Calculer la direction de déplacement en fonction de l'orientation de la caméra
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        // Ignorer l'axe vertical de la caméra
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculer la direction du mouvement
        Vector3 moveDirection = (forward * inputZ + right * inputX).normalized;

        // Appliquer la vitesse de déplacement
        Vector3 movement = (moveDirection * _moveSpeed) * multiplySpeedRunning;
        _rb.velocity = new Vector3(movement.x, _rb.velocity.y, movement.z);  // Garder la vitesse verticale intacte

        // Faire tourner le personnage pour l'aligner avec la direction du mouvement
        if (moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
