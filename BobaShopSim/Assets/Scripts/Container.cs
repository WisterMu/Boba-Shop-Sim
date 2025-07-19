using UnityEngine;

public class Container : MonoBehaviour
{
    // Base class for containers like Shaker and Cup
    public Drink drink = null; // Reference to the Drink script
    public Transform followTarget = null; // Target to follow, if needed
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        rb = GetComponentInParent<Rigidbody>(); // Get the Rigidbody component attached to the container
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on the container! Make sure the container has a Rigidbody component.");
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (followTarget != null)
        {
            // Follow the target's position
            transform.position = followTarget.position;
            transform.rotation = followTarget.rotation;

            // Disable physics interactions while following
            rb.isKinematic = true;
        }
        else
        {
            // Re-enable physics interactions when not following
            rb.isKinematic = false;
        }
    }
    
    public void OnInteract(Transform target)
    {
        Debug.Log("Interacting with container: " + gameObject.name);
        // Grab container by assigning it to follow target
        if (followTarget == null)
        {
            followTarget = target; // Set the target transform as the follow target
        }
    }
    
    public void OnDrop()
    {
        // To be called when the container is dropped (reset velocity because it goes wacky)
        Debug.Log("Dropping container: " + gameObject.name);

        if (followTarget != null)
        {
            followTarget = null; // Stop following
            rb.linearVelocity = Vector3.zero; // Reset velocity
            rb.angularVelocity = Vector3.zero; // Reset angular velocity
        }
    }
}
