using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // AudioManager is a singleton to manage audio playback
    // It should be attached to a GameObject in the scene that persists across scenes
    // Handles background music and volume control for now
    // Note that the AudioListener is managed by Unity, so we don't need to create one here

    [SerializeField]
    private float volume = 1.0f; // Default volume level
    [SerializeField]
    AudioSource audioSource; // Reference to the AudioSource component
                             // Maybe create list of sources/clips to play multiple sounds at once
                             // Or keep this source reserved for background music or ambient sounds, add sources to the specific objects that need sound effects

    // Singleton instance
    public static AudioManager Instance { get; private set; }
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this); // Do NOT destroy gameObject if others are on it!
            return;
        }

        Instance = this;
        // Don't call DontDestroyOnLoad here if shared GameObject handles it
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioListener.volume = volume; // Set the initial volume level

        audioSource = GetComponent<AudioSource>();
        // Set audio source to contain sound clip
        audioSource.clip = Resources.Load<AudioClip>("Audio/jixaw-metal-pipe-falling-sound"); // Load your audio clip from Resources
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic for audio playback can be added here if needed

        // For now, randomly plays a sound
        if (Random.Range(0f, 1f) < 0.0005f) // 0.05% chance to play sound each frame
        {
            // Randomize volume (for funzies)
            float u = Random.value; // uniform random in [0, 1]
            float skew = 3.0f; // Skew factor, adjust to change the distribution
            float skewed = u < 0.5f
                ? Mathf.Pow(u * 2, skew) / 2f        // favors 0
                : 1 - Mathf.Pow((1 - u) * 2, skew) / 2f; // favors 1
            audioSource.volume = skewed;
            // Play the sound
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            Debug.Log("Playing sound at " + Time.time);
            audioSource.Play();
        }
    }

    // Sets the volume level for the AudioListener
    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        AudioListener.volume = volume; // Update the AudioListener's volume
        Debug.Log("Audio volume set to: " + volume);
    }
}
