using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM : MonoBehaviour, IInteractable<GameObject>
{
    // Start is called before the first frame update
    CanvasManager canvasManager;
    GameObject UIPrefab;
    public void Interact(GameObject player)
    {
        canvasManager = FindObjectOfType<Canvas>().GetComponent<CanvasManager>();
        UIPrefab = Resources.Load("Prefabs/InteractUI/ATMScreen") as GameObject;
        canvasManager.ShowInteractableUI(UIPrefab, true);
        player.GetComponent<PlayerController>().canMove = false;
    }
 }
