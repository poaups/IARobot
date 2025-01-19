using UnityEngine;

public class TPSController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;

    [Header("Camera Settings")]
    [SerializeField] private Transform _cameraTransform;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        // Verrouiller le curseur de la souris
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Obtenir les entrées clavier
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

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
        Vector3 movement = moveDirection * _moveSpeed;
        _rb.velocity = new Vector3(movement.x, _rb.velocity.y, movement.z);

        // Faire tourner le joueur vers la direction de déplacement
        //On fait LookRotation en mettant les inputs du clavier a l'interieur

        if(moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection,Vector3.up);
            transform.rotation =  Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
