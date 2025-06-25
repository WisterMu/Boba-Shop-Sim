using UnityEngine;

public class LockPlayer : MonoBehaviour
{
    // Locks the player in position and rotation when entering a station or similar scenario
    public Transform followTarget = null; // Target to follow, if needed

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
