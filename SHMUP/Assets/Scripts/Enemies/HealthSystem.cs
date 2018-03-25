using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //Player health
    public float currentHealth;
    public float maxHealth;

    //Player shields.
    public float currentShields;
    public float maxShields;

    public float lootDropChance;

    //Stores any left over damage to deal to players through shields.
    private float excessShieldDamage;

    private Points addScore;
    private LootDropRoller callLoot;
    private float doesLootDrop;

    //Checks if boss.
    public bool isBoss;
    //Checks if boss part.
    public bool isBossPart;
    //For boss/bosspart death
    public GameObject scrap;

    public bool scoreScreen;

    public static int P1ramEnemy;
    public static int P2ramEnemy;

    public static int P1lightEnemy;
    public static int P2lightEnemy;

    public static int P1missileEnemy;
    public static int P2missileEnemy;

    public static int P1destroyerEnemy;
    public static int P2destroyerEnemy;

    public static bool P1bossKill;
    public static bool P2bossKill;

    void Start ()
    {
        currentHealth = maxHealth;

        SetSpeechData();

        //Tries to grab a points script if the object has any.
        addScore = gameObject.GetComponent<Points>();
        callLoot = gameObject.GetComponent<LootDropRoller>();

        if (addScore == null)
        {
            return;
        }
    }

    //Takes damage from another script and subtracts from the player health and shields.
    public void Damage(float damageAmmount, bool whatPlayer)
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

        if (currentHealth <= 0 && isBoss)
        {
            doesLootDrop = Random.Range(0.0f, 100.0f);

            if (addScore != null)
            {
                addScore.AddPoints(whatPlayer);
                if (doesLootDrop <= lootDropChance)
                {
                    callLoot.LootRoll(Random.Range(0.0f, 100.0f));
                }
            }
            Instantiate(scrap, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);

            HUDcontroller.winLevel = true;
        }
        else if (currentHealth <= 0 && isBossPart)
        {
            doesLootDrop = Random.Range(0.0f, 100.0f);

            if (addScore != null)
            {
                addScore.AddPoints(whatPlayer);
                    
                if (doesLootDrop <= lootDropChance)
                {
                    callLoot.LootRoll(Random.Range(0.0f, 100.0f));
                }
            }

            if (this.gameObject.tag == "Boss")
            {
                if (!whatPlayer)
                {
                    P1bossKill = true;
                }
                else
                {
                    P2bossKill = true;
                }
            }

            Instantiate(scrap, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        else if (currentHealth <= 0)
        {
            doesLootDrop = Random.Range(0.0f, 100.0f);

            if (this.gameObject.name == "RamEnemy(Clone)")
            {
                if (!whatPlayer)
                {
                    P1ramEnemy++;
                }
                else
                {
                    P2ramEnemy++;
                }
            }
            if (this.gameObject.name == "LightShip(Clone)")
            {
                if (!whatPlayer)
                {
                    P1lightEnemy++;
                }
                else
                {
                    P2lightEnemy++;
                }
            }
            if (this.gameObject.name == "MissileFighter(Clone)")
            {
                if (!whatPlayer)
                {
                    P1missileEnemy++;
                }
                else
                {
                    P2missileEnemy++;
                }
            }
            if (this.gameObject.name == "Destroyer(Clone)")
            {
                if (!whatPlayer)
                {
                    P1destroyerEnemy++;
                }
                else
                {
                    P2destroyerEnemy++;
                }
            }

            if (addScore != null)
            {
                addScore.AddPoints(whatPlayer);

                if (doesLootDrop <= lootDropChance)
                {
                    callLoot.LootRoll(Random.Range(0.0f, 100.0f));
                }

                Destroy(gameObject);
            }
        }
    }

    private void SetSpeechData()
    {
        P1ramEnemy = 0;
        P2ramEnemy = 0;

        P1lightEnemy = 0;
        P2lightEnemy = 0;

        P1missileEnemy = 0;
        P2missileEnemy = 0;

        P1destroyerEnemy = 0;
        P2destroyerEnemy = 0;

        P1bossKill = false;
        P2bossKill = false;
    }
}
