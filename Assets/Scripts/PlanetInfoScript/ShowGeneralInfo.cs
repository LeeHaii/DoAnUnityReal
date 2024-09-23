using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;


public class ShowGeneralInfo : MonoBehaviour
{
    public class Planet
    {
        public string ten;
        public double mass;
        public float radius;
        public double distanceFromSun;
        public float orbitalPeriod;
        public string color;
    }

    /* private string ten;
    private double mass;
    private float radius;
    private double distanceFromSun;
    private float orbitalPeriod;
    private string color; */ 
    private string jsonPath = File.ReadAllText("./Assets/PlanetInfo/GeneralInfo.json");

    public TextMeshProUGUI planetName;
    public TextMeshProUGUI planetMass;
    public TextMeshProUGUI planetRadius;
    public TextMeshProUGUI planetDistanceFromSun;
    public TextMeshProUGUI planetOrbitalPeriod;

    private Color planetColor;

    private List<Planet> planetData;
    private CamSwitcher getPassIndex;
    

    void Start()
    {
        getPassIndex = GameObject.Find("CamSwitch").GetComponent<CamSwitcher>();
        var deserialize = JsonConvert.DeserializeObject<JObject>(jsonPath);
        var data = deserialize.Value<JArray>("planets").ToObject<List<Planet>>();
        planetData = data;
        Debug.Log(getPassIndex.PassIndex.ToString());
        
    }

    void Update()
    {
        SetPlanetText();
    }

    public void SetPlanetText()
    {
        if (planetData != null)
        {
            planetName.text = planetData[getPassIndex.PassIndex].ten;
            planetMass.text = planetData[getPassIndex.PassIndex].mass.ToString() + "kg";
            planetRadius.text = planetData[getPassIndex.PassIndex].radius.ToString() + "km";
            planetDistanceFromSun.text = planetData[getPassIndex.PassIndex].distanceFromSun.ToString() + "km";
            planetOrbitalPeriod.text = planetData[getPassIndex.PassIndex].orbitalPeriod.ToString() + " Earth days";

            ColorUtility.TryParseHtmlString(planetData[getPassIndex.PassIndex].color, out planetColor);
            planetName.color = planetColor;
            planetMass.color = planetColor;
            planetRadius.color = planetColor;
            planetDistanceFromSun.color = planetColor;
            planetOrbitalPeriod.color = planetColor;

            Debug.Log(planetData[getPassIndex.PassIndex].ten);
            Debug.Log(planetData[getPassIndex.PassIndex].mass.ToString());
            Debug.Log(planetData[getPassIndex.PassIndex].radius.ToString());
            Debug.Log(planetData[getPassIndex.PassIndex].distanceFromSun.ToString());
            Debug.Log(planetData[getPassIndex.PassIndex].orbitalPeriod.ToString());

        }
    }
    
}
