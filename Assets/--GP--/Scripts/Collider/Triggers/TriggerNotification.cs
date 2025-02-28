using UnityEngine;

public class TriggerNotification : MonoBehaviour
{
    [SerializeField] private string notification;
    [SerializeField] private DisableExit somethingAtExit;
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<PlayerMovement>() != null)
        {
            Gamemanager.instance.NotificationScript.SetNotification(notification);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (somethingAtExit != null && other != null && other.GetComponent<PlayerMovement>() != null)
        {
            somethingAtExit.ExitExecute();
        }
    }
}
