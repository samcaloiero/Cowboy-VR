using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    private Collider collider;
    public StartScreenManager _startScreenManager;
    private AudioSource audioSource;
    private void Awake()
    {
        collider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            _startScreenManager.numberOfAliens -= 1;
            audioSource.Play();
            
        }
    }
}
