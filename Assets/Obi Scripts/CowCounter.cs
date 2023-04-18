using UnityEngine;

public class CowCounter : MonoBehaviour
{
    public int cowsAlive = 0;  // The number of cows currently alive in the scene

    private void Start()
    {
        // Get the initial number of cows in the scene
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        cowsAlive = cows.Length;
    }

    private void Update()
    {
        // Check if any cows have been destroyed and update the count accordingly
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        int currentCowsAlive = cows.Length;
        if (currentCowsAlive < cowsAlive)
        {
            cowsAlive = currentCowsAlive;
        }
    }
}