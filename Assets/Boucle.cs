using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boucle : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private float value = 0;
    public Image fade;

    public Transform ori;
    public GameObject engi;
    public GameObject heav;

    private bool hasFaded = false;
    private bool isFading = false;

    private void Start()
    {
        // Fade commence transparent
        SetFadeAlpha(0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            engi.GetComponent<Animator>().Play("Move");
        }
        if (!isFading)
        {
            value += Time.deltaTime ;
            if (value >= 24f)
            {
                value = 24f;
                if (!hasFaded)
                {
                    hasFaded = true;
                    StartCoroutine(FadeCycle());
                }
            }
        }

        timer.text = "Heure actuelle : " + value.ToString("0.00");
    }

    IEnumerator FadeCycle()
    {
        isFading = true;

        // FADE OUT
        yield return StartCoroutine(FadeToAlpha(1f, 2f));

        // Réinitialise positions
        //Pos();

        // Joue les animations
    

        // FADE IN
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeToAlpha(0f, 2f));

        // Réinitialise le chrono
        value = 0f;
        hasFaded = false;
        isFading = false;
    }

    IEnumerator FadeToAlpha(float targetAlpha, float duration)
    {
        float startAlpha = fade.color.a;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / duration);
            SetFadeAlpha(newAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        //PlayAnimation("Move");
        SetFadeAlpha(targetAlpha);
    }

    void SetFadeAlpha(float alpha)
    {
        Color c = fade.color;
        c.a = alpha;
        fade.color = c;
    }

    private void Pos()
    {
        engi.transform.position = ori.transform.position;
        heav.transform.position = ori.transform.position;
    }

    private void PlayAnimation(string animName)
    {
        Animator engiAnim = engi.GetComponent<Animator>();
        Animator heavAnim = heav.GetComponent<Animator>();

        if (engiAnim != null)
            engiAnim.Play(animName);

        if (heavAnim != null)
            heavAnim.Play(animName);
    }
}
