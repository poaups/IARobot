using UnityEngine;

public class RemoveItems : MonoBehaviour, IInteraction
{
    [SerializeField] private ParentItems parent;
    [SerializeField] private int indexItem;
    public void OnInteract()
    {
        print("J'interagis avec ");
        RemoveSelf();
    }

    void RemoveSelf()
    {
        print("RemoveSelf");
        parent.ChangeBool(indexItem);
        Destroy(gameObject);
    }
}
