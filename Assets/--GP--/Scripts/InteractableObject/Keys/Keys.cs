using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Keys : MonoBehaviour, IInteraction
{
    [SerializeField] private Door door;
    [SerializeField] private TakeObject taking;
    public void OnInteract()
    {
        taking.Took();
        door.SetCanOpen(true);
        Destroy(gameObject);
    }
}
