using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public Transform queueTarget; // The target position for the customer to queue at
    [SerializeField]
    float queueDistance = 1.0f; // Distance to maintain from each other in the queue
    private List<CustomerNavAgent> customers = new List<CustomerNavAgent>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetCustomerQueue(); // Initialize the customer queue
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            if (customers[i] == null)
            {
                customers.RemoveAt(i);
                i--;
                continue;
            }

            // Update the destination for each customer in the queue
            Vector3 targetPosition = queueTarget.position + new Vector3(0, 0, i * queueDistance);
            customers[i].SetDestination(targetPosition);
        }
    }

    // Resets customer list using all CustomerNavAgent components in the scene
    public void ResetCustomerQueue()
    {
        // Clear the current list of customers
        customers.Clear();

        // Get all CustomerNavAgent components in the scene
        CustomerNavAgent[] agents = FindObjectsByType<CustomerNavAgent>(FindObjectsSortMode.None);
        foreach (CustomerNavAgent agent in agents)
        {
            if (agent != null)
            {
                customers.Add(agent);
            }
        }
    }
}
