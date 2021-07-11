using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{ 
    
    public int camFOVZoom;
    public int camFOVNormal;
    public int changeIncrement;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().fieldOfView = camFOVNormal;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            if (GetComponent<Camera>().fieldOfView > camFOVZoom)
            {
                GetComponent<Camera>().fieldOfView -= changeIncrement;
            }
        }
        else
        {
            if(GetComponent<Camera>().fieldOfView < camFOVNormal)
            {
                GetComponent<Camera>().fieldOfView += changeIncrement;
            }
        }
    }
}
