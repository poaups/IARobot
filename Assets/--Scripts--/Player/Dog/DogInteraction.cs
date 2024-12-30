using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteraction : MonoBehaviour
{
    [System.Flags]
    public enum DogBehaviors
    {
        None = 0,          // Aucun comportement s�lectionn�
        Impulsion = 1 << 0  // 1 (binaire 0001)
    }
    public DogBehaviors currentBehaviors;

    [SerializeField] private BoxCollider _trigger;

    void Update()
    {
        ImpulstionFct();
    }

    void ImpulstionFct()
    {
        if (Input.GetKeyDown(KeyCode.E) && (currentBehaviors & DogBehaviors.Impulsion) != 0)
        {
            print("E");

            // Activer le trigger pour 1 frame
            _trigger.enabled = true;

            // D�sactiver le trigger apr�s 1 frame
            StartCoroutine(DisableTriggerAfterOneFrame());
        }
    }

    public void ResetBehaviors()
    {
        currentBehaviors = DogBehaviors.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger");
        // Si le trigger entre en collision avec un objet qui a le composant CanBreakable
        if (other.gameObject.GetComponent<CanBreakable>() != null)
        {
            other.gameObject.GetComponent<CanBreakable>().Impulsion(transform.position);
        }
    }

    // Coroutine pour d�sactiver le trigger apr�s 1 frame
    private IEnumerator DisableTriggerAfterOneFrame()
    {
        print("couroutine");
        // Attendre une frame avant de d�sactiver le trigger
        yield return null;

        // D�sactiver le trigger
        _trigger.enabled = false;
    }
}
