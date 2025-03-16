using UnityEngine;

/// <summary>
/// Detect of the glass has triger with the head
/// </summary>
/// 
public class TriggerGlass : MonoBehaviour
{
    private Hit hit;
    private void Awake()
    {
        hit = gameObject.GetComponent<Hit>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<TakeObject>() != null)
        {
            print("trigger glass head");
            hit.GlassHit();
        }
    }
}
