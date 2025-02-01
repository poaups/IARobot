using StarterAssets;
using UnityEngine;

public class ForwardPlayer : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs inputScript;
    [SerializeField] private PlayerInteraction interactionScript;

    private GameObject goTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<ItemTP>() != null)
        {
            print("Collision int " + other.name);
            goTriggered = other.gameObject;
            interactionScript.SetTakeBox(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.GetComponent<ItemTP>() != null)
        {
            print("Collision out " + other.name);
            goTriggered = null;
            interactionScript.SetTakeBox(false);

        }
    }

    private void Update()
    {
        if(inputScript.isInteracting && goTriggered != null)
        {
            print(inputScript.isInteracting);
            print("La caisse doit se mettre sur leplayer");
        }
    }
}
