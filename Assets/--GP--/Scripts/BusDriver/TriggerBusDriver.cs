using UnityEngine;

public class TriggerBusDriver : MonoBehaviour
{
    [SerializeField] private GameObject feedback;
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<PlayerMovement>() != null)
        {
            feedback.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.GetComponent<PlayerMovement>() != null)
        {
            feedback.SetActive(false);
        }
    }
}
