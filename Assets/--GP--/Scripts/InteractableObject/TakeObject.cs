using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour, IInteraction
{
    [Header("Animation")]
    [SerializeField] private bool isUp;
    
    [Range(0,5)]
    [SerializeField] private float WaitAnimation;

    [Header("Saveable object")]
    [SerializeField] private bool keys;
    [SerializeField] private bool paw;

    [SerializeField] private MonoBehaviour SomethingAtEnd;
    private ParentItems parentPickObject;
    [SerializeField] private Material wireFrameMat;
    [SerializeField] private int indexItem;
    [SerializeField] private GameObject txtFeedBack;

    private Material awakeMat;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        awakeMat = meshRenderer.material;
        
        if (txtFeedBack != null)
        {
            txtFeedBack.SetActive(false);
        }
    }

    private void Start()
    {
        parentPickObject = Gamemanager.instance.parentPickObject;
    }

    public void OnInteract()
    {
        if (isUp)
        {
            Gamemanager.instance.PlayerMovementScript.SetAnimationPick(true);
        }
        else
        {
            Gamemanager.instance.PlayerMovementScript.SetAnimationPickDown(true);
        }
        Gamemanager.instance.SetCanMove(false);
        WichVariablesIncrease();
        RemoveSelf();

        if(SomethingAtEnd != null)
        {
            IInteraction interaction = SomethingAtEnd as IInteraction;
            interaction.OnInteract();
        }
    }
    void WichVariablesIncrease()
    {
        if(paw)
        {
            Gamemanager.instance.updateKaboot.Paw = true;
        }

        if (keys)
        {
            Gamemanager.instance.SetKeys(true);
        }
    }

    public void DisplayEffect()
    {
        if(wireFrameMat != null)
        {
            meshRenderer.material = wireFrameMat;
        }

        if(txtFeedBack != null)
        {
            txtFeedBack.SetActive(true);
        }

    }

    public void UnDisplayEffect()
    {
        meshRenderer.material = awakeMat;
        txtFeedBack.SetActive(false);
    }
    void RemoveSelf()
    {
        StartCoroutine(WaitBeforeRemove());
    }

    IEnumerator WaitBeforeRemove()
    {
        yield return new WaitForSeconds(WaitAnimation);
        if (parentPickObject != null)
        {
            parentPickObject.ChangeBool(indexItem);
        }
        Destroy(gameObject);
    }
}
