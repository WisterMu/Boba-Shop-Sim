using UnityEngine;

public class StationTrigger : MonoBehaviour
{
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
        Debug.Log("OnTriggerEnter called for " + gameObject.name + " with collider: " + other.name);
        if (other.CompareTag("Player"))
        {
            // Optionally, you can show a UI prompt or highlight the station
            Debug.Log("Player touched station: " + gameObject.name);
            //station.EnterStation();  Call the EnterStation method on the parent station object
        }
    }
}
