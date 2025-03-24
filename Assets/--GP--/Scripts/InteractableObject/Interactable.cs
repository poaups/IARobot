using UnityEngine;
/// <summary>
/// Manage interactable objects, usable with other scripts via the OnInteract function.
/// </summary>
public class Interactable : MonoBehaviour
{
    public MonoBehaviour interactionScript;

    public void Interact()
    {
        if (interactionScript != null)
        {
            IInteraction interaction = interactionScript as IInteraction;
            if (interaction != null)
            {
                //print(interaction);
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
