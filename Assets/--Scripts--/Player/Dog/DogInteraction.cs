using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteraction : MonoBehaviour
{
    [System.Flags]
    public enum DogBehaviors
    {
        None = 0,          // Aucun comportement sélectionné
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
            _trigger.enabled = true;
            StartCoroutine(DisableTriggerAfterOneFrame());
        }
    }

    public void ResetBehaviors()
    {
        currentBehaviors = DogBehaviors.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CanBreakable>() != null)
        {
            other.gameObject.GetComponent<CanBreakable>().Impulsion(transform.position);
        }
    }

    // Coroutine pour désactiver le trigger après 1 frame
    private IEnumerator DisableTriggerAfterOneFrame()
    {
        print("couroutine");
        yield return null;
        _trigger.enabled = false;
    }
}
