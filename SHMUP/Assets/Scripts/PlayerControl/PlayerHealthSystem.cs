using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    public static bool P1lessLive;
    public static bool P2lessLive;

    public static bool P1moreHealth;
    public static bool P1moreShield;
    public static bool P1moreLive;

    public static bool P2moreHealth;
    public static bool P2moreShield;
    public static bool P2moreLive;

    //Player health
    public static float P1maxHealth;
    public static float P1currentHealth;
    public static float P1savedHealth;

    public static float P2maxHealth;
    public static float P2currentHealth;
    public static float P2savedHealth;

    public bool whichPlayer;
    public float minHealth;

    //Player shields.
    public static float P1maxShields;
    public static float P1currentShields;
    public static float P1savedShields;

    public static float P2maxShields;
    public static float P2currentShields;
    public static float P2savedShields;

    //Player Lives
    public static int P1maxLives;
    public static int P1currentLives;
    public static int P1savedLives;

    public static int P2maxLives;
    public static int P2currentLives;
    public static int P2savedLives;

    public Transform respawnLocation;
    public Transform playerHidingSpot;
    private float respawnTimer;

    private bool P1canRespawn;
    private bool P2canRespawn;

    private PlayerWeaponController playerWeaponController;

    //UI Tracking
    public Image P1HealthBar;
    public Image P1ShieldBar;
    
    public Image P2HealthBar;
    public Image P2ShieldBar;
    
    public Text P1lives;    
    public Text P2lives;

    //Stores any left over damage to deal to players through shields.
    private float P1excessShieldDamage;
    private float P2excessShieldDamage;

    //HoldsPlayerExplosion
    public GameObject playerExplosion;
    //Mini shield to show the player they're invulnerable at the moment.
    public GameObject respawnShield;
    public GameObject childShield;
    //Is player invulnerable?
    public bool invulnerable;

    void Start()
    {
        playerWeaponController = gameObject.GetComponent<PlayerWeaponController>();
        invulnerable = false;

        if (MainMenuController.onePlayer)
        {
            Player1Status();
        }
        else
        {
            Player1Status();
            Player2Status();
        }

        P1lessLive = false;
        P2lessLive = false;
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
                StartCoroutine(RespawnInvulnerability());

                SettingUpPlayer1();

                respawnTimer = 0;
            }
        }
        else if (gameObject.GetComponent<PlayerController>().P2isDead == true && P2canRespawn == true)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > 3)
            {
                //Respawns player at location.
                transform.position = respawnLocation.position;
                gameObject.GetComponent<PlayerController>().P2isDead = false;
                StartCoroutine(RespawnInvulnerability());

                SettingUpPlayer2();

                respawnTimer = 0;
            }
        }
        else
        {
            return;
        }
    }

    //Takes damage from another script and subtracts from the player health and shields.
    public void Damage(float damageAmmount)
    {
        if(invulnerable)
        {
            return;
        }
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

                P1ShieldBar.fillAmount = P1currentShields / P1maxShields;
            }
            //if excess shield damage is less than 0 it is substracted from health.
            if (P1excessShieldDamage < 0)
            {
                P1excessShieldDamage *= -1;
                P1currentHealth -= P1excessShieldDamage;
                
                P1HealthBar.fillAmount = P1currentHealth / P1maxHealth;
            }

            if (P1currentHealth < minHealth)
            {
                P1currentHealth = 0;
                P1HealthBar.fillAmount = P1currentHealth / P1maxHealth;
                P1HealthBar.fillAmount = P1currentHealth / P1maxHealth;

                //Instantiates player explosion where the player died.
                Instantiate(playerExplosion, gameObject.transform.position, gameObject.transform.rotation);

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

                P2ShieldBar.fillAmount = P2currentShields / P2maxShields;
            }
            //if excess shield damage is less than 0 it is substracted from health.
            if (P2excessShieldDamage < 0)
            {
                P2excessShieldDamage *= -1;
                P2currentHealth -= P2excessShieldDamage;

                P2HealthBar.fillAmount = P2currentHealth / P2maxHealth;
            }

            if (P2currentHealth < minHealth)
            {
                P2currentHealth = 0;
                P2HealthBar.fillAmount = P2currentHealth / P2maxHealth;

                Instantiate(playerExplosion, gameObject.transform.position, gameObject.transform.rotation);

                P2Respawn();
            }
        }
    }

    public void Healing(float healAmmount)
    {
        //player 1
        if(!whichPlayer)
        {
            P1moreHealth = true;

            P1currentHealth += healAmmount;

            if (P1currentHealth > P1maxHealth)
            {
                P1currentHealth = P1maxHealth;
            }
            
            P1HealthBar.fillAmount = P1currentHealth / P1maxHealth;
        }

        //player 2
        if (whichPlayer)
        {
            P2moreHealth = true;

            P2currentHealth += healAmmount;

            if (P2currentHealth > P2maxHealth)
            {
                P2currentHealth = P2maxHealth;
            }
            
            P2HealthBar.fillAmount = P2currentHealth / P2maxHealth;
        }
    }

    public void ShieldHealing(float shieldHealAmmount)
    {
        //player 1
        if(!whichPlayer)
        {
            P1moreShield = true;

            P1currentShields += shieldHealAmmount;

            if (P1currentShields > P1maxShields)
            {
                P1currentShields = P1maxShields;
            }
            
            P1ShieldBar.fillAmount = P1currentShields / P1maxShields;
        }

        //player 2
        if(whichPlayer)
        {
            P2moreShield = true;

            P2currentShields += shieldHealAmmount;

            if (P2currentShields > P2maxShields)
            {
                P2currentShields = P2maxShields;
            }

            P2ShieldBar.fillAmount = P2currentShields / P2maxShields;
        }
    }

    public void ExtraLife()
    {
        //player 1
        if(!whichPlayer)
        {
            P1moreLive = true;

            P1currentLives ++;

            if (P1currentLives > P1maxLives)
            {
                P1currentLives = P1maxLives;
                return;
            }
        }

        P1lives.text = "" + P1currentLives;

        //player 2
        if (whichPlayer)
        {
            P2moreLive = true;

            P2currentLives ++;

            if (P2currentLives > P2maxLives)
            {
                P2currentLives = P2maxLives;
                return;
            }

            P2lives.text = "" + P2currentLives;
        }
    }
    
    //player 1
    private void P1Respawn()
    {
        P1lessLive = true;

        if (P1currentLives <= 0)
        {
            transform.position = playerHidingSpot.position;
            gameObject.GetComponent<PlayerController>().P1isDead = true;
            playerWeaponController.LessGun();
            P1canRespawn = false;
            return; ;
        }
        if(P1currentLives > 0)
        {
            P1currentLives--;
            P1lives.text = "" + P1currentLives;
            transform.position = playerHidingSpot.position;
            gameObject.GetComponent<PlayerController>().P1isDead = true;
            playerWeaponController.LessGun();
            P1canRespawn = true;
        }
    }

    //player 2
    private void P2Respawn()
    {
        P2lessLive = true;

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
            P2lives.text = "" + P2currentLives;
            transform.position = playerHidingSpot.position;
            gameObject.GetComponent<PlayerController>().P2isDead = true;
            playerWeaponController.LessGun();
            P2canRespawn = true;
        }
    }

    private void Player1Status()
    {
        P1currentHealth = P1savedHealth;
        P1currentShields = P1savedShields;
        P1currentLives = P1savedLives;

        P1HealthBar.fillAmount = P1currentHealth / P1maxHealth;
        P1ShieldBar.fillAmount = P1currentShields / P1maxShields;
    }
    private void Player2Status()
    {
        P2currentHealth = P2savedHealth;
        P2currentShields = P2savedShields;
        P2currentLives = P2savedLives;

        P2HealthBar.fillAmount = P2currentHealth / P2maxHealth;
        P2ShieldBar.fillAmount = P2currentShields / P2maxShields;
    }

    private void SettingUpPlayer1()
    {
        P1currentHealth = P1maxHealth;

        //Tries to grab a points script if the object has any.

        P1HealthBar.fillAmount = P1currentHealth / P1maxHealth;
        P1ShieldBar.fillAmount = P1currentShields / P1maxShields;
    }
    private void SettingUpPlayer2()
    {
        P2currentHealth = P2maxHealth;

        //Tries to grab a points script if the object has any.

        P2HealthBar.fillAmount = P2currentHealth / P2maxHealth;
        P2ShieldBar.fillAmount = P2currentShields / P2maxShields;
    }

    IEnumerator RespawnInvulnerability()
    {
        invulnerable = true;
        childShield = Instantiate(respawnShield, gameObject.transform.position, gameObject.transform.rotation) as GameObject;

        //childShield = Instantiate(respawnShield, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation) as GameObject;
        childShield.transform.parent = gameObject.transform;
        yield return new WaitForSeconds(3);
        invulnerable = false;
    }
}
