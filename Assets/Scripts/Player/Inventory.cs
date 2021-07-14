using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<IPickable> Contents = new List<IPickable>();
    // Start is called before the first frame update
    public int MaxItems = 1;
    public int EquippedIndex = -1;


    public bool TryAdd(IPickable gameObject, GameObject player, out string error)
    {
        
        if (Contents.Count < MaxItems)
        {
            
            Contents.Add(gameObject);
            EquippedIndex = Contents.IndexOf(gameObject);
            gameObject.PickUp(player);
            gameObject.Equip(player);
            error = "";

            return true;
        }
        else
        {
            if (EquippedIndex > -1) 
            {
                Contents.Insert(EquippedIndex, gameObject);
                EquippedIndex = Contents.IndexOf(gameObject);
                Contents.RemoveAt(EquippedIndex + 1);
                gameObject.PickUp(player);
                gameObject.Equip(player);
                error = "";

                return true;
            }
            else
            {
                error = "max_items_reached";

                return false;
            }
        }
    }

    public bool Remove(object gameObject)
    {
        try
        {
            Contents.Remove(gameObject as IPickable);
        }
        catch
        {
            return false;
        }

        return true;

    }

    
}
