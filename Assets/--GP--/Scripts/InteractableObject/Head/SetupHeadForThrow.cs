using System.Collections;
using TMPro;
using UnityEngine;

public class SetupHeadForThrow : MonoBehaviour, IInteraction
{
    [SerializeField] private Transform newPosition;
    [SerializeField] private TextMeshPro txtFeedback;
    [SerializeField] private string txtToShow;
    [SerializeField] private float timeBeforeSetup;

    [HideInInspector] public bool canSet;
    public void OnInteract()
    {
        StartCoroutine(TimeSetup());

    }

    private void Update()
    {
        if(canSet)
        {
            SetPos();
        }
    }

    void SetPos()
    {
        transform.position = newPosition.position;
    }

    IEnumerator TimeSetup()
    {
        yield return new WaitForSeconds(timeBeforeSetup);
        canSet = true;
        GetComponent<BoxCollider>().enabled = false;
        txtFeedback.text = txtToShow;
        Gamemanager.instance.InteractionPlayer.SetGoToThrow(this.gameObject);
        Gamemanager.instance.PlayerMovementScript.goStocked = null;
    }
}
