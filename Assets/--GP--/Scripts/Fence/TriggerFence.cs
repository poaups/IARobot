using UnityEngine;

public class TriggerFence : MonoBehaviour
{
    [SerializeField] private GameObject feedBack;

    private void OnTriggerEnter(Collider other)
    {
        feedBack.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        feedBack.SetActive(false);
    }
}
