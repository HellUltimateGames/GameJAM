using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrittenNote : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    CanvasManager canvasManager;
    GameObject UIPrefab;
    public int index;
    public void Interact(GameObject player)
    {
        canvasManager = FindObjectOfType<Canvas>().GetComponent<CanvasManager>();
        UIPrefab = Resources.Load("Prefabs/InteractUI/NoteScreen" + index) as GameObject;
        canvasManager.ShowInteractableUI(UIPrefab, false);
        canvasManager.numberOfNotesRead++;
        Destroy(gameObject);
        //player.GetComponent<Controller>().canMove = false;
    }
}
