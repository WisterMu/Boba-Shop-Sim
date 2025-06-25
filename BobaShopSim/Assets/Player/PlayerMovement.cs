using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //variables
    public float WalkSpeed = 5f;
    public float SprintMultiplier = 2;
    public float MouseSensitivityX = 1f;
    public float MouseSensitivityY = 1f;
    public Transform mainCamera;
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
}
