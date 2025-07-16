using UnityEngine;
using UnityEngine.AI;

public class CustomerNavAgent : MonoBehaviour
{
    public Transform target;
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
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
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

    // void ChangeSpeed()
    // {
    //     // Change speed randomly periodically
    //     agent.speed = Random.Range(2.0f + grit, 4.0f + aggression);
    //     // Debug.Log("New speed: " + agent.speed);
    // }
}
