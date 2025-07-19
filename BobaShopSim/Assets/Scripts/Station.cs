using UnityEngine;
using UnityEngine.UIElements;

public class Station : MonoBehaviour
{
    // The functional part of the station, handles player interactions and station logic
    BoxCollider stationCollider; // Collider for the station
    public bool isActive { get; private set; } = false; // Indicates if the station is active
    GameObject player; // Reference to the player
    PlayerInteract playerInteract; // Reference to the player interact script
    [SerializeField]
    private Transform lockPosition; // Position to lock the player to when entering the station  
    [SerializeField]
    private Transform lockCamera; // Position to lock the camera to when entering the station  
    [SerializeField]
    private Transform itemStartPosition; // Position to start the item at when entering the station
    Camera mainCamera; // Reference to the main camera  
    PlayerLook playerLook; // Reference to the player look script
    LockPlayer lockPlayer; // Reference to the lock player script

    // public GameObject cursor; // Reference to the cursor GameObject
    public Vector3? hitPoint = null;
    public Container currentContainer; // Reference to the container currently being worked on
    public GameObject heldItem; // Reference to the item currently held by the player (clicked on)


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

        playerInteract = player.GetComponentInParent<PlayerInteract>(); // Get the player interact script from the player
        if (playerInteract == null)
        {
            Debug.LogError("PlayerInteract script not found on the player!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit moveHit, Mathf.Infinity, LayerMask.GetMask("InteractionPlane")))
            {
                Debug.DrawRay(ray.origin, ray.direction * moveHit.distance, Color.yellow);
                // Debug.Log("Mouse hit position: " + hit.point + " on " + hit.collider.name);
                // cursor.transform.position = hit.point; // Move the cursor to the hit point
                hitPoint = moveHit.point;

                if (heldItem != null)
                {
                    // If the player is holding an item, update its position to the hit point
                    heldItem.transform.position = moveHit.point + Vector3.up * 0.2f; // Offset slightly above the hit point
                }
            }
            else
            {
                hitPoint = null; // Reset hit point if nothing is hit
            }

            if (Physics.Raycast(ray, out RaycastHit interactHit, Mathf.Infinity, LayerMask.GetMask("Interactable")))
            {
                // If the player is looking at an interactable object, check for holding down click
                if (Input.GetButtonDown("Fire1")) // Assuming "Fire1" is the interaction button
                {
                    if (heldItem == null)
                    {
                        // Pick up the interactable object into heldItem
                        GameObject hitObject = interactHit.collider.gameObject;
                        Debug.Log("Station: Clicked on " + hitObject.name);

                        // Sets held item to the interactable object
                        heldItem = hitObject;
                    }
                }
                else if (Input.GetButtonUp("Fire1"))  // Released hold click
                {
                    if (heldItem != null)
                    {
                        heldItem = null; // Drop the held item at this position
                    }
                }
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

        // Takes item from player
        if (playerInteract.heldContainer != null)
        {
            currentContainer = playerInteract.heldContainer; // Get the held item from the player interact script
            playerInteract.DropContainer(); // Clear the held container reference in PlayerInteract
            currentContainer.transform.position = itemStartPosition.position; // Set the container's position to the station's position
        }
        else
        {
            Debug.Log("No item held by player to transfer to station.");
        }
    }

    public void ExitStation()
    {
        Debug.Log("Exiting Station" + gameObject.name);

        lockPlayer.UnlockPosition(); //set target to none
        playerLook.UnlockCamera(); // Lock the camera to the station's position;
        isActive = false; // Set the station to inactive

        // Return the container being worked on to the player
        if (currentContainer != null)
        {
            playerInteract.GrabContainer(currentContainer); // Call the GrabContainer method to set the held item in PlayerInteract
            heldItem = null; // Clear the held item reference in the station
            currentContainer = null; // Clear the current container reference
            Debug.Log("Returned item to player: " + currentContainer.name);
        }
        else
        {
            Debug.Log("No item to return to player.");
        }
    }

    void OnDrawGizmos()
    {
        if (hitPoint.HasValue)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hitPoint.Value, 0.1f); // Draw a sphere at the hit point
        }
    }
}
