using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{

    //Player health
    public static float P1currentHealth;
    public static float P2currentHealth;
    public static float P1maxHealth;
    public static float P2maxHealth;

    public bool whichPlayer;
    public float minHealth;

    //Player shields.
    public static float P1currentShields;
    public static float P2currentShields;
    public static float P1maxShields;
    public static float P2maxShields;

    //Player Lives
    public static int P1currentLives;
    public static int P2currentLives;
    public static int P1maxLives;
    public static int P2maxLives;

    public Transform respawnLocation;
    public Transform playerHidingSpot;
    private float respawnTimer;

    private bool P1canRespawn;
    private bool P2canRespawn;

    private PlayerWeaponController playerWeaponController;


    //UI Tracking
    public Text P1health;
    public Text P1shields;
    public Text P1lives;

    public Text P2health;
    public Text P2shields;
    public Text P2lives;

    //Stores any left over damage to deal to players through shields.
    private float P1excessShieldDamage;
    private float P2excessShieldDamage;

    void Start()
    {
        playerWeaponController = gameObject.GetComponent<PlayerWeaponController>();

        if(UIController.onePlayer)
        {
            SettingUpPlayer1();

            P1currentShields = P1maxShields;
            P1currentLives = P1maxLives;
        }
        else
        {
            SettingUpPlayer1();
            SettingUpPlayer2();

            P1currentShields = P1maxShields;
            P1currentLives = P1maxLives;
            P2currentShields = P2maxShields;
            P2currentLives = P2maxLives;
        }
    }

    private void Update()
    {
        if (gameObject.GetComponent<PlayerController>().P1isDead == true && P1canRespawn == true)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > 3)
            {
                //Respawns player at location.
                transform.position = respawnLocation.position;
                gameObject.GetComponent<PlayerController>().P1isDead = false;

                SettingUpPlayer1();

                respawnTimer = 0;
            }
        }
        if (gameObject.GetComponent<PlayerController>().P2isDead == true && P2canRespawn == true)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > 3)
            {
                //Respawns player at location.
                transform.position = respawnLocation.position;
                gameObject.GetComponent<PlayerController>().P2isDead = false;

                SettingUpPlayer2();

                respawnTimer = 0;
            }
        }
    }

    //Takes damage from another script and subtracts from the player health and shields.
    public void Damage(float damageAmmount)
    {
        //player 1
        if(!whichPlayer)
        {
            P1excessShieldDamage = P1currentShields - damageAmmount;

            //Checks if the player has shields
            //If player has shields damage is dealt to shields.
            if (P1currentShields >= 0)
            {
                P1currentShields -= damageAmmount;
                //If shields go under 0 shields are set to 0
                if (P1currentShields <= 0)
                {
                    P1currentShields = 0;
                }
                P1shields.text = "SP: " + P1currentShields;
            }
            //if excess shield damage is less than 0 it is substracted from health.
            if (P1excessShieldDamage < 0)
            {
                P1excessShieldDamage *= -1;
                P1currentHealth -= P1excessShieldDamage;

                P1health.text = "HP: " + P1currentHealth;
            }

            if (P1currentHealth < minHealth)
            {
                P1currentHealth = 0;
                P1health.text = "HP: " + P1currentHealth;
                //Destroy(gameObject);
                P1Respawn();
            }
        }

        //player 2
        if(whichPlayer)
        {
            P2excessShieldDamage = P2currentShields - damageAmmount;

            //Checks if the player has shields
            //If player has shields damage is dealt to shields.
            if (P2currentShields >= 0)
            {
                P2currentShields -= damageAmmount;
                //If shields go under 0 shields are set to 0
                if (P2currentShields <= 0)
                {
                    P2currentShields = 0;
                }
                P2shields.text = "SP: " + P2currentShields;
            }
            //if excess shield damage is less than 0 it is substracted from health.
            if (P2excessShieldDamage < 0)
            {
                P2excessShieldDamage *= -1;
                P2currentHealth -= P2excessShieldDamage;

                P2health.text = "HP: " + P2currentHealth;
            }

            if (P2currentHealth < minHealth)
            {
                P2currentHealth = 0;
                P2health.text = "HP: " + P2currentHealth;
                //Destroy(gameObject);
                P2Respawn();
            }
        }
    }

    public void Healing(float healAmmount)
    {
        //player 1
        if(!whichPlayer)
        {
            P1currentHealth += healAmmount;

            if (P1currentHealth > P1maxHealth)
            {
                P1currentHealth = P1maxHealth;
            }

            P1health.text = "HP: " + P1currentHealth;
        }

        //player 2
        if (whichPlayer)
        {
            P2currentHealth += healAmmount;

            if (P2currentHealth > P2maxHealth)
            {
                P2currentHealth = P2maxHealth;
            }

            P2health.text = "HP: " + P2currentHealth;
        }
    }

    public void ShieldHealing(float shieldHealAmmount)
    {
        //player 1
        if(!whichPlayer)
        {
            P1currentShields += shieldHealAmmount;

            if (P1currentShields > P1maxShields)
            {
                P1currentShields = P1maxShields;
            }

            P1shields.text = "SP: " + P1currentShields;
        }

        //player 2
        if(whichPlayer)
        {
            P2currentShields += shieldHealAmmount;

            if (P2currentShields > P2maxShields)
            {
                P2currentShields = P2maxShields;
            }

            P2shields.text = "SP: " + P2currentShields;
        }
    }

    public void ExtraLife()
    {
        //player 1
        if(!whichPlayer)
        {
            P1currentLives += 1;

            if (P1currentLives > P1maxLives)
            {
                return;
            }
        }

        P1lives.text = "Lives: " + P1currentLives;

        //player 2
        if (whichPlayer)
        {
            P2currentLives += 1;

            if (P2currentLives > P2maxLives)
            {
                return;
            }

            P2lives.text = "Lives: " + P2currentLives;
        }
    }
    
    //player 1
    private void P1Respawn()
    {
        if (P1currentLives <= 0)
        {
            transform.position = playerHidingSpot.position;
            gameObject.GetComponent<PlayerController>().P1isDead = true;
            playerWeaponController.LessGun();
            P1canRespawn = false;
            return;
        }
        if(P1currentLives > 0)
        {
            P1currentLives--;
            P1lives.text = "Lives: " + P1currentLives;
            transform.position = playerHidingSpot.position;
            gameObject.GetComponent<PlayerController>().P1isDead = true;
            playerWeaponController.LessGun();
            P1canRespawn = true;
        }
    }

    //player 2
    private void P2Respawn()
    {
        if (P2currentLives <= 0)
        {
            transform.position = playerHidingSpot.position;
            gameObject.GetComponent<PlayerController>().P2isDead = true;
            playerWeaponController.LessGun();
            P2canRespawn = false;
            return;
        }
        if (P2currentLives > 0)
        {
            P2currentLives--;
            P2lives.text = "Lives: " + P2currentLives;
            transform.position = playerHidingSpot.position;
            gameObject.GetComponent<PlayerController>().P2isDead = true;
            playerWeaponController.LessGun();
            P2canRespawn = true;
        }
    }

    private void SettingUpPlayer1()
    {
        P1currentHealth = P1maxHealth;

        //Tries to grab a points script if the object has any.
        P1health.text = "HP: " + P1currentHealth;
        P1shields.text = "SP: " + P1currentShields;
        P1lives.text = "Lives: " + P1currentLives;
    }

    private void SettingUpPlayer2()
    {
        P2currentHealth = P2maxHealth;

        //Tries to grab a points script if the object has any.
        P2health.text = "HP: " + P2currentHealth;
        P2shields.text = "SP: " + P2currentShields;
        P2lives.text = "Lives: " + P2currentLives;
    }
}
