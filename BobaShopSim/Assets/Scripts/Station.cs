using UnityEngine;
using UnityEngine.UIElements;

public class Station : MonoBehaviour
{
    // The functional part of the station, handles player interactions and station logic
    BoxCollider stationCollider; // Collider for the station
    public bool isActive = false; // Indicates if the station is active
    GameObject player; // Reference to the player
    [SerializeField]
    private Transform lockPosition; // Position to lock the player to when entering the station    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Find the player by tag
    }

    // Update is called once per frame
    void Update()
    {
        // Commented out because it bugs out with multiple stations
        // Moved functionality into PlayerInteract.cs
        // //detects if key is pressed and if user is currently at the station trigger
        // if (Input.GetKeyDown(KeyCode.E)) //detects if key is pressed
        // {
        //     EnterStation();
        // }
        // //same as above, just to exit station. 
        // else if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     ExitStation();
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //isActive = true;
            // Optionally, you can show a UI prompt or highlight the station
            Debug.Log("Player touched station: " + gameObject.name);

            //EnterStation(); <-- 7/8/25 Commented out because of "E" functionality
        }
    }

    public void EnterStation()
    {
        // Logic for entering the station
        // Locks the player into position and rotation, enables interaction, etc.

        Debug.Log("Entering station: " + gameObject.name);

        player.GetComponentInParent<LockPlayer>().followTarget = lockPosition; // Set the station as the follow target
        isActive = true; // Set the station to active
    }

    public void ExitStation()
    {
        Debug.Log("Exiting Station" + gameObject.name);

        player.GetComponentInParent<LockPlayer>().followTarget = null; //set target to none
        isActive = false; // Set the station to inactive
    }
}
