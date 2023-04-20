using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public float speed = 3f; // speed of movement
    public float amplitude = 0.5f; // amount of vertical movement
    public float frequency = 1f; // frequency of vertical movement

    private float timer = 0f; // timer to keep track of movement

    private void Update()
    {
        // update timer
        timer += Time.deltaTime;

        // calculate new position
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Sin(timer * frequency) * amplitude;

        // apply movement
        transform.position = newPosition;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}