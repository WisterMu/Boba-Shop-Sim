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

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {

        //variables
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        

        float movementAmount = Mathf.Abs(horizontal) + Mathf.Abs(vertical); //creates variable for combined variables

        var movementInput = new UnityEngine.Vector3(horizontal, 0, vertical).normalized; //normalizes movement

        var MovementDirection = mainCamera.transform.rotation * movementInput; //sets camera direction to be new forward

        MovementDirection.y = 0;

        if (movementAmount > 0)
        {
            transform.position += MovementDirection * WalkSpeed * Time.deltaTime; //movement and direction changes
        }
    }
}
