using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float recoilForce = 10f;
    public int bulletCollisionCount = 0;
    public int maxBulletCollisions = 5;
    public float movementSpeed = 5f;
    public float targetHeight = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletCollisionCount++;
            if (bulletCollisionCount >= maxBulletCollisions)
            {
                MoveUp();
            }
            else
            {
                Recoil();
            }
        }
    }

    private void Recoil()
    {
        Vector3 direction = (transform.position - Camera.main.transform.position).normalized;
        GetComponent<Rigidbody>().AddForce(direction * recoilForce, ForceMode.Impulse);
    }

    private void MoveUp()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * movementSpeed;
    }
}
