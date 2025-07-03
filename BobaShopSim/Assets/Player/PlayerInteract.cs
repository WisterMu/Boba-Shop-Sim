using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public Camera playerCamera;       // Reference to camera
    public float maxDistance = 100f;  // Raycast length
    public LayerMask layerMask;       // (Optional) Layer filtering
    [SerializeField]
    GameObject lookingAt = null; // Reference to the last seen outline component
    Input inputActions; // Input actions for player interaction
    [SerializeField]
    private Transform shakerOffset; // Reference to the shaker offset
    [SerializeField]
    Shaker heldShaker; // Reference to the held shaker component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // center of screen
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            // Debug.Log("Looking at: " + hit.collider.gameObject.name);

            OutlineRaycast(hit); // Call the method to handle outlines
        }
        else
        {
            // If nothing is hit, disable the outline on the last seen object
            if (lookingAt != null)
            {
                Outline lastOutline = lookingAt.GetComponent<Outline>();
                if (lastOutline != null)
                {
                    lastOutline.ToggleOutline(false);
                }
                lookingAt = null; // Clear the reference
            }
        }
    }

    void OutlineRaycast(RaycastHit hit)
    {
        // This method is called when an object is seen by the player
        // It can be used to enable outlines or other visual feedback
        if (hit.collider)
        {
            if (lookingAt != null && lookingAt != hit.collider.gameObject)
            {
                // Disable outline on the previously seen object
                Outline lastOutline = lookingAt.GetComponent<Outline>();
                if (lastOutline != null)
                {
                    lastOutline.ToggleOutline(false);
                }
            }
            Outline outline = hit.collider.GetComponent<Outline>();
            outline.ToggleOutline(true); // Enable outline on the object

            // // Check for input to select the object
            // if (Input.GetButtonDown("Fire1")) // Assuming "Fire1" is the interaction button
            // {
            //     SelectObject();
            // }
            lookingAt = hit.collider.gameObject; // Store the last seen object
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        // Tracks the input event
        Debug.Log("E key pressed (Interact)");
        // Do your interaction logic here
        if (lookingAt != null)
        {
            InteractWithObject(lookingAt);
        }
        else
        {
            InteractWithAir(); // If nothing is selected, interact with air
        }
    }

    void InteractWithObject(GameObject obj)
    {
        // Interaction functionality
        Debug.Log("Interacting with: " + obj.name);
        Shaker shaker = obj.GetComponent<Shaker>();
        if (shaker != null)     // is a shaker
        {
            shaker.OnInteract(shakerOffset); // Call the OnInteract method of the Shaker component
            if (heldShaker == null) // If not already holding a shaker
            {
                DropShaker(); // Drop any currently held shaker
                heldShaker = shaker; // Set the held shaker
            }
        }
    }

    void InteractWithAir()
    {
        // Interaction functionality when nothing is selected
        Debug.Log("Interacting with air.");
        DropShaker(); // Drop the shaker if it is being held
    }

    void DropShaker()
    {
        // Drop the shaker if it is being held
        if (heldShaker != null)
        {
            heldShaker.OnDrop(); // Call the OnDrop method of the Shaker component
            heldShaker = null; // Reset the held shaker
            Debug.Log("Dropped the shaker.");
        }
    }
}
