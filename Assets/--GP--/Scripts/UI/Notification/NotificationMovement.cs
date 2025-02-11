using System.Collections;
using UnityEngine;

public class NotificationMovement : MonoBehaviour
{
    [Header("Notification Parameters")]
    [SerializeField] private float secondsBeforeNotification;
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
    }
    //GO going toward target
    public IEnumerator MoveNotification()
    {
        while(Vector3.Distance(transform.position, target.position) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    //GO going toward position at begining
    void ReturnOriginalPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _originalPos, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _originalPos) <= 0.1f)
        {
            canMove = true;
        }
    }
}
