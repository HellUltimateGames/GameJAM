using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IInteractable, IWeapon, IPickable
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject impactEffect;
    ParticleSystem muzzleFlash;

    bool _pickedUp = false;
    public bool isPickedUp { get { return _pickedUp; } set { _pickedUp = value; } }

    bool _equiped = false;
    public bool isEquiped { get { return _equiped; } set { _equiped = value; } }

    int _inventoryId = -1;
    public int InventoryId { get { return _inventoryId; } set { _inventoryId = value; } }



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPickedUp)
        {
            GetComponent<FloatController>().Float();
        }
    }

    public void Interact(GameObject player)
    {
        player.GetComponent<Inventory>().TryAdd(this, player, out _);
    }

    public void PickUp(GameObject player)
    {
        isPickedUp = true;
    }

    public void Equip(GameObject player)
    {
        isEquiped = true;
        transform.parent = player.transform.GetChild(0).transform;
        transform.rotation = player.transform.GetChild(0).GetChild(0).rotation;
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        transform.localPosition = new Vector3(0.343f, -0.469f, 0.884f);
    }

    public void Shoot()
    {
        muzzleFlash = transform.GetComponentInChildren<ParticleSystem>();
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}
