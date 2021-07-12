
using UnityEngine;

public class Actions : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            
            GameObject EquipedObject = GetComponent<Inventory>().Contents[GetComponent<Inventory>().EquippedIndex].gameObject;

            if (EquipedObject.GetComponent<Weapon>() != null)
            {
                EquipedObject.GetComponent<Weapon>().Shoot();
            }
        }
    }

}
