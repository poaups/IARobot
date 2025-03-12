using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class OpenDoor : MonoBehaviour, IInteraction
{
    [SerializeField] private Door door;
    public void OnInteract()
    {
        door.SetCanOpen(true);
    }
}
