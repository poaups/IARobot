using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    InputManager inputManager;
    [SerializeField] private GameObject _photoUi;
    [SerializeField] private float zoomSpeed;  // Vitesse de zoom
    private float _originalZoomSpeed;  // Vitesse de zoom
    [SerializeField] private float zoomOutSpeedMultiplier;
    [SerializeField] private Camera cameraToZoom;
    [SerializeField] private float minFOV = 30f;
    [SerializeField] private float _originalFOV = 60f;
    [SerializeField] private float FOVForSpawPhoto;
    [SerializeField] private Image _flash;
    [SerializeField] private float flashSpeed = 1f; // La vitesse de la transition de l'alpha

    private bool isFlashing = false;

    private bool isZooming = false;
    private float targetFOV;



    void Start()
    {
        _originalZoomSpeed = zoomSpeed;
        inputManager = GetComponent<InputManager>();
        targetFOV = cameraToZoom.fieldOfView;
    }

    //L'update fonctionne tout le temps avec le ZoomOut et ca devrait pas
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFlashing)
        {
            StartCoroutine(FlashEffectCoroutine());
        }

        if (inputManager.rightClickHeld)
        {
            Zooming();
        }
        else
        {
            ZoomOut();
        }   


    }

    void Zooming()
    {
        isZooming = true;
        zoomSpeed = _originalZoomSpeed;

        cameraToZoom.fieldOfView = Mathf.MoveTowards(cameraToZoom.fieldOfView, minFOV, zoomSpeed * Time.deltaTime);

        if (cameraToZoom.fieldOfView < FOVForSpawPhoto)
        {
            _photoUi.SetActive(true);
        }
    }

    void ZoomOut()
    {
        if (isZooming)
        {
            zoomSpeed = zoomOutSpeedMultiplier;
            _photoUi.SetActive(false);
            cameraToZoom.fieldOfView = Mathf.MoveTowards(cameraToZoom.fieldOfView, _originalFOV, zoomSpeed * Time.deltaTime);
        }
    }

    private IEnumerator FlashEffectCoroutine()
    {
        isFlashing = true;
        float time = 0f;
        while (_flash.color.a < 1f)
        {

            time += Time.deltaTime * flashSpeed;
            float alphaValue = Mathf.Lerp(0f, 1f, time);
            _flash.color = new Color(_flash.color.r, _flash.color.g, _flash.color.b, alphaValue);
            yield return null;
        }

        time = 0f;
        while (_flash.color.a > 0f)
        {
            time += Time.deltaTime * flashSpeed;
            float alphaValue = Mathf.Lerp(1f, 0f, time);
            _flash.color = new Color(_flash.color.r, _flash.color.g, _flash.color.b, alphaValue);
            yield return null;
        }

        isFlashing = false;
    }
}

