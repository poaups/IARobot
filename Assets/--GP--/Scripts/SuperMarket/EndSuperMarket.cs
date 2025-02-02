using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndActivity : MonoBehaviour
{
    [SerializeField] private float TimeBedoreDog;

    public void StartCoroutine()
    {
        StartCoroutine(WaitBeforeDog());
    }

    public IEnumerator WaitBeforeDog()
    {
        yield return new WaitForSeconds(TimeBedoreDog);
        SoundDog();
    }

    void SoundDog()
    {
        print("Chien arrive");
    }
}
