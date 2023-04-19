using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowGenerator : MonoBehaviour
{
    public GameObject cowPrefab;
    public int numCows;
    public GameObject ground;

    void Awake()
    {
        for (int i = 0; i < numCows; i++)
        {
            
            float x = Random.Range(-5.0f, 5.0f); // generate random x position
            float z = Random.Range(-5.0f, 5.0f); // generate random z position
            Vector3 position = new Vector3(x, 0.0f, z) + ground.transform.position; // add ground position offset
            Instantiate(cowPrefab, position, Quaternion.identity); // spawn cow prefab at position
        }
    }
}
