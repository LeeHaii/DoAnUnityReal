using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public XROrigin main;
    public XROrigin secondary;

    private bool isOnMain;
    // Start is called before the first frame update
    void Start()
    {
        isOnMain = true;
        if (main != null && secondary != null)
        {
            main.gameObject.SetActive(true);
            secondary.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("hasnt assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPlanet()
    {
        isOnMain = !isOnMain;
        main.gameObject.SetActive(isOnMain);
        secondary.gameObject.SetActive(!isOnMain);
    }
}
