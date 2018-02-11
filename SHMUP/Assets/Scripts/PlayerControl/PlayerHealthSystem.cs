using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{

    //Player health
    public float currentHealth;
    public float minHealth;
    public float maxHealth;

    //Player shields.
    public float currentShields;
    public float maxShields;

    //UI Tracking
    /*public Text health_P1;
    public Text shields_P1;
    public Text health_P2;
    public Text shields_P2;*/

    public Text health;
    public Text shields;

    //Stores any left over damage to deal to players through shields.
    private float excessShieldDamage;

    void Start()
    {
        currentHealth = maxHealth;
        //Tries to grab a points script if the object has any.

        health.text = "HP: " + currentHealth;
        shields.text = "SP: " + currentShields;
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
            shields.text = "SP: " + currentShields;
        }
        //if excess shield damage is less than 0 it is substracted from health.
        if (excessShieldDamage < 0)
        {
            excessShieldDamage *= -1;
            currentHealth -= excessShieldDamage;

            health.text = "HP: " + currentHealth;
        }

        if (currentHealth < minHealth)
        {
            currentHealth = 0;
            health.text = "HP: " + currentHealth;
            Destroy(gameObject);
        }
    }

    public void Healing(float healAmmount)
    {
        if (currentHealth > maxHealth)
        {
            return;
        }
        currentHealth += healAmmount;
        health.text = "HP: " + currentHealth;
    }

    public void ShieldHealing(float shieldHealAmmount)
    {
        if (currentHealth > maxHealth)
        {
            return;
        }
        currentShields += shieldHealAmmount;
        shields.text = "SP: " + currentShields;
    }
}
