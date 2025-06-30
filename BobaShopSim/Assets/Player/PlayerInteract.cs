using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera playerCamera;       // Reference to camera
    public float maxDistance = 100f;  // Raycast length
    public LayerMask layerMask;       // (Optional) Layer filtering
    GameObject lastSeen = null; // Reference to the last seen outline component

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
            Debug.Log("Looking at: " + hit.collider.gameObject.name);
            // You can do something with hit.collider or hit.transform

            if (hit.collider)
            {
                if (lastSeen != null && lastSeen != hit.collider.gameObject)
                {
                    // Disable outline on the previously seen object
                    Outline lastOutline = lastSeen.GetComponent<Outline>();
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
                lastSeen = hit.collider.gameObject; // Store the last seen object
            }
        }
        else
        {
            // If nothing is hit, disable the outline on the last seen object
            if (lastSeen != null)
            {
                Outline lastOutline = lastSeen.GetComponent<Outline>();
                if (lastOutline != null)
                {
                    lastOutline.ToggleOutline(false);
                }
                lastSeen = null; // Clear the reference
            }
        }
    }

    void SelectObject()
    {
        // Logic to select an object
        // This could involve raycasting or checking for nearby interactable objects
    }
}
