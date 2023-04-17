using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float detectionRange = 10f;

    private GameObject[] enemies;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        float nearestDistance = Mathf.Infinity;
        Vector3 nearestEnemy = Vector3.zero;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < detectionRange && distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy.transform.position;
            }
        }

        if (nearestDistance < Mathf.Infinity)
        {
            Vector3 direction = transform.position - nearestEnemy;
            direction.Normalize();
            
        }
    }
}
