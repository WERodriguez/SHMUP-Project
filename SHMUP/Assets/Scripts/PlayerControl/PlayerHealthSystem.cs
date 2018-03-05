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

    //Player Lives
    public int currentLives;
    public int maxLives = 3;
    public Transform respawnLocation;
    public Transform playerHidingSpot;
    private float respawnTimer;
    private bool canRespawn;

    private PlayerWeaponController playerWeaponController;


    //UI Tracking
    public Text health;
    public Text shields;
    public Text lives;

    //Stores any left over damage to deal to players through shields.
    private float excessShieldDamage;

    void Start()
    {
        playerWeaponController = gameObject.GetComponent<PlayerWeaponController>();
        currentHealth = maxHealth;
        currentLives = 3;
        //Tries to grab a points script if the object has any.

        health.text = "HP: " + currentHealth;
        shields.text = "SP: " + currentShields;
        lives.text = "Lives: " + currentLives;
    }

    private void Update()
    {
        if(gameObject.GetComponent<PlayerController>().isDead == true && canRespawn == true)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > 3)
            {
                //Respawns player at location.
                transform.position = respawnLocation.position;
                gameObject.GetComponent<PlayerController>().isDead = false;
                currentHealth = maxHealth;
                health.text = "HP: " + currentHealth;
                respawnTimer = 0;
            }
        }
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
            //Destroy(gameObject);
            Respawn();
        }
    }

    public void Healing(float healAmmount)
    {
        currentHealth += healAmmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        health.text = "HP: " + currentHealth;
    }

    public void ShieldHealing(float shieldHealAmmount)
    {
        currentShields += shieldHealAmmount;

        if (currentShields > maxShields)
        {
            currentShields = maxShields;
        }

        shields.text = "SP: " + currentShields;
    }

    public void ExtraLife()
    {
        currentLives += 1;

        if (currentLives > maxLives)
        {
            return;
        }

        lives.text = "Lives: " + currentLives;
    }

    private void Respawn()
    {
        currentLives -= 1;

        if(currentLives < 0)
        {
            transform.position = playerHidingSpot.position;
            gameObject.GetComponent<PlayerController>().isDead = true;
            playerWeaponController.LessGun();
            canRespawn = false;
            return;
        }

        lives.text = "Lives: " + currentLives;
        transform.position = playerHidingSpot.position;
        gameObject.GetComponent<PlayerController>().isDead = true;
        playerWeaponController.LessGun();
        canRespawn = true;
    }
}
