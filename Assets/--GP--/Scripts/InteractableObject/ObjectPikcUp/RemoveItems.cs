using System.Collections;
using UnityEngine;

public class RemoveItems : MonoBehaviour, IInteraction
{
    [SerializeField] private ParentItems parent;
    [SerializeField] private Material wireFrameMat;
    [SerializeField] private int indexItem;
    [SerializeField] private float WaitAnimation;
    [SerializeField] private GameObject txtFeedBack;

    private Material awakeMat;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        awakeMat = meshRenderer.material;
        txtFeedBack.SetActive(false);
    }
    public void OnInteract()
    {
        Gamemanager.instance.ControllerPlayer.SetAnimationPick(true);
        Gamemanager.instance.SetCanMove(false);
        RemoveSelf();
    }

    void RemoveSelf()
    {
        StartCoroutine(WaitBeforeRemove());
    }
    public void DisplayEffect()
    {
        meshRenderer.material = wireFrameMat;
        txtFeedBack.SetActive(true);
    }

    public void UnDisplayEffect()
    {
        meshRenderer.material = awakeMat;
        txtFeedBack.SetActive(false);
    }
    IEnumerator WaitBeforeRemove()
    {
        yield return new WaitForSeconds(WaitAnimation);
        parent.ChangeBool(indexItem);
        Destroy(gameObject);
    }
}
