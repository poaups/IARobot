using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DogInteraction;

public class Deconstruct : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI _earnTxt;
    [SerializeField] private TextMeshProUGUI _GdTxt;
    [SerializeField] private Button _button;

    void Start()
    {
        _earnTxt.text = "Earn : " + _button.Cost;
    }

    public void UseDeconstruct()
    {
        Gamemanager.instance.AddScrap(_button.Cost);
        LowerAlphatxt();
    }

    public void LowerAlphatxt()
    {
        Color currentColor = _GdTxt.color;
        currentColor.a = Mathf.Clamp01(0.5f); // Incrémenter l'alpha (entre 0 et 1)
        _GdTxt.color = currentColor;
    }
}
