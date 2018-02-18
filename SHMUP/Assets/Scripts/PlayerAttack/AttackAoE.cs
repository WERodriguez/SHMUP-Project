using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAoE : MonoBehaviour
{

    private HealthSystem health;

    //This is where the boom goes to learn who its daddy is.
    private GameObject explodo;
    //Refference to explosion prefab
    public GameObject explosion;

    //What player the bullet belongs to.
    public bool whoDoIBelongTo;
    public bool hasFuse;

    public float damageAmmount;
    public float fuseTime;

    

    private bool whichPlayer;

    private void Start()
    {
        //Asks itself who it belongs to.
        whichPlayer = whoDoIBelongTo;
        //Creates a modified instance of its assigned explosion prefab.
        explodo = explosion as GameObject;
        //Marks said instance as belonging to the player that shot this.
        explodo.GetComponent<AttackExplosion>().whoDoIBelongTo = whichPlayer;        
    }

    private void Update()
    {
        fuseTime -= Time.deltaTime;

        if (hasFuse == true && fuseTime < 0)
        {
            Debug.Log("I am supposed to explode");
            Instantiate(explodo, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player") || other.CompareTag("PlayerBullet"))
        {
            return;
        }

        health = other.GetComponent<HealthSystem>();

        if (health == null)
        {
            return;
        }

        health.Damage(damageAmmount, whoDoIBelongTo);
        Instantiate(explodo, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
