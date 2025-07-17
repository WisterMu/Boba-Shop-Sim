using UnityEngine;
using UnityEngine.AI;

public class CustomerNavAgent : MonoBehaviour
{
    public Transform followtarget;
    Vector3 destination;
    NavMeshAgent agent = null;
    [SerializeField]
    float speed = 3.5f; // Default speed
    // float aggression = 0.5f; // Default aggression level
    // float grit = 0.5f; // Default grit level
    // public float fatigue = 1f; // Default fatigue level

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        agent.speed = speed;

        // // Set FixedUpdate to run at a specific interval
        // InvokeRepeating("ChangeSpeed", 0f, 2f); // Uncomment if you want to change speed periodically

        // // Randomly set aggression and grit
        // aggression = Random.Range(0.0f, 1.0f);
        // grit = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (followtarget == null)
        {
            // If no follow target is set, go to destination
            if (Vector3.Distance(destination, transform.position) > 1.0f)
            {
                agent.destination = destination;
            }
            else
            {
                // If close enough to destination, stop moving
                agent.isStopped = true;
            }
            return;
        }
        else
        {
            if (Vector3.Distance(destination, followtarget.position) > 1.0f)
            {
                destination = followtarget.position;
                agent.destination = destination;
            }
        }


        // // If moving, reduce fatigue
        // if (agent.remainingDistance > 1f)
        // {
        //     // Change fatigue over time by a random amount, to a minimum of 0.2
        //     fatigue -= Time.deltaTime * Random.Range(0.05f, 0.15f);
        //     if (fatigue < 0.2f)
        //     {
        //         fatigue = 0.2f;
        //     }
        // }
        // else
        // {
        //     // If not moving, increase fatigue
        //     fatigue += Time.deltaTime * Random.Range(0.05f, 0.15f);
        //     if (fatigue > 1f)
        //     {
        //         fatigue = 1f;
        //     }
        // }
    }

    public void SetFollowTarget(Transform newFollowTarget)
    {
        followtarget = newFollowTarget;
        destination = followtarget.position;
        agent.destination = destination;
    }

    // Set a new destination for the agent (disables following target)
    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
        agent.destination = destination;
        followtarget = null; // Clear follow target
        agent.isStopped = false; // Ensure the agent is not stopped
    }

    // void ChangeSpeed()
    // {
    //     // Change speed randomly periodically
    //     agent.speed = Random.Range(2.0f + grit, 4.0f + aggression);
    //     // Debug.Log("New speed: " + agent.speed);
    // }
}
