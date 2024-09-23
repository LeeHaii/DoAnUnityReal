using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitToggle : MonoBehaviour
{
    public OrbitalVisualizer[] orbitVisualizers; // Array of OrbitVisualizer components to toggle

    // This method will be called when the button is clicked
    public void OnToggleOrbitButtonPressed()
    {
        foreach (var visualizer in orbitVisualizers)
        {
            visualizer.ToggleOrbitVisibility();
        }
    }

    public void TurnOffOrbitToggle()
    {
        foreach(var visualizer in orbitVisualizers)
        {
            visualizer.TurnOffVisibility();
        }
    }
}
