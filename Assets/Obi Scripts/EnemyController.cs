using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f; // Enemy speed
    public float cowCatchRadius = 3.0f; // Radius to search for cows
    private GameObject targetCow; // Current cow target

    private void Update()
    {
        // If there is no target cow or the current target cow no longer exists,
        // find a new target cow
        if (targetCow == null || !targetCow.activeSelf)
        {
            FindTargetCow();
        }
        else
        {
            // Move towards the target cow
            Vector3 direction = targetCow.transform.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
            transform.LookAt(targetCow.transform.position);
        }
    }

    private void FindTargetCow()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, cowCatchRadius);

        float nearestDistance = Mathf.Infinity;
        GameObject nearestCow = null;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Cow"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestCow = collider.gameObject;
                }
            }
        }

        targetCow = nearestCow;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cow"))
        {
            // Destroy the cow
            Destroy(collision.gameObject);
            // Find a new target cow
            FindTargetCow();
        }
    }
}