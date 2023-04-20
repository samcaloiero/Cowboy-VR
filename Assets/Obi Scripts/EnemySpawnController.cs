using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    //public int numEnemies = 10;
   // private int enemyCount;
    public float spawnRadius = 10f;
    public List<Transform> spawnPoints;

    void Start()
    {
        
    }

    public void SpawnEnemies(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Vector3 randomPos = Random.insideUnitSphere * spawnRadius;
            randomPos += spawnPoint.position;

            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        }
    }
    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (Transform spawnPoint in spawnPoints)
        {
            Gizmos.DrawWireSphere(spawnPoint.position, 1f);
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
