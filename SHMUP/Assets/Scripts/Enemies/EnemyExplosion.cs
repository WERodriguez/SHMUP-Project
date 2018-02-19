using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private PlayerHealthSystem health;

    //For experimenting with multiple projectiles later. Shrapnel basically.
    //public GameObject projectiles;

    public float damageAmmount;
    public float explosionDuration;

    void Start()
    {
        //Destroys the explosion after a duration.
        Destroy(gameObject, explosionDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Does nothing to boundary or player tags.
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            return;
        }

        //Grabs a refference to the other object's health system
        health = other.GetComponent<PlayerHealthSystem>();
        if (health == null)
        {
            return;
        }

        //Tells that health system to deal X damage.
        health.Damage(damageAmmount);
    }
}
