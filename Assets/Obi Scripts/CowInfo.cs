using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowInfo : MonoBehaviour
{
    
    public CowHealthBar cowHealthBar;  // Reference to the health bar slider script

    private void Start()
    {
        // Find the Cow Health Bar slider object in the scene
        cowHealthBar = GameObject.Find("Cow Health Bar").GetComponent<CowHealthBar>();
    }

    private void OnDestroy()
    {
        // Call the Cow Health Bar script to decrease the slider value
        cowHealthBar.CowDied();
    }
}

