using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update

    bool showingInteractableUI;
    GameObject InteractableUIObject;
    GameObject player;
   
    public void ShowInteractableUI(GameObject prefab, bool freeze)
    {
        if (showingInteractableUI) return;
        InteractableUIObject = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        InteractableUIObject.transform.SetParent(gameObject.transform, false);
        showingInteractableUI = true;
        if (player == null) return;
        player.GetComponent<PlayerController>().canMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        
    }
    public void closeInteractableUI()
    {
        if(!showingInteractableUI) return;
        GameObject.Destroy(InteractableUIObject);
    }
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            closeInteractableUI();
            showingInteractableUI = false;
            player.GetComponent<PlayerController>().canMove = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }    
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
