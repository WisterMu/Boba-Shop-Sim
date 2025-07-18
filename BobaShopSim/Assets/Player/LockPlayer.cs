using UnityEngine;

public class LockPlayer : MonoBehaviour
{
    // Locks the player in position and rotation when entering a station or similar scenario
    private Transform followTarget = null; // Target to follow, if needed
    public bool isLocked { get; private set; } = false; // Indicates if the player is locked in position
    Rigidbody rb; // Reference to the player's Rigidbody for physics interactions

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on the player! Make sure the player has a Rigidbody component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null)  // Lock player in position (should also disable controls)
        {
            // Follow the target's position
            transform.position = followTarget.position;
            transform.rotation = followTarget.rotation;
        }
    }

    // Method to set the follow target
    public void LockPosition(Transform target)
    {
        followTarget = target; // Set the follow target to the provided transform
        transform.position = followTarget.position; // Immediately set the player position
        transform.rotation = followTarget.rotation; // Immediately set the player rotation
        rb.isKinematic = true; // Disable physics interactions while locked
        isLocked = true; // Set the lock state to true
    }

    public void UnlockPosition()
    {
        followTarget = null; // Clear the follow target
        rb.isKinematic = false; // Re-enable physics interactions
        isLocked = false; // Set the lock state to false
    }
    
    void OnDrawGizmos()
    {
        if (followTarget != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(followTarget.position, 0.1f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
    }
}
