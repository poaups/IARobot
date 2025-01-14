using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBreakable : MonoBehaviour
{
    [SerializeField] private float _force = 10;
    private Rigidbody _rigidbody;
    [HideInInspector] public bool _alreadyBreak = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Impulsion(Vector3 dogDirection)
    {
        _alreadyBreak = true;
        print("Impulsion");
        Vector3 forceDirection = -dogDirection.normalized;
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.AddForce(forceDirection * _force, ForceMode.Impulse);
    }
}
