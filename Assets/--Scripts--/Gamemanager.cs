using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [HideInInspector] public int Scraps;
    /*[SerializeField] */public List<PlayerManager> _manager;
    [SerializeField] private CameraManager _cameraManagerScripts;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _dog;

    [Header("Reference Scrips")]
    public DogInteraction _dogInteractionGM;

    [Header("Who move at begining")]
    public bool CanMovePlayer;
    public bool CanMoveDog;

    [Space(10)]

    [Header("Foots")]
    public float TimeBeforeDisableFoot;
    public float TimeBeforeAbleEachFoot;

    [Header("Fade")]
    public bool IsFading = false;
    public float TimeBeforebetweenFade;
    public float FadeTime;
    [SerializeField] private Image _visionUI;

    [Header("Scraps")]
    [SerializeField] private TextMeshProUGUI _textScraps;

    private void Awake()
    {
        instance = this;
        Scraps = 0;
        _textScraps.text = "Scraps : " + Scraps.ToString();

        if(CanMovePlayer == true)
        {
            _manager[0].enabled = true;
            _manager[1].enabled = false;
            _cameraManagerScripts.ChangeTarget(_player);
        }
        else
        {
            _manager[1].enabled = true;
            _manager[0].enabled = false;
            _cameraManagerScripts.ChangeTarget(_dog);
        }
    }

    public void AddScrap()
    {
        Scraps++;
        _textScraps.text = "Scraps : " + Scraps.ToString();
    }

    public void AbleDisableControllers()
    {
        _manager[0].enabled = !_manager[0].enabled;
        _manager[1].enabled = !_manager[1].enabled;
    }

    public bool GetManager()
    {
        return _manager[0].enabled;
    }


    public IEnumerator FadeIn()
    {
        IsFading = true;
        float elapsedTime = 0f;
        Color initialColor = _visionUI.color;

        while (elapsedTime < Gamemanager.instance.FadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(elapsedTime / Gamemanager.instance.FadeTime);
            _visionUI.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);

            yield return null;
        }
        _visionUI.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);
        StartCoroutine(WaitBeforeFadeOut());
    }
    IEnumerator WaitBeforeFadeOut()
    {
        yield return new WaitForSeconds(TimeBeforebetweenFade);
        StopCoroutine(FadeIn());
        StartCoroutine(FadeOut());

    }
    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color initialColor = _visionUI.color;

        while (elapsedTime < Gamemanager.instance.FadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(1f - (elapsedTime / Gamemanager.instance.FadeTime));
            _visionUI.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);

            yield return null;
        }
        _visionUI.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);
        IsFading = false;
    }
}
