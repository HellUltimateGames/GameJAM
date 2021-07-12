using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    public GameObject gameObject { get; }
    public bool isPickedUp { get; set; }
    public bool isEquiped { get; set; }
    public int InventoryId { get; set; }
    public void PickUp(GameObject player);

    public void Equip(GameObject player);
}
