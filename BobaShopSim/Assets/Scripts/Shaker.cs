using Unity.Mathematics;
using UnityEngine;

public class Shaker : MonoBehaviour
{

    public Drink drink = null; // Reference to the Drink script
    public Transform followTarget = null; // Target to follow, if needed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null)
        {
            // Follow the target's position
            transform.position = followTarget.position;
            transform.rotation = followTarget.rotation;
        }
    }

    public void CreateDrink()
    {
        if (drink == null)
        {
            drink = gameObject.AddComponent<Drink>();
        }
    }

    public void ClearDrink()
    {
        if (drink != null)
        {
            Destroy(drink);
            drink = null;
        }
    }

    public void OnInteract(Transform player)
    {
        // Grab shaker by assigning it to follow target
        if (followTarget == null)
        {
            followTarget = player; // Set the player as the follow target
        }
        else
        {
            followTarget = null; // If already following, stop following
        }

    }
    
    public void OnDrop()
    {
        // To be called when the shaker is dropped (reset velocity because it goes wacky)

        // Drop Shaker
        Rigidbody rb = GetComponent<Rigidbody>();

        if (followTarget != null)
        {
            followTarget = null; // Stop following
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // Reset velocity
                rb.angularVelocity = Vector3.zero; // Reset angular velocity
            }
        }
    }
}
