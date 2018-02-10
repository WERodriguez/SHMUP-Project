using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //Player health
    public float currentHealth;
    public float minHealth;
    public float maxHealth;

    //Player shields.
    public float currentShields;
    public float maxShields;

    //Stores any left over damage to deal to players through shields.
    private float excessShieldDamage;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
    }	

    //Takes damage from another script and subtracts from the player health and shields.
    public void Damage(float damageAmmount)
    {
        excessShieldDamage = currentShields - damageAmmount;

        //Checks if the player has shields
        //If player has shields damage is dealt to shields.
        if (currentShields > 0)
        {
            currentShields -= damageAmmount;
            //If shields go under 0 shields are set to 0
            if (currentShields <= 0)
            {
                currentShields = 0;
            }
        }
        //if excess shield damage is less than 0 it is substracted from health.
        if (excessShieldDamage < 0)
        {
            excessShieldDamage *= -1;
            currentHealth -= excessShieldDamage;
        }

        if (currentHealth < minHealth)
        {
            Destroy(gameObject);
        }
    }

    public void Healing(float healAmmount)
    {
        currentHealth += healAmmount;

        if (currentHealth < minHealth)
        {
            Destroy(gameObject);
        }
    }
}
