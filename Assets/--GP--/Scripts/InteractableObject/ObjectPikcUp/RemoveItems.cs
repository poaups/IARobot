using System.Collections;
using UnityEngine;

public class RemoveItems : MonoBehaviour, IInteraction
{
    [SerializeField] private ParentItems parent;
    [SerializeField] private Material wireFrameMat;
    [SerializeField] private int indexItem;
    [SerializeField] private float WaitAnimation;

    private Material awakeMat;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        awakeMat = meshRenderer.material;
    }
    public void OnInteract()
    {
        print("J'interagis avec ");
        Gamemanager.instance.ControllerPlayer.SetAnimationPick(true);
        Gamemanager.instance.SetCanMove(false);
        RemoveSelf();
    }

    void RemoveSelf()
    {
        StartCoroutine(WaitBeforeRemove());
        print("RemoveSelf");
    }
    public void DisplayEffect()
    {
        print("DisplayEffect");
        meshRenderer.material = wireFrameMat;
    }

    public void UnDisplayEffect()
    {
        print("UnDisplayEffect");
        meshRenderer.material = awakeMat;
    }
    IEnumerator WaitBeforeRemove()
    {
        yield return new WaitForSeconds(WaitAnimation);
        parent.ChangeBool(indexItem);
        Destroy(gameObject);
    }
}
