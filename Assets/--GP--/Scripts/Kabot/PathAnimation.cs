using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAnimation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private KabotMovement kabotMovement;
    private Transform[] waypoints;
    private int currentIndex = -1;
    private bool isWaiting = false;

    void Awake()
    {
        int childCount = transform.childCount;
        waypoints = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
        print("test");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.GetComponent<KabotMovement>() != null)
        {
            MoveToNextPoint();
            kabotMovement.CurrentState = KabotMovement.KabotState.GuidePlayer;
        }
    }

    public void MoveToNextPoint()
    {
        print("MoveToNextPoint");
        if (kabotMovement.IsPlayerNear)
        {
            currentIndex++;
            if (currentIndex < waypoints.Length)
            {
                target.position = waypoints[currentIndex].position;
            }
            else
            {
                kabotMovement.CurrentState = KabotMovement.KabotState.FollowPlayer;
                Destroy(gameObject);
            }
        }
        else
        {
            if (!isWaiting)
            {
                StartCoroutine(WaitForPlayer());
            }
        }
    }

    private IEnumerator WaitForPlayer()
    {
        isWaiting = true;
        while (!kabotMovement.IsPlayerNear)
        {
            yield return new WaitForSeconds(0.5f);
        }
        isWaiting = false;
        MoveToNextPoint();
    }
}
