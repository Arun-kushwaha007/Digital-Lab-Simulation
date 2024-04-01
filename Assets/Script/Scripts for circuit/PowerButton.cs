using UnityEngine;
using TMPro;

public class PowerButton : MonoBehaviour
{
    public Light lightToControl;
    public TextMeshProUGUI toggleButton;
    private bool isLightOn = false;

    void Start()
    {
        // Update the button text initially based on the light state
        UpdateButtonText();
    }

    // Function to toggle the light on and off
    public void ToggleLight()
    {
        // Toggle the light state
        isLightOn = !isLightOn;

        // Update the light state
        lightToControl.enabled = isLightOn;

        // Update the button text
        UpdateButtonText();
    }

    // Function to update the button text based on the light state
    private void UpdateButtonText()
    {
        if (isLightOn)
        {
            toggleButton.text = "Turn Off";
        }
        else
        {
            toggleButton.text = "Turn On";
        }
    }
}
