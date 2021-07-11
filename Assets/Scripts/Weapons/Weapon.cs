using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IInteractable<GameObject>, IWeapon
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject impactEffect;
    ParticleSystem muzzleFlash;
    bool pickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pickedUp)
        {
            GetComponent<FloatController>().Float();
        }
    }

    public void Interact(GameObject player)
    {
        pickedUp = true;
        transform.parent = player.transform.GetChild(0).transform;
        transform.rotation = player.transform.GetChild(0).GetChild(0).rotation;
        transform.localPosition = new Vector3(0.15f, -0.4f, 1.1f);
    }

    public void Shoot()
    {
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
