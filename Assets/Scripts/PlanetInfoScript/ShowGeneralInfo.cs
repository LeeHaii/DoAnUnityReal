using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using SimpleJSON;
using Palmmedia.ReportGenerator.Core.Common;
using System.IO;

public class ShowGeneralInfo : MonoBehaviour
{
    private class Planet
    {
        public string planetName;
        public long planetMass;
        public float planetRaidus;
        public double dFS;
        public float orbitalPeriod;
    }

    [Header("Attributes")]
    [SerializeField]
    private TMP_Text planetName;
    [SerializeField]
    private TMP_Text planetMass;
    [SerializeField]
    private TMP_Text dFS;
    [SerializeField]
    private TMP_Text orbitalPeriod;
    [SerializeField]
    private string textColor;
    private string jsonPath = File.ReadAllText("./../PlanetInfo/GeneralInfo.json");

    void Start()
    {
        List<Planet> planets = JsonSerializer.Deserialize<List<Planet>>(jsonPath);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetJsonData()
    {
        print("Get Json Data");
    }
    public void SetPlanetText()
    {

    }
    
}
