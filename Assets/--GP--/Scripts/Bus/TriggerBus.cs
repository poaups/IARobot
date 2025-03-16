using UnityEngine;

public class TriggerBus : MonoBehaviour
{
    [SerializeField] private ActionTriggerBus bus;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.GetComponent<PlayerMovement>() != null)
        {
            bus.StartAction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bus.DisableAction();
    }
}
