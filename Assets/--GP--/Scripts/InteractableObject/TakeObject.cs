using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Handles the interaction for picking up objects.
/// Implements the IInteraction interface to allow interaction.
/// - Plays an animation based on whether the object is picked up from above or below.
/// - Updates variables related to collected items (e.g., keys, paw, ladder).
/// - Changes the object's material when interacted with for visual feedback.
/// - Triggers additional actions if needed after pickup.
/// - Optionally destroys the object after interaction.
/// </summary>
public class TakeObject : MonoBehaviour, IInteraction
{
    #region Reference
    [Header("Animation")]
    [SerializeField] private bool isUp;
    [SerializeField] private bool isDown;
    
    [Range(0,5)]
    [SerializeField] private float timeAnimation;

    [Header("Saveable object")]
    [SerializeField] private bool keys;
    [SerializeField] private bool paw;
    [SerializeField] private bool ladder;

    [Header("Parameters")]
    [SerializeField] private MonoBehaviour SomethingAtEnd;
    [SerializeField] private bool needToBeDestroy;
    [SerializeField] private bool canBeReTake;
    public bool AttachToHand;
    [SerializeField] private int indexItem;

    [Header("Feedback")]
    [SerializeField] private Material wireFrameMat;
    [SerializeField] private GameObject txtFeedBack;

    private ParentItems parentPickObject;
    private Material awakeMat;
    private MeshRenderer meshRenderer;
    private Gamemanager gm;

    #endregion
    private void Awake()
    {
        Begin();
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

        if(!canBeReTake)
        { 
            Destroy(GetComponent<BoxCollider>());
           
        }
        gm.SetCanMove(false);
        WichVariablesIncrease();
        UnDisplayEffect();
        if (needToBeDestroy)
        {
            RemoveSelf();
        }

        SomethingToPlay();

    }
    void Begin()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        awakeMat = meshRenderer.material;

        if (txtFeedBack != null)
        {
            txtFeedBack.SetActive(false);
        }
    }

    // Triggers an interaction on the assigned object if it implements the IInteraction interface.
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
            Gamemanager.instance.objectSavePlayer.Keys = true;
        }

        if (ladder)
        {
            Gamemanager.instance.objectSavePlayer.Ladder = true;
        }
    }

    #region Visual Effect
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
        if (txtFeedBack != null)
        {
            txtFeedBack.SetActive(false);
        }
    }
    void RemoveSelf()
    {
        StartCoroutine(WaitBeforeRemove());
    }
    IEnumerator WaitBeforeRemove()
    {
        yield return new WaitForSeconds(timeAnimation);

        if (parentPickObject != null)
        {
            parentPickObject.ChangeBool(indexItem);
        }

        Destroy(gameObject);
    }
    #endregion 

}
