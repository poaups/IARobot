using UnityEngine;

public class TriggerBusDriver : MonoBehaviour
{
    [SerializeField] private GameObject feedback;
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<PlayerMovement>() != null)
        {
            if (feedback != null)
            {
                FeedBackEffect(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.GetComponent<PlayerMovement>() != null)
        {
            if(feedback != null)
            {
                FeedBackEffect(false);
            }
        }
    }

    public void DisableFeedback()
    {
        FeedBackEffect(false);
        feedback = null;
    }
    void FeedBackEffect(bool active)
    {
        feedback.SetActive(active);
    }
}
