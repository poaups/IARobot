using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask layerRay; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        Debug.DrawRay(origin, direction * rayLength, Color.red, 1.0f);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayLength, layerRay))
        {
            Debug.Log("Ray hit: " + hit.collider.name);
            if(hit.collider.GetComponent<Shelf>() != null)
            {
                print("Collision Shelf");
            }
        }
    }
}
