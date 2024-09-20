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

    private string ten;
    private double mass;
    private float radius;
    private double distanceFromSun;
    private float orbitalPeriod;
    private string color;
    private string jsonPath = File.ReadAllText("./Assets/PlanetInfo/GeneralInfo.json");

    void Start()
    {
        var deserialize = JsonConvert.DeserializeObject<JObject>(jsonPath);
        var data = deserialize.Value<JArray>("planets").ToObject<List<Planet>>();
        Debug.Log(data[0].ten);
        Debug.Log(data[0].mass);
        Debug.Log(data[0].radius);
        Debug.Log(data[0].distanceFromSun);
        Debug.Log(data[0].orbitalPeriod);
        Debug.Log(data[0].color);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlanetText()
    {

    }
    
}
