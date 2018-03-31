using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAoE : MonoBehaviour
{
    private PlayerHealthSystem health;

    //Refference to explosion prefab
    public GameObject explosion;

    public bool hasFuse;

    public float damageAmmount;
    public float fuseTime;

    private bool whichPlayer;

    private void Update()
    {
        fuseTime -= Time.deltaTime;

        if (hasFuse == true && fuseTime < 0)
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("LightEnemy") || other.CompareTag("MediumEnemy") || other.CompareTag("HeavyEnemy") || other.CompareTag("OverEnemy") || other.CompareTag("EnemyBullet"))
        {
            return;
        }

        health = other.GetComponent<PlayerHealthSystem>();

        if (health == null)
        {
            return;
        }

        health.Damage(damageAmmount);
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
