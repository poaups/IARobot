using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndActivity : MonoBehaviour
{
    [SerializeField] private float TimeBedoreDog;

    [Header("Door")]
    [SerializeField] private GameObject triggerDoor;

    private void Awake()
    {
        triggerDoor.SetActive(false);
    }
    public void EndAction()
    {
        StartCoroutine(WaitBeforeDog());
        triggerDoor.SetActive(true);
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
