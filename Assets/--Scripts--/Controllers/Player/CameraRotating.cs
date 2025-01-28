using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TPSCameraController : MonoBehaviour
{
    [Header("Réglages de la caméra")]
    [SerializeField] private float _sensitivity = 100f;  // Sensibilité de la souris
    [SerializeField] private Transform _target;         // Le joueur à suivre
    [SerializeField] private Vector3 _offset;           // Décalage de la caméra par rapport au joueur
    [SerializeField] private float _distance = 5f;      // Distance de la caméra par rapport au joueur

    private float _rotationX = 0f;  // Rotation autour de l'axe horizontal
    private float _rotationY = 0f;  // Rotation autour de l'axe vertical
    private StarterAssetsInputs inputCamera;

    private void Awake()
    {
        inputCamera = GetComponentInParent<StarterAssetsInputs>();
    }
    void Start()
    {
        // Verrouiller le curseur de la souris
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        HandleCameraRotation();
        UpdateCameraPosition();
    }

    void HandleCameraRotation()
    {
        // Obtenir les déplacements de la souris
        float mouseX = inputCamera.look.x * _sensitivity * Time.deltaTime;
        float mouseY = inputCamera.look.y * _sensitivity * Time.deltaTime;

        // Ajuster les angles de rotation
        _rotationX += mouseX;
        _rotationY -= mouseY;
        _rotationY = Mathf.Clamp(_rotationY, -45f, 60f);  // Limiter l'angle de la caméra

        // Appliquer la rotation à la caméra
        Quaternion rotation = Quaternion.Euler(_rotationY, _rotationX, 0f);
        transform.rotation = rotation;
    }

    void UpdateCameraPosition()
    {
        // Calculer la position désirée de la caméra en fonction de la position du joueur
        //La soustraction permet de mettre la camera derriere le joueur et non devant lui 
        //Le Time.deltaTime empeche le fait que ce soit instantane

        //Vector3 desiredPosition = _target.position - transform.forward * _distance + _offset;
        //transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10f);

        Vector3 _desiredPosition = _target.position - transform.forward * _distance + _offset;
        transform.position = Vector3.Lerp(transform.position, _desiredPosition, Time.deltaTime * 10f);
    }
}
