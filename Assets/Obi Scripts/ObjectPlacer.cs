using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject ground; // reference to the ground game object
    public GameObject[] plants; // array of plant game objects to place
    public GameObject[] rocks; // array of rock game objects to place
    public int numPlants = 10; // number of plant game objects to place
    public int numRocks = 10; // number of rock game objects to place
    public float minHeight = 0.1f; // minimum height above ground
    public float maxHeight = 1.0f; // maximum height above ground

    private void Start()
    {
        // get bounds of ground game object
        Renderer groundRenderer = ground.GetComponent<Renderer>();
        Bounds groundBounds = groundRenderer.bounds;

        // place plants
        for (int i = 0; i < numPlants; i++)
        {
            // get random plant and random position
            GameObject plant = plants[Random.Range(0, plants.Length)];
            Vector3 position = new Vector3(Random.Range(groundBounds.min.x, groundBounds.max.x), 0f, Random.Range(groundBounds.min.z, groundBounds.max.z));

            // place plant on ground
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(position.x, 100f, position.z), Vector3.down, out hit))
            {
                position.y = hit.point.y + Random.Range(minHeight, maxHeight);
                Instantiate(plant, position, Quaternion.identity);
            }
        }

        // place rocks
        for (int i = 0; i < numRocks; i++)
        {
            // get random rock and random position
            GameObject rock = rocks[Random.Range(0, rocks.Length)];
            Vector3 position = new Vector3(Random.Range(groundBounds.min.x, groundBounds.max.x), 0f, Random.Range(groundBounds.min.z, groundBounds.max.z));

            // place rock on ground
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(position.x, 100f, position.z), Vector3.down, out hit))
            {
                position.y = hit.point.y + Random.Range(minHeight, maxHeight);
                Instantiate(rock, position, Quaternion.identity);
            }
        }
    }
}
