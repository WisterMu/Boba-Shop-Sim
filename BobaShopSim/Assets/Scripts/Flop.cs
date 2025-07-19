using UnityEngine;

public class Flop : MonoBehaviour
{
    Rigidbody rb; // Reference to the Rigidbody component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        // Applies force to rigidbody to simulate a flop effect every few seconds
        if (Time.time % 5 < 0.1f) // Adjust the timing as needed
        {
            rb.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 1f, ForceMode.Impulse); // Adjust the force as needed

            // ALso rotate the object a random amount
            rb.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 1f, ForceMode.Impulse); // Random torque
        }
    }
}
