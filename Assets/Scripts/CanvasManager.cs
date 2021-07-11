using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update

    bool showingInteractableUI;
    GameObject InteractableUIObject;
    public void ShowInteractableUI(GameObject prefab)
    {
        if (showingInteractableUI) return;
        InteractableUIObject = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        InteractableUIObject.transform.parent = gameObject.transform;
        showingInteractableUI = true;
    }
    public void closeInteractableUI()
    {
        if(!showingInteractableUI) return;
        GameObject.Destroy(InteractableUIObject);
    }
    void Update()
    {
        if(Input.GetKeyDown("escape") || Input.GetKeyDown("e"))
        {
            closeInteractableUI();
        }    
    }
}
