using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitalVisualizer : MonoBehaviour
{
    public GameObject sun;
    public int segments = 100;
    public float orbitRadius;

    private LineRenderer lineRenderer;
    private bool isVisible = false;

    public bool IsVisible { get { return isVisible; } set { isVisible = value; } }

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = true;
        lineRenderer.enabled = false;
        DrawOrbitPath();
    }

    private void DrawOrbitPath()
    {
        Vector3[] points = new Vector3[segments + 1];
        float angleStep = 360f / segments;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * angleStep;
            float radians = Mathf.Deg2Rad * angle;
            float x = Mathf.Sin(radians) * orbitRadius;
            float z = Mathf.Cos(radians) * orbitRadius;
            points[i] = new Vector3(x + sun.transform.position.x, sun.transform.position.y, z + sun.transform.position.z);
        }

        lineRenderer.SetPositions(points);
    }

    public void ToggleOrbitVisibility()
    {
        isVisible = !isVisible;
        lineRenderer.enabled = isVisible;
    }

    public void TurnOffVisibility()
    {
        isVisible = false;
        lineRenderer.enabled = isVisible;
    }
}
