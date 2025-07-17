using UnityEngine;

public class StationTrigger : MonoBehaviour
{
    // This script + object is currently not being used, may delete later
    // It was created to handle station triggers, but the functionality is now in PlayerInteract.cs
    Station station; // Reference to the parent station object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        station = transform.parent.GetComponent<Station>(); // Get the parent station object
        if (station == null)
        {
            Debug.LogError("Parent station object not found for " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // Not really being used right now
        // Debug.Log("OnTriggerEnter called for " + gameObject.name + " with collider: " + other.name);
        // if (other.CompareTag("Player"))
        // {
        //     // Optionally, you can show a UI prompt or highlight the station
        //     Debug.Log("Player touched station: " + gameObject.name);
        //     //station.EnterStation();  Call the EnterStation method on the parent station object
        // }
    }

    void OnTriggerStay(Collider other)
    {

    }
}
