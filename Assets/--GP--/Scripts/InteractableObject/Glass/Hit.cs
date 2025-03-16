using UnityEngine;
/// <summary>
/// Action when trhowable object trigger this
/// </summary>
public class Hit : MonoBehaviour
{
    public void GlassHit()
    {
        print("GlassHit");
        //visual effect here
        Destroy(gameObject);
    }
}
