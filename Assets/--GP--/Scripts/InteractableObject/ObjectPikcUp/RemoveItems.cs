using System.Collections;
using UnityEngine;

public class RemoveItems : MonoBehaviour, IInteraction
{
    [SerializeField] private TakeObject taking;
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
        taking.Took();
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
        if(parent != null)
        {
            parent.ChangeBool(indexItem);
        }
        Destroy(gameObject);
    }
}
