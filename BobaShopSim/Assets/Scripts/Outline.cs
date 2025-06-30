using UnityEngine;

public class Outline : MonoBehaviour
{
    Renderer rend = null; // Renderer component to access material properties
    Material mat = null; // Material to modify properties

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;

        if (mat == null)
        {
            Debug.LogError("No material found on the Shaker object.");
            return;
        }

        // Initialize the material properties
        mat.SetFloat("_Outline_Width", 0f); // Disable outline on start
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ToggleOutline(bool enable)
    {
        if (mat != null)
        {
            mat.SetFloat("_Outline_Width", enable ? 60f : 0f); // Enable or disable outline
        }
    }
}
