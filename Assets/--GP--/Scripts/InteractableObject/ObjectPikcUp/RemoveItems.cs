using System.Collections;
using UnityEngine;

public class RemoveItems : MonoBehaviour, IInteraction
{
    [SerializeField] private ParentItems parent;
    [SerializeField] private int indexItem;
    [SerializeField] private float WaitAnimation;
    public void OnInteract()
    {
        print("J'interagis avec ");
        RemoveSelf();
    }

    void RemoveSelf()
    {
        StartCoroutine(WaitBeforeRemove());
        print("RemoveSelf");
    }

    IEnumerator WaitBeforeRemove()
    {
        yield return new WaitForSeconds(WaitAnimation);
        parent.ChangeBool(indexItem);
        Destroy(gameObject);
    }
}
