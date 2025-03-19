using System.Collections;
using TMPro;
using UnityEngine;
/// <summary>
/// Handles the setup of an object (such as a head) for throwing.
/// Implements the IInteraction interface to allow interaction.
/// When interacted with, it positions itself correctly and disables colliders.
/// </summary>
public class SetupHeadForThrow : MonoBehaviour, IInteraction
{
    [SerializeField] private Transform handPosition;
    [SerializeField] private TextMeshPro txtFeedback;
    [SerializeField] private BoxCollider collider;
    [SerializeField] private BoxCollider trigger;

    [SerializeField] private string txtToShow;
    [SerializeField] private float timeBeforeSetup;

    [HideInInspector] public bool IsAttachedOnHand;
    public void OnInteract()
    {
        StartCoroutine(TimeSetup());
    }
    private void Update()
    {
        if(IsAttachedOnHand)
        {
            SetPos();
        }
    }
    void SetPos()
    {
        transform.position = handPosition.position;
    }
    public void SetCollider(bool newCollider)
    {
        trigger.enabled = newCollider;
        collider.enabled = newCollider;
    }
    IEnumerator TimeSetup()
    {
        //Animation time of picking an object
        yield return new WaitForSeconds(timeBeforeSetup);

        SetCollider(false);
        IsAttachedOnHand = true;
        trigger.enabled = false;
        txtFeedback.text = txtToShow;

        Gamemanager.instance.InteractionPlayer.SetGameOjectThrow(this.gameObject);

        // Disables the stocked GameObject because the handled object is already saved by the player's trigger.
        Gamemanager.instance.PlayerMovementScript.goStocked = null;
    }
}
