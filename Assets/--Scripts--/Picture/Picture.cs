using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picture : MonoBehaviour
{
    [Header("Zoom")]
    [HideInInspector] public bool CanZoomAndFlash;

    [SerializeField] private float zoomSpeed; 
    [SerializeField] private float zoomOutSpeedMultiplier;
    [SerializeField] private Camera cameraToZoom;
    [SerializeField] private float minFOV = 30f;
    [SerializeField] private float _originalFOV = 60f;
    [SerializeField] private float FOVForSpawPhoto;

    private float _originalZoomSpeed;
    private bool isZooming = false;
    private float targetFOV;

    [Header("Flash")]
    [SerializeField] private Image _flash;
    [SerializeField] private float flashSpeed = 1f;

    private bool isFlashing = false;

    [Header("Reference")]
    [SerializeField] private Image _photo;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject _photoUi;

    private Texture2D screenCapture;

    void Start()
    {
        CanZoomAndFlash = true;
        _originalZoomSpeed = zoomSpeed;
        targetFOV = cameraToZoom.fieldOfView;

        _photo.enabled = false;
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

    }

    void Update()
    {
        print(_photoUi.activeSelf + " _photoUi.activeSelf " + !isFlashing + " !isFlashing false " + CanZoomAndFlash + " CanZoomAndFlash");
        if (_photoUi.activeSelf && Input.GetMouseButtonDown(0) && !isFlashing && CanZoomAndFlash)
        {
            StartCoroutine(CapturePhoto()); //Screen
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
  

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        _photo.sprite = photoSprite;
        StartCoroutine(WaitBetweenShow());
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

    IEnumerator WaitBetweenShow()
    {
        yield return new WaitForSeconds(2f);
        _photo.enabled = true;
    }

    private IEnumerator FlashEffectCoroutine()
    {
        isFlashing = true;

        // Transition vers alpha = 1
        float time = 0f;
        while (_flash.color.a < 1f)
        {
            time += Time.deltaTime * flashSpeed;
            float alphaValue = Mathf.Lerp(0f, 1f, time);
            _flash.color = new Color(_flash.color.r, _flash.color.g, _flash.color.b, alphaValue);
            yield return null;
        }

        // Remettre le temps à zéro avant la deuxième transition
        time = 0f;

        // Transition vers alpha = 0
        while (_flash.color.a > 0f)
        {
            time += Time.deltaTime * flashSpeed;
            float alphaValue = Mathf.Lerp(1f, 0f, time);

            var tempColor = _flash.color;
            tempColor.a = alphaValue;
            _flash.color = tempColor;

            yield return null;
        }
    

        isFlashing = false;
    }

    IEnumerator CapturePhoto()
    {
        yield return new WaitForEndOfFrame();
        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }
}
