using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAnimation : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Transform[] waypoints;
    private int currentIndex = -1;

    void Awake()
    {
        int childCount = transform.childCount;
        waypoints = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KabotMovement>() != null)
        {
            MoveToNextPoint();
        }
    }

    public void MoveToNextPoint()
    {
        currentIndex ++;
        if (currentIndex < waypoints.Length)
        {
            target.position = waypoints[currentIndex].position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
