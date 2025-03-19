using UnityEngine;
/// <summary>
/// Triggers an action when interacted with, implementing the IInteraction interface.
/// Activates a UI element and initiates a player animation when interacted with.
/// </summary>
public class ActionTriggerBus : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject ui;
    public void OnInteract()
    {
        Gamemanager.instance.PlayerMovementScript.SetAnimationFalling(true);
    }
    #region Feedback
    public void StartAction()
    {
        ui.SetActive(true);
    }
    public void DisableAction()
    {
        ui.SetActive(false);
    }
    #endregion
}
