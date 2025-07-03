using UnityEngine;

public class Cup : Container
{
    // Basically same as shaker but only contains a drink
    // Inherits from Container to use the drink and followTarget properties

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update(); // Call the base class Update method to handle following target
    }
}
