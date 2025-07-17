using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager is a singleton to manage game state, saving, and loading
    // It should be attached to a GameObject in the scene that persists across scenes

    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Menu management
    [SerializeField]
    List<Canvas> menus = new List<Canvas>(); // List of all menus in the game (set in the inspector)


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

    void Start()
    {
        // Initialize menus
        SetActiveMenu("MainMenu"); // Set the default active menu
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveMenu(string menuName)
    {
        // Switch between different menus
        for (int i = 0; i < menus.Count; i++)
        {
            if (menus[i].name == menuName)
            {
                menus[i].gameObject.SetActive(true); // Activate the specified menu
            }
            else
            {
                menus[i].gameObject.SetActive(false); // Deactivate all other menus
            }
        }
    }

    public void StartGame()
    {
        // Implement start game logic here
        Debug.Log("Starting game...");
        // Debug.Log("Game started!");

        // Swap scene to the main game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        SetActiveMenu("None"); // Hide all menus when starting the game
    }

    public void SaveGame()
    {
        // Implement save game logic here
        Debug.Log("Saving game...");
        // Debug.Log("Game saved!");
    }

    public void LoadGame()
    {
        // Implement load game logic here
        Debug.Log("Loading game...");
        // Debug.Log("Game loaded!");
    }
    
    public void QuitGame()
    {
        // Implement quit game logic here
        Debug.Log("Quitting game...");
        Application.Quit(); // Quit the application
    }
}
