using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeController : MonoBehaviour
// Wind Sound Script
{
    // wow what complex variables i wonder what these do
    public AudioClip audioClip;
    public float maxVolume = 1.0f;
    public float minVolume = 0.1f;
    public float maxVelocity = 10.0f;
    public float minVelocity;
    //actually wasnt sure if i need both Audioclip and AudioSorce
    private AudioSource audioSource;
    private Rigidbody rigidBody;

    private void Start()
    {
        //setting up clip not in inspector and make sure it loops
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.volume = minVolume;

        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //current velocity translates to get a clamped value to a slider and then our relative velocity between our range becomes the volume %
        float currentVelocity = rigidBody.velocity.magnitude;
        float volume = (currentVelocity - minVelocity) / (maxVelocity - minVelocity);
        volume = Mathf.Clamp(volume, 0.0f, 1.0f);
        volume = Mathf.Lerp(minVolume, maxVolume, volume);
        audioSource.volume = volume;
    }
}
