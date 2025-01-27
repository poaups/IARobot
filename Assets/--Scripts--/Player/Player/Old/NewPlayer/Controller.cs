using StarterAssets;
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

    private Rigidbody _rb;
    private PlayerInput playerInput;
    private StarterAssetsInputs input;
    private float currentRunSpeed;

    private void Awake()
    {
        currentRunSpeed = multiplySpeedRunning;

        playerInput = GetComponent<PlayerInput>();
        input = GetComponent<StarterAssetsInputs>();
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!IsRunning()) multiplySpeedRunning = 1;
        else { multiplySpeedRunning = currentRunSpeed; }

        if (input.move == Vector2.zero) _rb.velocity = Vector2.zero;
        else { HandleMovement(); }
       
    }

    bool IsRunning()
    {
        return input.sprint;
    }
    void HandleMovement()
    {
        // Obtenir les entrées clavier
        float inputX = input.move.x;
        float inputZ = input.move.y;

        // Calculer le vecteur de déplacement en fonction de l'orientation de la caméra
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        // On ignore l'axe vertical de la caméra
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculer la direction de mouvement globale
        Vector3 moveDirection = (forward * inputZ + right * inputX).normalized;

        // Appliquer la vitesse de déplacement
        Vector3 movement = (moveDirection * _moveSpeed) * multiplySpeedRunning;
        _rb.velocity = new Vector3(movement.x, _rb.velocity.y, movement.z);

        // Faire tourner le joueur vers la direction de déplacement
        //On fait LookRotation en mettant les inputs du clavier a l'interieur

        if(moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection,Vector3.up);
            transform.rotation =  Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
