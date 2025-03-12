using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteraction
{
    [SerializeField] private Door door;
    public void OnInteract()
    {
        door.SetCanOpen(true);
    }
}
