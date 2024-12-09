using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    public Transform cameraPivot;
    public Transform targetTransform;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;
    public float lookAngle;
    public float pivotAngle;

    public float minimumPivotAngle = -35;
    public float maximumPivotAngle = 35;
    private void Awake()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
    }
    public void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position,
            targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }

    public void RotateCamera()
    {
        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }
}

//public class CameraManager : MonoBehaviour
//{
//    InputManager inputManager;
//    public Transform targetTransform; //object camera will follow
//    public Transform cameraPivot; //object the camera uses to pivot
//    public Transform cameraTransform; //transform of the actual camera object in the scene
//    public LayerMask collisionLayers; //Layer we want our camera to collide with
//    private float defaultPosition;
//    private Vector3 cameraFollowerVelocity = Vector3.zero;
//    private Vector3 cameraVectorPosition;

//    public float cameraCollisionOffSet = 0.2f; //how much the camera will jump off of objects its colliding with
//    public float minimumColisionOffSet = 0.2f;
//    public float cameraCollisionRadius = 2;
//    public float cameraFollowSpeed = 0.2f;
//    public float cameraLookSpeed = 2;
//    public float cameraPivotSpeed = 2;

//    public float lookAngle; // Camera looking up and down
//    public float pivotAngle; // Camera looking left and right

//    public float minimumPivotAngle = -35;
//    public float maximumPivotAngle = 35;

//    private void Awake()
//    {
//       inputManager = FindObjectOfType<InputManager>();
//       targetTransform = FindObjectOfType<PlayerManager>().transform;
//       cameraTransform = Camera.main.transform;
//       defaultPosition = cameraTransform.localPosition.z;
//    }

//    public void HandleAllCameraMovement()
//    {
//        FollowTarget();
//        RotateCamera();
//        HandleCameraCollisions();
//    }
//    private void FollowTarget()
//    {
//        Vector3 targetPosition = Vector3.SmoothDamp
//            (transform.position, targetTransform.position, ref cameraFollowerVelocity, cameraFollowSpeed);
//        transform.position = targetPosition;
//    }

//    private void RotateCamera()
//    {
//        Vector3 rotation;
//        Quaternion targetRotation;
//        //Probablement mettre des inputs joystcik ici
//        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
//        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
//        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

//        rotation = Vector3.zero;
//        rotation.y = lookAngle;
//        targetRotation = Quaternion.Euler(rotation);
//        transform.rotation = targetRotation;

//        rotation = Vector3.zero;
//        rotation.x = pivotAngle;
//        targetRotation = Quaternion.Euler(rotation);
//        cameraPivot.localRotation = targetRotation;
//    }

//    private void HandleCameraCollisions()
//    {
//        float targetPosition = defaultPosition;
//        RaycastHit hit;
//        Vector3 direction = cameraTransform.position - cameraPivot.position;
//        direction.Normalize();

//        if(Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers))
//        {
//            float distance = Vector3.Distance(cameraPivot.position, hit.point);
//            targetPosition  =- (distance - cameraCollisionOffSet);
//        }

//        if(Mathf.Abs(targetPosition) < minimumColisionOffSet)
//        {
//            targetPosition = targetPosition - minimumColisionOffSet;
//        }

//        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
//        cameraTransform.localPosition = cameraVectorPosition;

//    }
//}
