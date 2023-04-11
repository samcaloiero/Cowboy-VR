using UnityEngine;

public class PlayAudioOnMoveUp : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;

    private bool wasMovingUp = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool isMovingUp = transform.position.y > transform.position.y + 0.01f;

        if (isMovingUp && !wasMovingUp)
        {
            source.PlayOneShot(clip);
        }

        wasMovingUp = isMovingUp;
    }
}