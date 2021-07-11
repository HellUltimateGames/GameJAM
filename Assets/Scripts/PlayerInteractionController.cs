using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
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
                    if (Input.GetButton("Interact"))
                    {
                        GameObject o = hitInfo.collider.gameObject;
                        o.GetComponent<IInteractable<GameObject>>().Interact(gameObject);
                    }
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
