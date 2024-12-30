using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [HideInInspector] public int Scraps;
    [SerializeField] private TextMeshProUGUI _textScraps;

    private void Awake()
    {
        instance = this;
        Scraps = 0;
        _textScraps.text = "Scraps : " + Scraps.ToString();
    }

    public void AddScrap()
    {
        Scraps++;
        _textScraps.text = "Scraps : " + Scraps.ToString();
    }
}
