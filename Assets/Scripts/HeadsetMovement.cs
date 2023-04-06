using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsetMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 cameraMove = Camera.main.transform.forward;
        _rigidbody.velocity = cameraMove * speed;
    }
}

