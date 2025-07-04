using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager is a singleton to manage game state, saving, and loading
    // It should be attached to a GameObject in the scene that persists across scenes
    
    // Singleton instance
    public static GameManager Instance { get; private set; }


    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SaveGame()
    {
        // Implement save game logic here
        Debug.Log("Saving game...");
        // Debug.Log("Game saved!");
    }
    
    void LoadGame()
    {
        // Implement load game logic here
        Debug.Log("Loading game...");
        // Debug.Log("Game loaded!");
    }
}
