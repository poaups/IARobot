using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour, IInteraction
{
    [Header("Animation")]
    [SerializeField] private bool isUp;
    [SerializeField] private bool isDown;
    
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
    private Gamemanager gm;

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
        gm = Gamemanager.instance;
        parentPickObject = gm.parentPickObject;
    }

    public void OnInteract()
    {
        if (isUp)
        {
            gm.PlayerMovementScript.SetAnimationPick(true);
        }
        else if (isDown)
        {
            gm.PlayerMovementScript.SetAnimationPickDown(true);
        }

        gm.SetCanMove(false);
        WichVariablesIncrease();
        RemoveSelf();
        SomethingToPlay();

    }

    //if need to play something at the end for specific obj
    void SomethingToPlay()
    {
        if (SomethingAtEnd != null)
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

    //material change if we have trigger enter with it
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
    //material change to original if we have trigger exit with it
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
