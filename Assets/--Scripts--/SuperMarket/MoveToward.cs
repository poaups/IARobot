using UnityEngine;

public class MoveToward : MonoBehaviour
{

    [Header("Target")]
    public Transform targetBack;
    public Transform targetForward;

    public Transform player;
    public float speed;

    private bool direction;
    private bool currentlyMove;
    private Transform target;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            ChangeDirectionMovement();
        }
    }
    void MovementStart()
    {
        Vector3 direction = (target.position - player.position).normalized;
        player.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(player.position, target.position) < 0.01f)
        {
            player.position = target.position;
        }
    }
    void MovementBack()
    {

    }

    public void ChangeDirectionMovement()
    {
        direction = !direction;

        print("direction avant changement " + direction + "| taget " + target);
        if (direction)
        {
            target = targetBack;
        }
        else
        {
            target = targetForward;
        }
        print("direction apres changement " + direction + " taget " + target);
    }
}


