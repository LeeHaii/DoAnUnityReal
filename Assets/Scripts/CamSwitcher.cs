using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem;

public class CamSwitcher : MonoBehaviour
{
    public List<XROrigin> PlanetList;
    public XROrigin mainRig;

    public int PassIndex { get; set; }

    void Start()
    {
        if (PlanetList != null && PlanetList.Count > 0 && mainRig != null)
        {
            for (int i = 0; i < PlanetList.Count; i++)
            {
                if (PlanetList[i] == null)
                {
                    Debug.LogError("XROrigin at index " + i + " is null!");
                    return;
                }
                PlanetList[i].gameObject.SetActive(false);
            }
            mainRig.gameObject.SetActive(true);
            //ActivateRig(mainRig);
            PassIndex = 0;
        }
        else
        {
            Debug.LogError("PlanetList is either null or empty!");
        }
    }


    public void SwitchToPlanet(int index)
    {
        if (index >= 0 && index < PlanetList.Count)
        {
            // Disable all XR rigs first
            for (int i = 0; i < PlanetList.Count; i++)
            {
                if (PlanetList[i] != null)
                {
                    PlanetList[i].gameObject.SetActive(false);
                }
            }
            mainRig.gameObject.SetActive(false);
            ActivateRig(PlanetList[index]);
            PassIndex = index;
        }
        else
        {
            Debug.LogError("Invalid planet index: " + index);
        }
    }


    private void ActivateRig(XROrigin rig)
    {
        if (rig != null)
        {
            rig.gameObject.SetActive(true);

            // Ensure the camera in the XR rig is active
            Camera camera = rig.GetComponentInChildren<Camera>();
            if (camera != null)
            {
                camera.enabled = true;
            }
            
        }
        else
        {
            Debug.LogError("Tried to activate a null XROrigin!");
        }
        
    }

    public void ReturnToMain()
    {
        for(int i = 0; i < PlanetList.Count; i++)
        {
            PlanetList[i].gameObject.SetActive(false);
        }
        ActivateRig(mainRig);
    }
}