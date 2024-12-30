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
    [HideInInspector] public bool CanMove;
    [SerializeField] private TextMeshProUGUI _textScraps;

    private void Awake()
    {
        CanMove = true;
        instance = this;
        Scraps = 0;
        _textScraps.text = "Scraps : " + Scraps.ToString();
    }

    public void AddScrap()
    {
        Scraps++;
        _textScraps.text = "Scraps : " + Scraps.ToString();
    }

    public void AbleDisableControllers()
    {
        CanMove = !CanMove;
    }
}
