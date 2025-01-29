using Unity.VisualScripting;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    [SerializeField] private BoxCollider objectToTraverse;

    [Header("Target")]
    public Transform player;
    public float speed;

    private bool direction;
    private bool currentlyMove;
    private bool canMove;
    private Transform target;

    private void Awake()
    {
        canMove = false;
        currentlyMove = true;
    }
    private void Update()
    {
        print(currentlyMove + "currentlyMove");
        //if(Input.GetKeyUp(KeyCode.Escape))
        //{
        //    ChangeDirectionMovement();
        //}

        if (Input.GetKeyUp(KeyCode.P))
        {
            SetCanMove(true);
        }

        if(canMove)
        {
            Movement();
        }
    }
    void Movement()
    {
        print("Movement");
        Vector3 direction = (target.position - player.position).normalized;
        player.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(player.position, target.position) < 0.01f)
        {
            canMove = false;
            currentlyMove = true;
            InverseColliderActivation();
            player.position = target.position;
        }
    }

    //public void ChangeDirectionMovement()
    //{
    //    direction = !direction;

    //    print("direction avant changement " + direction + "| taget " + target.name);
    //    if (direction)
    //    {
    //        target = targetBack;
    //    }
    //    else
    //    {
    //        target = targetForward;
    //    }
    //    print("direction apres changement " + direction + " taget " + target.name);
    //}

    public void SetCanMove(bool currentMove)
    {
        print(canMove + "Can Move avant");
        canMove = currentMove;
        currentlyMove = !currentMove;
        print(canMove + "Can Move apres");
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        print(target.name + "SetTarget");
    }
    public bool GetCanMove()
    {
        print("currentlyMove" + currentlyMove);
        return currentlyMove;
    }

    public void InverseColliderActivation()
    {
        objectToTraverse.enabled = !objectToTraverse.enabled;
    }
}


