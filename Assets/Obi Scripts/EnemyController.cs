using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 3.0f;
    public List<GameObject> cowObjects;
    public List<GameObject> playerObjects;
    public AudioClip collisionSound;

    private Transform target;

    void Start()
    {
        // Find all game objects with the "Cow" tag and add them to the cowObjects list
        GameObject[] cowGOs = GameObject.FindGameObjectsWithTag("Cow");
        foreach (GameObject cowGO in cowGOs)
        {
            cowObjects.Add(cowGO);
        }

        // Find all game objects with the "Player" tag and add them to the playerObjects list
        GameObject[] playerGOs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerGO in playerGOs)
        {
            playerObjects.Add(playerGO);
        }
    }

    void Update()
    {
        GameObject targetObject = GetNearestObject();

        if (targetObject != null)
        {
            target = targetObject.transform;

            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Rotate towards the target
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    GameObject GetNearestObject()
    {
        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject cowObject in cowObjects)
        {
            float distance = Vector3.Distance(transform.position, cowObject.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestObject = cowObject;
            }
        }

        foreach (GameObject playerObject in playerObjects)
        {
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestObject = playerObject;
            }
        }

        return nearestObject;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            // Destroy the cow game object on collision
            Destroy(other.gameObject);

            // Play collision sound
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            // Play collision sound
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }
}
