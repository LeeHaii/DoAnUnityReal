using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRLookAtPlanet : MonoBehaviour
{
    public OrbitalVisualizer OrbitalVisualizer;
    public Transform planet; // Assign the planet you want the XR Rig to look at
    public Transform cameraTransform; // Reference to the camera or headset transform
 
    void Update()
    {
        if (OrbitalVisualizer.IsVisible)
        {
            OrbitalVisualizer.IsVisible = false;
        }
        // Make the XR Rig constantly look at the planet by adjusting the Y-axis rotation
        Vector3 direction = planet.position - cameraTransform.position;
        direction.y = 0; // Lock the rotation to the horizontal plane (so only the Y-axis is affected)
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
