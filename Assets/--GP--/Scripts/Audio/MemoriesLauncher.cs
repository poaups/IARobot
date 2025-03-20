using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemoriesLauncher : MonoBehaviour
{
    [HideInInspector] public List<string> ListOfText;

    [SerializeField] private float timeCurrentText;
    [SerializeField] private GameObject txtHodlder;
    [SerializeField] private float speedCurrentTexte;
    [SerializeField] private TextMeshProUGUI txt;

    private bool currentlyPlay;

    public IEnumerator WaitBetweenChar()
    {
        SetHolder(true);
        txt.text = string.Empty;
        for (int i = 0; i < ListOfText.Count; i++)
        {
            foreach (char c in ListOfText[i])
            {
                txt.text += c;
                yield return new WaitForSeconds(speedCurrentTexte);
            }

            yield return new WaitForSeconds(timeCurrentText);
            txt.text = string.Empty;
        }
        SetHolder(false);
    }

    void SetHolder(bool activeHolder)
    {
        if(txtHodlder != null)
        {
            txtHodlder.SetActive(activeHolder);
        }
    }
}
