using UnityEngine;

public class TriggerNotification : MonoBehaviour
{
    [SerializeField] private string notification;
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<PlayerMovement>() != null)
        {
            Gamemanager.instance.NotificationScript.SetNotification(notification);
        }
    }
}
