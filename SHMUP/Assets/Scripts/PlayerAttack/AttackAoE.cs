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
    public float damageAmmount;


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

    //Use this to actually detect a collision. A bump.
    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I dun collided!");

        if (collision.gameObject.CompareTag("Boundary") || collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        //Pulls a contact point from where the bullet hit another collider.
        ContactPoint contact = collision.contacts[0];
        //Assigns contact point to a vector3
        Vector3 pos = contact.point;

        //Calls for the explosion at point of impact.
        Instantiate(explosion, pos, gameObject.transform.rotation);
        Destroy(gameObject);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player"))
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
