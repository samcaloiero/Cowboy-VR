using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawner : MonoBehaviour
{
    // Reference to the player game object
    public GameObject player;

    // Reference to the spawn point game object
    public Transform spawnPoint;

    // Reference to the audio clip to play when the player dies
    public AudioClip deathSound;

    // Number of times the player has died
    private int numDeaths = 0;

    // Tag of the enemy game object
    private const string ENEMY_TAG = "Enemy";

    // Handle collisions with the enemy game object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ENEMY_TAG)
        {
            numDeaths++;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            if (numDeaths >= 3)
            {
                SceneManager.LoadScene("Lose Scene");
            }
            else
            {
                player.transform.position = spawnPoint.position;
            }
        }
    }
}