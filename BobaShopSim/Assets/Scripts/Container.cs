using UnityEngine;

public class Container : MonoBehaviour
{
    // Base class for containers like Shaker and Cup
    public Drink drink = null; // Reference to the Drink script
    public Transform followTarget = null; // Target to follow, if needed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (followTarget != null)
        {
            // Follow the target's position
            transform.position = followTarget.position;
            transform.rotation = followTarget.rotation;
        }
    }
    
    public void OnInteract(Transform player)
    {
        Debug.Log("Interacting with container: " + gameObject.name);
        // Grab container by assigning it to follow target
        if (followTarget == null)
        {
            followTarget = player; // Set the player as the follow target
        }
    }
    
    public void OnDrop()
    {
        // To be called when the container is dropped (reset velocity because it goes wacky)
        Debug.Log("Dropping container: " + gameObject.name);

        if (followTarget != null)
        {
            followTarget = null; // Stop following
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // Reset velocity
                rb.angularVelocity = Vector3.zero; // Reset angular velocity
            }
        }
    }
}
