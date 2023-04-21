using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    private Rigidbody _rb;
    public bool yPositionFrozen = true;
    public int bulletCollisionCount = 0;
    public int maxBulletCollisions = 5;
    public float targetHeight = 10f;
    public float speed = 5f; // The speed at which to move the object

    private bool movingUp = true; // Whether the object is currently moving up or not

    private void Start()
    {
        // Get the Rigidbody component
        _rb = GetComponent<Rigidbody>();

        // Freeze the Y position
        if (yPositionFrozen)
        {
            _rb.constraints = RigidbodyConstraints.FreezeRotationY;
            _rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletCollisionCount++;
            if (bulletCollisionCount >= maxBulletCollisions)
            {
                MoveUp();
            }
        }
    }

    private void MoveUp()
    {
        if (movingUp)
        {
            yPositionFrozen = false;
            transform.Translate(Vector3.up * speed * Time.deltaTime); // Move the object upwards
            if (transform.position.y >= targetHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            yPositionFrozen = true;
            _rb.constraints = RigidbodyConstraints.FreezeRotationY;

        }
    }

    private void Update()
    {
        if (yPositionFrozen == false)
        {
            StartCoroutine(DestroyAfterDelayCoroutine());
        }
        if (bulletCollisionCount >= 20)
        {
            DestroyObject(this);
        }

    }

    private IEnumerator DestroyAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}


