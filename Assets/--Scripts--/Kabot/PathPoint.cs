using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    private PathAnimation pathAnimation;

    void Awake()
    {
        pathAnimation = GetComponentInParent<PathAnimation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KabotMovement>() != null)
        {
            pathAnimation.MoveToNextPoint();
        }
    }
}
