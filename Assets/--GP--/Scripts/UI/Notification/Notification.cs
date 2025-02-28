using System.Collections;
using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [Header("Notification Parameters")]
    [SerializeField] private float secondsBeforeNotification;
    [SerializeField] private TextMeshProUGUI notificationTxt;
    [SerializeField] private float speed;
    [SerializeField] private Transform target;

    private float timer;
    private Vector3 _originalPos;
    private bool canReturn;
    private bool canMove;

    private void Awake()
    {
        canReturn = false;
        canMove = true;
        _originalPos = transform.position;
        StartCoroutine(MoveNotification());
    }
    public void SetNotification(string newTxt)
    {
        notificationTxt.text = newTxt;
    }
    //GO going toward target
    public IEnumerator MoveNotification()
    {
        yield return new WaitForSeconds(secondsBeforeNotification);

        while(Vector3.Distance(transform.position, target.position) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    //GO going toward position at begining
    public IEnumerator ReturnOriginalPoint()
    {
        print("ReturnOriginalPoint");

        while (Vector3.Distance(transform.position, _originalPos) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _originalPos, speed * Time.deltaTime);
            yield return null;
        }
    }


}
