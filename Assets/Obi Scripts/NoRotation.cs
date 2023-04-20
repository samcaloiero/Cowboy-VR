using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotation : MonoBehaviour
{
    // Set this to true if you want to disable rotation entirely
    public bool disableRotation = true;

    // Ignore gravity for the rigid body
    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.useGravity = false;
        }
    }

    // Disable rotation by resetting the rotation each frame
    private void FixedUpdate()
    {
        if (disableRotation)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
