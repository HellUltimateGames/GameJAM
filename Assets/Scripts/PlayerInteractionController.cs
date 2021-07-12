using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

    public Camera cam;


    //The Hand icon has the index of 0, and the standard crossheir is 1
    public GameObject[] interactiveIcons;

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
                    interactiveIcons[0].SetActive(true);
                    interactiveIcons[1].SetActive(false);

                    


                    if (Input.GetButton("Interact"))
                    {
                        

                        GameObject o = hitInfo.collider.gameObject;
                        o.GetComponent<IInteractable>().Interact(gameObject);
                    }
                }
                else
                {
                    interactiveIcons[1].SetActive(true);
                    interactiveIcons[0].SetActive(false);
                    //when the doent hit anything / moves away
                }
            }
        }
        else
        {
            interactiveIcons[1].SetActive(true);
            interactiveIcons[0].SetActive(false);
            //when the doent hit anything / moves away
        }
    }
}
