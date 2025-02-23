
using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    [Header("Réglages de la caméra")]
    [SerializeField] private float _sensitivity = 100f;  // Sensibilité de la souris
    [SerializeField] private Transform _target;         // Le joueur à suivre
    [SerializeField] private Vector3 _offset;           // Décalage de la caméra par rapport au joueur
    [SerializeField] private float _distance = 5f;      // Distance de la caméra par rapport au joueur
    [SerializeField] private Transform _rotationSide;
    [SerializeField] private Transform _rotationUp;

    [Header("Rotation Limit")]
    [SerializeField, Range(-90, 0)] private float _rotationMaxUp;
    [SerializeField, Range(90, 0)] private float _rotationMaxDown;

    public StarterAssetsInputs inputCamera;
    private float _cameraRotationX;
    private StarterAssetsInputs _cameraRotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if(Gamemanager.instance.CanMove)
        {
            UpdateCameraRotation();
        }
    }
    private void UpdateCameraRotation()
    {
        if (inputCamera.Look.sqrMagnitude > 0.001)
        {
            // Right/left Camera
            _rotationSide.Rotate(Vector3.up, inputCamera.Look.x * _sensitivity);

            // Up/down Camera
            float mouseY = inputCamera.Look.y * _sensitivity;

            _cameraRotationX += mouseY;
            _cameraRotationX = Mathf.Clamp(_cameraRotationX, _rotationMaxUp, _rotationMaxDown);

            _rotationUp.localEulerAngles = new Vector3(_cameraRotationX, _rotationUp.localEulerAngles.y, 0f);

        }
    }
}
