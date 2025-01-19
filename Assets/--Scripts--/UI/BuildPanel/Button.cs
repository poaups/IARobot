using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DogInteraction;

public class Button : MonoBehaviour
{
    public int Cost;

    [SerializeField] private DogInteraction _dogInteraction;
    [SerializeField] private TextMeshProUGUI _costTxt;
    [SerializeField] private DogBehaviors selectedBehavior; // Enum exposée dans l'inspecteur
    [SerializeField] private TextMeshProUGUI _GdTxt;

    void Start()
    {
        _costTxt.text = "Cost : " + Cost;
    }

    public void CheckForCost()
    {
        if (Gamemanager.instance.Scraps >= Cost)
        {
            Debug.Log("Tu peux acheter");
            Gamemanager.instance.RemoveScrap(Cost);

            // Activer le comportement sélectionné
            _dogInteraction.ChangeBehavior(selectedBehavior);

            IncreaseAlpha();
        }
        else
        {
            Debug.Log("Pas assez de ressources");
        }
    }

    public void IncreaseAlpha()
    {
        Color currentColor = _GdTxt.color;
        currentColor.a = Mathf.Clamp01(1f); // Incrémenter l'alpha (entre 0 et 1)
        _GdTxt.color = currentColor;
    }
}
