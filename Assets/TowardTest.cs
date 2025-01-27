using UnityEngine;

public class TowardTest : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <0.01f)
        {
            print("Fin");
        }
    }
}
