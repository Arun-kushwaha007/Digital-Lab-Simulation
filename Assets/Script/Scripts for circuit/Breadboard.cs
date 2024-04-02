using UnityEngine;

public class Breadboard : MonoBehaviour
{
    // Reference to the power rails of the breadboard
    public GameObject positiveRail;
    public GameObject negativeRail;

    // Layer mask for detecting components and wires
    public LayerMask componentLayer;

    // Variables to track the currently selected component and wire
    private GameObject selectedComponent;
    private GameObject selectedWire;

    void Update()
    {
        // Check for mouse input to interact with the breadboard
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a raycast to detect objects under the mouse cursor
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, componentLayer))
            {
                GameObject hitObject = hit.collider.gameObject;

                // Check if the hit object is a component
                if (hitObject.CompareTag("Component"))
                {
                    // If a component is clicked, select it
                    selectedComponent = hitObject;
                    selectedWire = null;
                }
                // Check if the hit object is a wire
                else if (hitObject.CompareTag("Wire"))
                {
                    // If a wire is clicked, select it
                    selectedWire = hitObject;
                    selectedComponent = null;
                }
                else
                {
                    // If neither a component nor a wire is clicked, clear the selection
                    selectedComponent = null;
                    selectedWire = null;
                }
            }
        }

        // Check if a component is selected and the left mouse button is clicked
        if (selectedComponent != null && Input.GetMouseButtonDown(0))
        {
            // Insert the selected component into the breadboard
            InsertComponent(selectedComponent);
        }

        // Check if a wire is selected and the left mouse button is clicked
        if (selectedWire != null && Input.GetMouseButtonDown(0))
        {
            // Connect the selected wire to the breadboard's power rails
            ConnectWire(selectedWire);
        }
    }

    // Method to insert a component into the breadboard
    void InsertComponent(GameObject component)
    {
        // Insert logic for inserting components into the breadboard here
        // You may need to determine the position and orientation of the component on the breadboard
    }

    // Method to connect a wire to the breadboard's power rails
    void ConnectWire(GameObject wire)
    {
        // Connect logic for connecting wires to the breadboard's power rails here
        // You may need to determine which rail (positive/negative) the wire should connect to
    }
}
