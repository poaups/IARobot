using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraController : MonoBehaviour
{
    [Header("Réglages de la sensibilité")]
    [SerializeField] private float _sensibility;

    private float _rotationX = 0;
    private float _rotationY = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X") * _sensibility * Time.deltaTime;
        float _mouseY = Input.GetAxis("Mouse Y") * _sensibility * Time.deltaTime;

        // Calculer la rotation verticale (haut/bas) en limitant les angles
        _rotationY -= _mouseY;
        _rotationY = Mathf.Clamp(_rotationY, -90, 90);  // Apply clamp to _rotationY

        // Calculer la rotation horizontale (gauche/droite)
        _rotationX += _mouseX;

        // Appliquer la rotation à la caméra
        transform.localRotation = Quaternion.Euler(_rotationY, _rotationX, 0);
    }
}
