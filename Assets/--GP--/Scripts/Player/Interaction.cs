using UnityEngine;

/// <summary>
/// Trow object with GoToThrow, you need to assing go for GoToThrow and call function Throw
/// </summary>
public class Interaction : MonoBehaviour
{
    public GameObject GoToThrow { get; private set; }

    [SerializeField] private float forwardForce = 10f;
    [SerializeField] private float upwardForce = 3f; 

    public void Throw()
    {
        if (GoToThrow != null)
        {
            GoToThrow.GetComponent<SetupHeadForThrow>().canSet = false;
            Rigidbody rb = GoToThrow.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = GoToThrow.AddComponent<Rigidbody>();
            }
            rb.velocity = Vector3.zero;

            Vector3 throwDirection = transform.forward * forwardForce + transform.up * upwardForce;
            rb.AddForce(throwDirection, ForceMode.Impulse);
        }
    }

    public void SetGoToThrow(GameObject go)
    {
        GoToThrow = go;
    }
}
