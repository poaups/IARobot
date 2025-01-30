using TMPro;
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

    void Update()
    {
        WaitForFunction();
        if (canReturn)
        {
            ReturnOriginalPoint();
        }

        #region Input Test Function
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    canReturn = true;
        //}

        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    canReturn = false;
        //}

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    DisableSelf();
        //}
      

        //print(canReturn);
        #endregion
    }

    //Wait seconde before moving
    void WaitForFunction()
    {
        timer += Time.deltaTime;
        if (timer >= secondsBeforeNotification && canMove)
        {
            MoveNotification();
        }
    }
    //GO going toward target
    void MoveNotification()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            canMove = false;
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
