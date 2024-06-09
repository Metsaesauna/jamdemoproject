using UnityEngine;

public class GodModeToggle : MonoBehaviour
{
    // Define the sequence to be detected
    private string inputSequence = "seppoonbi";
    private string currentInput = "";

    // Boolean to be changed when the sequence is detected
    public bool sequenceDetected = false;

    void Update()
    {
        // Check for key inputs and update the current input string
        foreach (char c in Input.inputString)
        {
            currentInput += c;

            // If the current input exceeds the length of the target sequence, trim it
            if (currentInput.Length > inputSequence.Length)
            {
                currentInput = currentInput.Substring(1);
            }

            // Check if the current input matches the target sequence
            if (currentInput == inputSequence)
            {
                sequenceDetected = true;
                Debug.Log("Input sequence detected!");
                // Optionally, you can reset the current input after detection
                currentInput = "";
            }
        }
    }
}