using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanVision : MonoBehaviour
{
    [SerializeField] private Image _visionUI;
    private List<GameObject> _foots = new List<GameObject>();
    private bool _isActivated;
    private float _timeFade;

    void Awake()
    {
        //_timeFade = Gamemanager.instance.FadeTime;
        _visionUI.color = new Color(_visionUI.color.r, _visionUI.color.g, _visionUI.color.b, 0);
        _isActivated = false;
        AddFootInList();
    }
    void AddFootInList()
    {
        foreach (Transform child in this.transform)
        {
            _foots.Add(child.gameObject);
        }
        DisableFoot();
    }

    void DisableFoot()
    {
        foreach(GameObject foot in _foots)
        {
            foot.SetActive(false);
        }
        _isActivated = false;
    }

    public void AbleFoot()
    {
        if(_isActivated == false)
        {
            _isActivated = true;
            print("Coroutine");
            StartCoroutine(WaitBeforeAble());
            StartCoroutine(Gamemanager.instance.FadeIn());
        }
        else
        {
            return;
        }
       
    }
    IEnumerator WaitBeforeDisable()
    {
        yield return new WaitForSeconds(Gamemanager.instance.TimeBeforeDisableFoot);
        StartCoroutine(WaitBeforeDisableEach());
        //StartCoroutine(Gamemanager.instance.FadeOut());
    }

    IEnumerator WaitBeforeDisableEach()
    {
        foreach (GameObject foot in _foots)
        {
            foot.SetActive(false);
            yield return new WaitForSeconds(Gamemanager.instance.TimeBeforeAbleEachFoot);
        }
        _isActivated = false;
    }

    IEnumerator WaitBeforeAble()
    {
        print("WaitBeforeAble");
        foreach (GameObject foot in _foots)
        {
            foot.SetActive(true);
            yield return new WaitForSeconds(Gamemanager.instance.TimeBeforeAbleEachFoot);
        }
        StartCoroutine(WaitBeforeDisable());
    }
}
