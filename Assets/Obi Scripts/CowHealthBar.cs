using UnityEngine;
using UnityEngine.UI;

public class CowHealthBar : MonoBehaviour
{
    public float startingCows;  // The initial number of cows in the scene
    private float currentCows;  // The current number of cows alive

    private Slider slider;  // Reference to the slider component

    private void Start()
    {
        // Get the slider component
        slider = GetComponent<Slider>();

        // Set the starting number of cows
        currentCows = startingCows;
        UpdateSliderValue();
    }

    public void CowDied()
    {
        currentCows--;
        UpdateSliderValue();
    }

    private void UpdateSliderValue()
    {
        // Update the slider value based on the current number of cows
        slider.value = currentCows / startingCows;
    }

    private void Update()
    {
        UpdateSliderValue();
    }
}