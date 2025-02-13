using UnityEngine;

public class Interactable : MonoBehaviour
{
    public MonoBehaviour interactionScript;

    public void Interact()
    {
        print("Interact");
        if (interactionScript != null)
        {
            IInteraction interaction = interactionScript as IInteraction;
            if (interaction != null)
            {
                interaction.OnInteract();
            }
            else
            {
                Debug.LogWarning("Interaction script does not implement IInteraction interface.");
            }
        }
        else
        {
            Debug.LogWarning("No interaction script attached to " + gameObject.name);
        }
    }
}
