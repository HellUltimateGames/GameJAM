using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitEnemy : MonoBehaviour
{
    private void Start()
    {
        if(gameObject.GetComponent<CapsuleCollider>().enabled) Destroy(gameObject, 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Ignore")) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Controller>().TakeDamage(5);
            Destroy(gameObject);
        }
    }

}

