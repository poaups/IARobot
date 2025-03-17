using UnityEngine;

public class ActionTriggerBus : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject ui;
    public void OnInteract()
    {
        Gamemanager.instance.PlayerMovementScript.SetAnimationFalling(true);
        print("ANim playe la");
    }
    public void StartAction()
    {
        ui.SetActive(true);
    }

    public void DisableAction()
    {
        ui.SetActive(false);
    }
}
