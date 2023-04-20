using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 2f;
    public AudioClip attackSound;
    public string targetTag = "Cow";
    

    private Transform target;
    private List<Transform> targets = new List<Transform>();
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FindTargets();
        FindNextTarget();
    }

    void FindTargets()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject targetObject in targetObjects)
        {
            targets.Add(targetObject.transform);
        }
    }

    void FindNextTarget()
    {
        float minDistance = Mathf.Infinity;
        Transform nearestTarget = null;

        foreach (Transform potentialTarget in targets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, potentialTarget.position);
            if (distanceToTarget < minDistance)
            {
                minDistance = distanceToTarget;
                nearestTarget = potentialTarget;
            }
        }

        target = nearestTarget;
    }

    void Update()
    {
        if (target == null)
        {
            FindNextTarget();
            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= attackRange)
        {
            Attack();
        }
        else
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        if (target != null)
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        if (target.CompareTag("Player"))
        {
            audioSource.PlayOneShot(attackSound);
        }
        else if (target.CompareTag(targetTag))
        {
            Destroy(target.gameObject);
        }

        targets.Remove(target);
        FindNextTarget();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            audioSource.PlayOneShot(attackSound);
        }
    }
}
