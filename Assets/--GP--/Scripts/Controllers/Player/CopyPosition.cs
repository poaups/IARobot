using UnityEngine;

[ExecuteInEditMode]

public class CopyPosition : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _cameraHigh;

    void Update()
    {
        transform.position = new Vector3(_transform.position.x, _transform.position.y + _cameraHigh, _transform.position.z);
    }
}