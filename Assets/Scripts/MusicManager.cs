using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic;

    private static MusicManager instance = null;
    private AudioSource audioSource;

    void Awake()
    {
        // Ensure that only one instance of MusicManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading new scenes
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate MusicManager
            return;
        }

        // Set up the AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Loop the music
        audioSource.playOnAwake = false; // Ensure the music doesn't start playing on Awake

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}