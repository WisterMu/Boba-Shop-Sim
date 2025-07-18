using UnityEngine;

public class LockPlayer : MonoBehaviour
{
    // Locks the player in position and rotation when entering a station or similar scenario
    private Transform followTarget = null; // Target to follow, if needed
    public bool isLocked { get; private set; } = false; // Indicates if the player is locked in position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        isLocked = true; // Set the lock state to true
    }

    public void UnlockPosition()
    {
        followTarget = null; // Clear the follow target
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
