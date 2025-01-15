
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Movement();

    }
    void Movement()
    {
        float _inputX = Input.GetAxisRaw("Horizontal");
        float _inputZ = Input.GetAxisRaw("Vertical");

        Vector3 _movement = new Vector3(_inputX, 0 ,_inputZ).normalized;
        _rb.velocity = _movement * _speed;
    }
}
