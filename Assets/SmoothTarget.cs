using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothTarget : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;
    public float speed = 5f;

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 2f)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
