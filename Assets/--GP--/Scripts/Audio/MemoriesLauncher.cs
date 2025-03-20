using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemoriesLauncher : MonoBehaviour
{
    [SerializeField] private List<string> listOfText;
    [SerializeField] private float timeCurrentText;
    [SerializeField] private GameObject txtHodlder;
    [SerializeField] private float speedCurrentTexte;
    [SerializeField] private TextMeshProUGUI txt;

    private bool currentlyPlay;

    IEnumerator WaitBetweenChar()
    {
        SetHolder(true);
        txt.text = string.Empty;
        for (int i = 0; i < listOfText.Count; i++)
        {
            foreach (char c in listOfText[i])
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
