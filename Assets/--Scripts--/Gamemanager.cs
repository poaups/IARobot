using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [HideInInspector] public int Scraps;
    /*[SerializeField] */public List<PlayerManager> _manager;
    [SerializeField] private CameraManager _cameraManagerScripts;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _dog;

    [Header("Who move at begining")]
    public bool CanMovePlayer;
    public bool CanMoveDog;

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
}
