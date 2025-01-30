using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    [SerializeField] private DeathLauncher deathLauncher;
    [SerializeField] private List<string> listOfText;
    [SerializeField] private float timeCurrentText;
    [SerializeField] private float speedCurrentTexte;
    //[SerializeField] private AudioClip Voice;

    private bool currentlyPlay;
    private TextMeshProUGUI localSubtitels;

    private void Awake()
    {
        currentlyPlay = false;
        localSubtitels = deathLauncher.textSubtitels;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.GetComponent<Controller>() != null)
        {
            if(!currentlyPlay)
            {
                StartCoroutine(WaitBetweenChar());
            }
        }
    }
    IEnumerator WaitBetweenChar()
    {
        currentlyPlay = true;
        localSubtitels.text = string.Empty;
        for (int i = 0; i < listOfText.Count; i++)
        {
            foreach (char c in listOfText[i])
            {
                localSubtitels.text += c;
                yield return new WaitForSeconds(speedCurrentTexte);
            }

            yield return new WaitForSeconds(timeCurrentText);
            localSubtitels.text = string.Empty;
        }
        currentlyPlay = false;
    }
}
