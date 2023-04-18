using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitGame : MonoBehaviour
{
    private Collider collider;
 
    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
