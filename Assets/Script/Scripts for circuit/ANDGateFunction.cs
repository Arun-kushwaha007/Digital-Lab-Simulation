using UnityEngine;
using TMPro;

public class ANDGateFunction : MonoBehaviour
{
    public Light lightToControl;
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    private bool button1State = false;
    private bool button2State = false;

    void Start()
    {
        // Update the button text initially based on the light state
        UpdateButtonState();
    }

    // Function to toggle the state of button 1
    public void ToggleButton1()
    {
        button1State = !button1State;
        UpdateButtonState();
        PerformANDGateOperation();
    }

    // Function to toggle the state of button 2
    public void ToggleButton2()
    {
        button2State = !button2State;
        UpdateButtonState();
        PerformANDGateOperation();
    }

    // Function to perform AND gate operation and control the light
    private void PerformANDGateOperation()
    {
        // If both buttons are active, turn on the light
        if (button1State && button2State)
        {
            lightToControl.enabled = true;
        }
        else
        {
            lightToControl.enabled = false;
        }
    }

    // Function to update the text of buttons based on their states
    private void UpdateButtonState()
    {
        button1Text.text = button1State ? "Button 1: ON" : "Button 1: OFF";
        button2Text.text = button2State ? "Button 2: ON" : "Button 2: OFF";
    }
}
