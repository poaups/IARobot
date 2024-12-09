using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField] private float zoomSpeed = 10f; // Vitesse de zoom
    [SerializeField] private Camera cameraToZoom;  // Caméra ciblée
    [SerializeField] private float minFOV = 30f;   // Limite minimale du FOV
    [SerializeField] private float maxFOV = 60f;   // Limite maximale du FOV
    private bool isZooming;
    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        if (inputManager.rightClickHeld)
        {
            //Debug.Log("Clic droit maintenu");
            Zooming();
        }

    }

    void Zooming()
    {
        cameraToZoom.fieldOfView = Mathf.Clamp(cameraToZoom.fieldOfView - zoomSpeed * Time.deltaTime, minFOV, maxFOV);
    }
}
