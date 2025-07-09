using UnityEngine;
using UnityEngine.UIElements;

public class Station : MonoBehaviour
{
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
        //detects if key is pressed and if user is already locked into station or not
        if (Input.GetKeyDown(KeyCode.E) && player.GetComponentInParent<LockPlayer>().followTarget == null) //detects if key is pressed and user is already at station
        {
            EnterStation();
        }
        //same as above, just to exit station. 
        else if (Input.GetKeyDown(KeyCode.Escape) && player.GetComponentInParent<LockPlayer>().followTarget == lockPosition)
        {
            ExitStation();
        }
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
    }

    public void ExitStation()
    {
        Debug.Log("Exiting Station" + gameObject.name);

        player.GetComponentInParent<LockPlayer>().followTarget = null; //set target to none
    }
}
