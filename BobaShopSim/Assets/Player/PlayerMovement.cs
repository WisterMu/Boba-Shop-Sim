using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //variables
    Rigidbody rb;
    public float WalkSpeed = 5f;
    public float SprintMultiplier = 2;
    public Transform mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UnityEngine.Vector3 movement = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + movement * WalkSpeed * Time.fixedDeltaTime);

        movement = Camera.main.transform.TransformDirection(movement);
        movement = UnityEngine.Vector3.ProjectOnPlane(movement, UnityEngine.Vector3.up);

        UnityEngine.Vector3 camDir = mainCamera.transform.forward;
        camDir = UnityEngine.Vector3.ProjectOnPlane(camDir, UnityEngine.Vector3.up);

        transform.forward = camDir;
    }
}
