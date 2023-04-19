using UnityEngine;

public class PlayAudioOnMoveUp : MonoBehaviour
{
    public AudioClip audioClip;
    public float triggerDistance = 10f;

    private AudioSource audioSource;
    private float initialY;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialY = transform.position.y;
    }

    void Update()
    {
        float currentY = transform.position.y;
        float distanceTravelled = currentY - initialY;

        if (distanceTravelled >= triggerDistance && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
