using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowGenerator : MonoBehaviour
{
    public int numCows = 10;
    public GameObject cowPrefab;
    public GameObject ground;
    public float minY = 0f;
    public float maxY = 5f;

    void Awake()
    {
        Mesh groundMesh = ground.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = groundMesh.vertices;

        for (int i = 0; i < numCows; i++)
        {
            int randomIndex = Random.Range(0, vertices.Length);
            Vector3 randomVertex = ground.transform.TransformPoint(vertices[randomIndex]);

            float y = randomVertex.y;

            y = Mathf.Clamp(y, minY, maxY);

            Vector3 position = new Vector3(randomVertex.x, y, randomVertex.z);

            
            Instantiate(cowPrefab, position, Quaternion.identity);
        }
    }
}