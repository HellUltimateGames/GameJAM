
using UnityEngine;

public class Actions : MonoBehaviour, IInteractable<GameObject>
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //Shoot();
        }
    }


    


    public void Interact(GameObject player)
    {
        
    }
}
