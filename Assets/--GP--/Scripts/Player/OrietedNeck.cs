using UnityEngine;

public class OrientedNeck : MonoBehaviour
{
    [SerializeField] private GameObject orientedObject;
    [SerializeField] private float maxRotationX = 30f;
    [SerializeField] private float minRotationX = -30f;

    private float rotationY;
    private float rotationX;

    void LateUpdate()
    {
        if (orientedObject == null) return; // Prevent errors if no object is assigned

        // Extract Y rotation from the oriented object
        rotationY = orientedObject.transform.eulerAngles.y;
        rotationX = orientedObject.transform.eulerAngles.x;

        // Clamp the rotation
        rotationY = Mathf.Clamp(rotationY, minRotationX, maxRotationX);

        // Apply rotation
        transform.rotation = Quaternion.Euler(0, rotationY, rotationX);
    }
}
