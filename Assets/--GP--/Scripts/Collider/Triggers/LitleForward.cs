using UnityEngine;

public class LitleForward : MonoBehaviour
{
    [SerializeField] private PlayerInteraction playerInteraction;

    private StarterAssetsInputs inputScript;
    private Shelf shelfScript;

    private void Awake()
    {
        inputScript = GetComponentInParent<StarterAssetsInputs>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<Shelf>() != null)
        {
            shelfScript = other.GetComponent<Shelf>();
            print(shelfScript + " shelfScript");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.GetComponent<Shelf>() != null)
        {
            shelfScript = null;
            print(shelfScript + " shelfScript");
        }
    }

    private void Update()
    {
        if(inputScript.isInteracting && shelfScript != null && playerInteraction.GetCanTakeBox())
        {
            shelfScript.UseObject();
        }
        
    }
}
