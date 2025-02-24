using UnityEngine;

public class Begin : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private Notification notification;

    public void OnInteract()
    {
        print("J'interagis la" + this.gameObject.name);
        DisableImage();
    }
    void DisableImage()
    {
        blackScreen.SetActive(false);
        //Gamemanager.instance.AbleControllerCamera();
        StartCoroutine(notification.MoveNotification());
    }
}
