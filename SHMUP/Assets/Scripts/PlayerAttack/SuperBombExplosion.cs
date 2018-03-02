using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBombExplosion : MonoBehaviour
{
    private HealthSystem health;

    //For experimenting with multiple projectiles later. Shrapnel basically.
    //public GameObject projectiles;

    public float damageAmmount;
    public float explosionDuration;

    private Vector3 bombScale;
    public float growthRate;

    //What player the bullet belongs to.
    public bool whoDoIBelongTo;

    void Start()
    {
        bombScale =  transform.localScale;
        //Destroys the explosion after a duration.
        Destroy(gameObject, explosionDuration);
    }


    private void Update()
    {
        bombScale.x += Time.deltaTime * growthRate;
        bombScale.y += Time.deltaTime * growthRate;
        bombScale.z += Time.deltaTime * growthRate;

        transform.localScale = bombScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Does nothing to boundary or player tags.
        if (other.CompareTag("Boundary") || other.CompareTag("Player"))
        {
            return;
        }

        //Grabs a refference to the other object's health system
        health = other.GetComponent<HealthSystem>();
        if (health == null)
        {
            return;
        }

        //Tells that health system to deal X damage.
        health.Damage(damageAmmount, whoDoIBelongTo);
    }
}
