using Unity.Mathematics;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    //variables
    public float mouseSensitivity = 100f;
    [SerializeField] Transform playerBody;
    float xRotation = 0f; //Makes sure camera doesn't spin without player


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locks cursor into  seperate frame
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    
}
