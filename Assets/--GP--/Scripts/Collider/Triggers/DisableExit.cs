using UnityEngine;

public class DisableExit : MonoBehaviour
{
    [SerializeField] private GameObject triggerToAble;
    [SerializeField] private bool deleateMe;
    [SerializeField] private bool notificationBack;
    public void ExitExecute()
    {
        //Able new Go (often notification trigger)
        if(triggerToAble != null)
        {
            triggerToAble.SetActive(true);
        }

        if(deleateMe)
        {
            Destroy(gameObject);
        }

        //Notification going in awake spawn
        if(notificationBack)
        {
            Gamemanager.instance.NotificationScript.StartCoroutine(Gamemanager.instance.NotificationScript.ReturnOriginalPoint());
        }
    }
}
