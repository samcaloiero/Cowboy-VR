using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Jetpack : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float speed;
    [SerializeField] private float TimeToExplode = 15;
    private float _timer;
    private bool exploded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        exploded = false;
        _timer = TimeToExplode;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerCountDown();
        
        if (!exploded && TimerEnd())
        {
            exploded = true;
            _rigidbody.velocity = Random.onUnitSphere * 10;
        }
    }

    public void TimerCountDown()
    {
        _timer = _timer - Time.deltaTime;
    }

    public bool TimerEnd()
    {
        return _timer <= 0;
    }
    private void FixedUpdate()
    {
        if (!exploded)
        {
            Vector3 vertical = Vector3.up;
            _rigidbody.velocity = vertical * speed;
            Vector3 cameraMove = Camera.main.transform.forward;
            _rigidbody.velocity = cameraMove * speed;
        }
    }
}
