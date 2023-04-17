using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed = 5f;
    public GameObject cowPrefab;
    public GameObject player;
    public float attackDistance = 1f;
    public float attackInterval = 2f;
    public float damage = 10f;
    public GameObject bloodSplatter;

    private float lastAttackTime;

    void Update()
    {
        // Find the nearest target (cow or player)
        GameObject target = FindNearestTarget();

        // If there is a target within attack range, move towards it
        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        // Attack the target if it's within attack range and the attack interval has elapsed
        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= attackDistance && Time.time - lastAttackTime >= attackInterval)
        {
            lastAttackTime = Time.time;

            if (target.CompareTag("Cow"))
            {
                Destroy(target);
            }
            else if (target.CompareTag("Player"))
            {
                Instantiate(bloodSplatter, player.transform.position, Quaternion.identity);
                StartCoroutine(ResetBloodSplatter());
            }
        }
    }

    GameObject FindNearestTarget()
    {
        GameObject nearestCow = null;
        float cowDistance = Mathf.Infinity;

        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");

        foreach (GameObject cow in cows)
        {
            float distance = Vector3.Distance(transform.position, cow.transform.position);

            if (distance < cowDistance)
            {
                cowDistance = distance;
                nearestCow = cow;
            }
        }

        float playerDistance = Vector3.Distance(transform.position, player.transform.position);

        if (playerDistance < cowDistance)
        {
            return player;
        }
        else
        {
            return nearestCow;
        }
    }

    IEnumerator ResetBloodSplatter()
    {
        yield return new WaitForSeconds(3f);
        bloodSplatter.SetActive(false);
    }
}
