
using UnityEngine;
using UnityEngine.UI;

public class CowHealthBar : MonoBehaviour
{
    public CowCounter cowCounter;  // The cow counter script that tracks the number of cows in the scene
    public float startingCows = 0;  // The initial number of cows in the scene
    public Image healthBar;  // The UI health bar to update

    private float currentCowsAlive;  // The current number of cows alive in the scene

    private void Start()
    {
        currentCowsAlive = startingCows;
        UpdateHealthBar();
    }

    private void Update()
    {
        // Update the number of cows alive
        currentCowsAlive = cowCounter.cowsAlive;

        // Update the health bar based on the number of cows alive
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = currentCowsAlive / startingCows;
        healthBar.fillAmount = healthPercentage;
    }
}
