using TMPro;
using UnityEngine;
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [HideInInspector] public int Scraps;

    [Header("Scraps")]
    [SerializeField] private TextMeshProUGUI textScraps;

    private void Awake()
    {
        instance = this;
        Scraps = 0;
        textScraps.text = "Scraps : " + Scraps.ToString();
    }

    public void AddScrap(int _newScarp)
    {
        Scraps += _newScarp;
        textScraps.text = "Scraps : " + Scraps.ToString();
    }

    public void RemoveScrap(int _newScrap)
    {
        Scraps -= _newScrap;
        textScraps.text = "Scraps : " + Scraps.ToString();
    }
}
