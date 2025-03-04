using UnityEngine;

public class Begin : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject Pause;
    [SerializeField] private Sensitivity sensitivity;
    [SerializeField] private Notification notification;


    private void Start()
    {
        Pause.SetActive(true);
        sensitivity.AbleSettings();
        Pause.SetActive(false);
    }
    public void OnInteract()
    {
        print("J'interagis la" + this.gameObject.name);
        DisableImage();
    }
    void DisableImage()
    {
        blackScreen.SetActive(false);
        StartCoroutine(notification.MoveNotification());
    }
}
