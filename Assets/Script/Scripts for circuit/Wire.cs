using UnityEngine;

public class Wire : MonoBehaviour
{
    public LayerMask componentLayer; // Layer mask for detecting circuit components
    public Material connectedMaterial; // Material for the wire when connected
    public Material disconnectedMaterial; // Material for the wire when disconnected

    private bool isConnected = false; // Flag to track whether the wire is connected

    private Vector3 startPoint; // Starting point of the wire
    private Vector3 endPoint; // Ending point of the wire

    private LineRenderer lineRenderer; // LineRenderer component for drawing the wire

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = disconnectedMaterial;
        lineRenderer.positionCount = 2; // Two points for the wire
    }

    void Update()
    {
        if (!isConnected)
        {
            // If the wire is not connected, update the end point of the wire to the current mouse position
            endPoint = GetMouseWorldPosition();
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPoint);
        }

        // Check for mouse input to connect/disconnect the wire
        if (Input.GetMouseButtonDown(0))
        {
            if (!isConnected)
            {
                // If the wire is not connected and the left mouse button is clicked, try to connect the wire
                TryConnectWire();
            }
            else
            {
                // If the wire is already connected and the left mouse button is clicked, disconnect the wire
                DisconnectWire();
            }
        }
    }

    void TryConnectWire()
    {
        // Cast a ray from the current mouse position to detect circuit components
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, componentLayer))
        {
            // If the ray hits a component, connect the wire to it
            endPoint = hit.point;
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPoint);
            lineRenderer.material = connectedMaterial;
            isConnected = true;
        }
    }

    void DisconnectWire()
    {
        // Disconnect the wire by resetting its properties
        lineRenderer.material = disconnectedMaterial;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, startPoint);
        isConnected = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        // Get the current mouse position in world coordinates
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
