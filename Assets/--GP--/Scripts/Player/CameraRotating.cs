using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    [Header("Réglages de la caméra")]
    [SerializeField] private float _sensitivity;  
    [SerializeField] private Transform _target; 
    [SerializeField] private Vector3 _offset; 
    [SerializeField] private float _distance = 5f; 
    [SerializeField] private Transform _rotationSide;
    [SerializeField] private Transform _rotationUp;
    [SerializeField] private LayerMask layersToIgnore;

    [Header("Rotation Limit")]
    [SerializeField, Range(-90, 0)] private float _rotationMaxUp;
    [SerializeField, Range(90, 0)] private float _rotationMaxDown;
    [SerializeField, Range(0, 1)] private float powerSensitivity;

    public StarterAssetsInputs inputCamera;
    private float _cameraRotationX;
    private StarterAssetsInputs _cameraRotationY;

    void LateUpdate()
    {
        if(Gamemanager.instance.CanMove)
        {
            UpdateCameraRotation();
        }
    }

    public void SetSensitivity(float newSensitivity)
    {
        _sensitivity = (newSensitivity * powerSensitivity);
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
    public Vector3 ForwardRay()
    {
        float rayLength = 100f;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origin, direction * rayLength, Color.red, 2f);

        int layerMask = ~layersToIgnore.value;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayLength, layerMask))
        {
            print(hit.collider.name);
            return hit.point;
        }
        return origin + direction * rayLength;
    }


}
