using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetListToggle : MonoBehaviour
{
    public GameObject planetCanvas;
    private bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;

        // Ensure the initial state of the canvas
        if (planetCanvas != null)
        {
            planetCanvas.SetActive(isOpened);
        }
        else
        {
            Debug.LogError("Planet canvas is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleUI()
    {
        isOpened = !isOpened;
        planetCanvas.SetActive(isOpened);
    }
}
