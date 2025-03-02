using UnityEngine;

public class DisablePaper : MonoBehaviour
{
    [SerializeField] private GameObject objectToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>()  != null)
        {
            objectToDisable.SetActive(false);
            Gamemanager.instance.starterAssetsInputs.PaperScript = null;
        }
    }
}
