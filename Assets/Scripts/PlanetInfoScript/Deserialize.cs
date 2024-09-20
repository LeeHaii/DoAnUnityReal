using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Deserialize : MonoBehaviour
{
    [SerializeField] private string jsonPath;
    private JsonObjectsCollection jsonObjectsCollection;

    [ContextMenu("Load Objects")]
    private void LoadObjects()
    {
        using (StreamReader stream = new StreamReader(jsonPath))
        {
            string json = stream.ReadToEnd();
            jsonObjectsCollection = JsonUtility.FromJson<JsonObjectsCollection>(json);
        }
        Debug.Log("Objects Loaded: " + jsonObjectsCollection.jsonObjects.Length);
        FindObjectOfType<Text>().text = jsonObjectsCollection.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadObjects();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}