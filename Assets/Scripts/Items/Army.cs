using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    CanvasManager canvasManager;
    GameObject UIPrefab;
    public void Interact(GameObject player)
    {
        canvasManager = FindObjectOfType<Canvas>().GetComponent<CanvasManager>();
        UIPrefab = Resources.Load("Prefabs/InteractUI/ArmyScreen") as GameObject;
        canvasManager.ShowInteractableUI(UIPrefab, true);
        // player.GetComponent<Controller>().canMove = false;
    }
}
