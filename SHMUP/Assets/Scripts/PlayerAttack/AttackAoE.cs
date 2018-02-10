using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAoE : MonoBehaviour
{
    //Refference to explosion prefab
    public GameObject explosion;

    //Use this to actually detect a collision. A bump.
    private void OnCollisionEnter(Collision collision)
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
    }
}
