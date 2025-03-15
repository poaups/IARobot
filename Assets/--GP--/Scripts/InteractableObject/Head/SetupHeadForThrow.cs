using TMPro;
using UnityEngine;

public class SetupHeadForThrow : MonoBehaviour, IInteraction
{
    [SerializeField] private Transform newPosition;
    [SerializeField] private TextMeshPro txtFeedback;
    [SerializeField] private string txtToShow;

    private bool canSet;
    public void OnInteract()
    {
        canSet = true;
        GetComponent<BoxCollider>().enabled = false;
        txtFeedback.text = txtToShow;
        Gamemanager.instance.InteractionPlayer.GoToThrow = this.gameObject;
        Gamemanager.instance.PlayerMovementScript.goStocked = null;
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
}
