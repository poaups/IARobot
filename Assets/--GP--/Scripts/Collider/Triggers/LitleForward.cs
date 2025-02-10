using UnityEngine;

public class LitleForward : MonoBehaviour
{
    public GameObject goStocked = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Interactable>() != null)
        {
            goStocked = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Interactable>() != null)
        {
            goStocked = null;
        }
    }

    private void Update()
    {
        if(goStocked != null)
        {
            print("Objet stcoke" + goStocked.name);
        }
    }
}
