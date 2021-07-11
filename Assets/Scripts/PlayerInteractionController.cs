using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, 7))
        {
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.gameObject.tag == "Interactable")
                {
                    //When the Raycast hits an interactable object
                }
                else
                {
                   //when the doent hit anything / moves away
                }
            }
        }
        else
        {
            //when the doent hit anything / moves away
        }
    }
}
