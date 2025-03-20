using TMPro;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Power up txt script 
/// </summary>
public class PowerUpTxt : MonoBehaviour
{
    //Each power up have the same string so 
    //instead of assing string in each powerup script, all the script take this string
    [field : SerializeField] public string txtPowerUp { get; private set; }
    [field : SerializeField] public bool IsActive { get; private set; }

    [SerializeField] private GameObject txtHolder;
    [SerializeField] private TextMeshProUGUI txt;

    private void Awake()
    {
        AssignBegin();
    }

    public void SetTxtHolder(bool holder, string newTxt)
    {
        txtHolder.SetActive(holder);
        txt.text = newTxt;
    }

    public void DialogueIsActive(bool newActive)
    {
        IsActive = newActive;
    }

    void AssignBegin()
    {
        IsActive = false;
        txtHolder.SetActive(false);
        txt.text = "";
    }
}
