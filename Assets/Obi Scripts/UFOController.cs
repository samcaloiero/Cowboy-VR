using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public int bulletCollisionCount = 0;
    public int maxBulletCollisions = 5;
    public float targetHeight = 10f;
    public float speed = 5f;  // The speed at which to move the object

    private bool movingUp = true;  // Whether the object is currently moving up or not

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
            transform.Translate(Vector3.up * speed * Time.deltaTime); // Move the object upwards
            if (transform.position.y >= targetHeight)
            {
                movingUp = false;
            }
        }
    }
}
