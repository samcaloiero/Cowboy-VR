using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float detectionRange = 10f;
    public float roamRadius = 10f;
    public float roamSpeed = 2f;

    private Vector3 roamCenter;
    private bool isRunning;
    private GameObject[] enemies;

    void Start()
    {
        roamCenter = transform.position;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        if (!isRunning)
        {
            Roam();
        }
        else
        {
            RunAwayFromEnemies();
        }
    }

    void Roam()
    {
        transform.position = Vector3.MoveTowards(transform.position, roamCenter, roamSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, roamCenter) < 0.1f)
        {
            roamCenter = transform.position + Random.insideUnitSphere * roamRadius;
            roamCenter.y = transform.position.y;
            transform.LookAt(roamCenter);
        }

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < detectionRange)
            {
                isRunning = true;
                break;
            }
        }
    }

    void RunAwayFromEnemies()
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

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            isRunning = false;
        }
    }
}
