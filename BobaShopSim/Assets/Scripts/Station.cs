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

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
            // Optionally, you can show a UI prompt or highlight the station
            Debug.Log("Player touched station: " + gameObject.name);

            EnterStation();
        }
    }

    public void EnterStation()
    {
        // Logic for entering the station
        // Locks the player into position and rotation, enables interaction, etc.
        Debug.Log("Entering station: " + gameObject.name);
        
        player.GetComponent<PlayerMovement>().followTarget = lockPosition; // Set the station as the follow target
    }
}
