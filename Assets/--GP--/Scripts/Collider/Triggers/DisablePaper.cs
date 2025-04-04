using UnityEngine;

public class DisablePaper : MonoBehaviour
{
    [SerializeField] private GameObject objectToDisable;
    [SerializeField] private bool atBegining;

    private void Start()
    {
        if(atBegining)
        {
            objectToDisable.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>()  != null)
        {
            objectToDisable.SetActive(false);
            Gamemanager.instance.starterAssetsInputs.PaperScript = null;
        }
    }
}
