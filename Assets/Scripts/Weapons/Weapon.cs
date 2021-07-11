using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IInteractable<GameObject>, IWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<FloatController>().Float();
    }

    public void Interact(GameObject player)
    {

    }

    public void Shoot()
    {
        
    }
}
