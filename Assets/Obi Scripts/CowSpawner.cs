using System.Collections;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject cowPrefab;
    public GameObject[] cowSpawners;
    public int numCowsToSpawn = 10;
    public float spawnRadius = 10f;

    private void Start()
    {
        SpawnCows();
    }

    private void SpawnCows()
    {
        for (int i = 0; i < numCowsToSpawn; i++)
        {
            GameObject randomSpawner = cowSpawners[Random.Range(0, cowSpawners.Length)];
            Vector3 spawnPosition = randomSpawner.transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = 0;
            Instantiate(cowPrefab, spawnPosition, Quaternion.identity);
        }
    }
}