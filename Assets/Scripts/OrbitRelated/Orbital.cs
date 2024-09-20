using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Orbital : MonoBehaviour
{

    public GameObject sun;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
    }

    private void OrbitAround()
    {
        transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
