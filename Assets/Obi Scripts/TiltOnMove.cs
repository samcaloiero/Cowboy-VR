using UnityEngine;

public class TiltOnMove : MonoBehaviour
{
    public float tiltAngle = 10f;
    public float tiltSpeed = 5f;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > 0f)
        {
            // Calculate the tilt angle based on the direction of movement
            Vector3 movementDirection = _rb.velocity.normalized;
            float targetAngle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;

            // Smoothly rotate the game object towards the target angle
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, tiltSpeed * Time.fixedDeltaTime);

            // Tilt the game object upward slightly
            transform.rotation *= Quaternion.Euler(-tiltAngle, 0f, 0f);
        }
    }
}