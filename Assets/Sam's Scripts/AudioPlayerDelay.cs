using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerDelay : MonoBehaviour
{
        public AudioSource audioSource; // The audio source to play
        public float delay = 5.0f; // The delay in seconds between each play

        private float timer = 0.0f;

        private void Update()
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Check if it's time to play the audio
            if (timer >= delay)
            {
                // Reset the timer
                timer = 0.0f;

                // Play the audio
                audioSource.Play();
            }
        }
}
