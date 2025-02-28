using UnityEngine;

public class Keys : MonoBehaviour, IInteraction
{
    [SerializeField] private Door door;
    public void OnInteract()
    {
        Gamemanager.instance.ControllerPlayer.SetAnimationPick(true);
        Gamemanager.instance.SetCanMove(false);
        door.SetCanOpen(true);
        Destroy(gameObject);
    }
}
