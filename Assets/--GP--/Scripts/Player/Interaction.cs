using UnityEngine;

/// <summary>
/// Handles object throwing using GoToThrow. 
/// You need to assign a GameObject to GoToThrow and call the Throw function to throw it.
/// </summary>
public class Interaction : MonoBehaviour
{
    [HideInInspector] public bool CanObey = false;
    
    private bool hasPliers = false;
    private Animator animator;

    private void Awake()
    {
        CanObey = false;
        animator = GetComponent<Animator>();
    }
    #region Reference
    public GameObject GoToThrow { get; private set; }

    [SerializeField] private float forwardForce = 10f;
    [SerializeField] private float upwardForce = 3f;

    private SetupHeadForThrow throwObj;
    #endregion
    #region Throw
    public void Throw()
    {
        if (GoToThrow != null)
        {
            throwObj = GoToThrow.GetComponent<SetupHeadForThrow>();
            throwObj.IsAttachedOnHand = false;
            throwObj.SetCollider(true);

            Rigidbody rb = GoToThrow.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;

                Vector3 throwDirection = transform.forward * forwardForce + transform.up * upwardForce;
                rb.AddForce(throwDirection, ForceMode.Impulse);
            }
            else
            {
                Debug.LogError("Rigidbody missing : " + GoToThrow.name);
            }
        }
        else
        {
            Debug.LogError("GoToThrow missing");
        }
    }

    public void SetGameOjectThrow(GameObject go)
    {
        GoToThrow = go;
    }
    #endregion

    public void Memories(bool newUpgrade)
    {
        animator.SetBool("Upgrade", newUpgrade);
    }

    public void UsePliers()
    {
        print("UsePliers");
    }

    public bool GetPliers()
    {
        return hasPliers;
    }
    public void SetPliers(bool value)
    {
        hasPliers = value;
    }
}
