
using UnityEngine;

public class Actions : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if (GetComponent<Inventory>().EquippedIndex != -1 && GetComponent<Inventory>().EquippedIndex < GetComponent<Inventory>().MaxItems)
            {
                GameObject EquipedObject = GetComponent<Inventory>().Contents[GetComponent<Inventory>().EquippedIndex].gameObject;

                if (EquipedObject.GetComponent<Weapon>() != null)
                {
                    EquipedObject.GetComponent<Weapon>().Shoot();
                }
            }
        }
    }

}
