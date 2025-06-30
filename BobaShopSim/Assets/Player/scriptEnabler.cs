using UnityEngine;
using UnityEngine.Video;

public class scriptEnabler : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered counter trigger");
        }
        
    }
}
