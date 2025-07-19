using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Shaker : Container
{
    // Shaker class inherits from Container
    // It can create and clear a drink instance

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update(); // Call the base class Update method to handle following target
    }

    // Create a new drink instance if it doesn't exist (should only be allowed on shakers)
    public void CreateDrink()
    {
        if (drink == null)
        {
            drink = gameObject.AddComponent<Drink>();
        }
    }

    // Empty the drink instance (should only be allowed on shakers)
    public void ClearDrink()
    {
        if (drink != null)
        {
            Destroy(drink);
            drink = null;
        }
    }
}
