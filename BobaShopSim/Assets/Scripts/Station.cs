using UnityEngine;
using UnityEngine.UIElements;

public class Station : MonoBehaviour
{
    // The functional part of the station, handles player interactions and station logic
    BoxCollider stationCollider; // Collider for the station
    public bool isActive { get; private set; } = false; // Indicates if the station is active
    GameObject player; // Reference to the player
    [SerializeField]
    private Transform lockPosition; // Position to lock the player to when entering the station  
    [SerializeField]
    private Transform lockCamera; // Position to lock the camera to when entering the station  
    Camera mainCamera; // Reference to the main camera  
    PlayerLook playerLook; // Reference to the player look script
    LockPlayer lockPlayer; // Reference to the lock player script
    public GameObject cursor; // Reference to the cursor GameObject


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Find the player by tag
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
        mainCamera = Camera.main; // Get the main camera
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found! Make sure there is a camera tagged as 'MainCamera'.");
        }

        playerLook = mainCamera.GetComponent<PlayerLook>(); // Get the player look script from the camera
        if (playerLook == null)
        {
            Debug.LogError("PlayerLook script not found on the main camera!");
        }

        lockPlayer = player.GetComponentInParent<LockPlayer>(); // Get the lock player script from the player
        if (lockPlayer == null)
        {
            Debug.LogError("LockPlayer script not found on the player!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = LayerMask.GetMask("Interactable"); // Define the layer mask for interactable objects
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
                Debug.Log("Mouse hit position: " + hit.point + " on " + hit.collider.name);
                cursor.transform.position = hit.point; // Move the cursor to the hit point
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //isActive = true;
            // Optionally, you can show a UI prompt or highlight the station
            Debug.Log("Player touched station: " + gameObject.name);

            //EnterStation(); <-- 7/8/25 Commented out because of "E" functionality
        }
    }

    public void EnterStation()
    {
        // Logic for entering the station
        // Locks the player into position and rotation, enables interaction, etc.

        Debug.Log("Entering station: " + gameObject.name);

        lockPlayer.LockPosition(lockPosition); // Set the station as the follow target
        playerLook.LockCamera(lockCamera); // Lock the camera to the station's position;
        isActive = true; // Set the station to active
    }

    public void ExitStation()
    {
        Debug.Log("Exiting Station" + gameObject.name);

        lockPlayer.UnlockPosition(); //set target to none
        playerLook.UnlockCamera(); // Lock the camera to the station's position;
        isActive = false; // Set the station to inactive
    }
}
