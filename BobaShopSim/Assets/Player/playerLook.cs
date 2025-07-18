using Unity.Mathematics;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //variables
    public float mouseSensitivity = 100f;
    [SerializeField] Transform playerBody;
    float xRotation = 0f; //Makes sure camera doesn't spin without player
    public bool isLocked { get; private set; } = false; //Locks camera position and rotation when true
    Transform lockedPosition; //Position to lock camera to when isLocked is true
    [SerializeField] Vector3 cameraOffset = new Vector3(0f, 0.53f, 0f); // Reference to the camera offset


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locks cursor into  seperate frame
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked) //If camera is not locked, allow player to look around
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //get horizontal rotation
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //get vertical rotation

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //clamps limit of vertical rotation to between -90 and 90 degrees

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //puts rotation into effect
            playerBody.Rotate(Vector3.up * mouseX); //makes player treat the camera direction as new forward direction
        }
    }

    // LateUpdate is called after all Update methods have been called
    void LateUpdate()
    {
        if (isLocked)
        {
            transform.position = lockedPosition.position;
            transform.rotation = lockedPosition.rotation;
        }
        else
        {
            // Ensure the camera maintains the offset from the player body
            transform.position = playerBody.position + cameraOffset;
        }
    }

    // Method to lock the camera to a specific position and rotation
    public void LockCamera(Transform position)
    {
        isLocked = true; // Set the lock state to true
        lockedPosition = position; // Set the locked position to the provided transform
        transform.position = lockedPosition.position; // Immediately set the camera position
        transform.rotation = lockedPosition.rotation; // Immediately set the camera rotation
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
    }

    // Method to unlock the camera
    public void UnlockCamera()
    {
        isLocked = false; // Set the lock state to false
        lockedPosition = null; // Clear the locked position
        Cursor.lockState = CursorLockMode.Locked; // Re-lock the cursor
    }

}
