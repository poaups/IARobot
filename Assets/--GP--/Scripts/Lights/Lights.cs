using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour, IInteraction
{
    [SerializeField] private List<Light> lightsToAble;
    [SerializeField] private NotificationMovement notification;

    public void OnInteract()
    {
        print("J'interagis la" + this.gameObject.name);
        DisableLights();
    }
    void DisableLights()
    {
        foreach (Light light in lightsToAble)
        {
            light.enabled = true;
        }
        Gamemanager.instance.AbleControllerCamera();
        StartCoroutine(notification.MoveNotification());
    }
}
