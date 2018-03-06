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

    void Start ()
    {
        currentHealth = maxHealth;

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
            Instantiate(scrap, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        else if (currentHealth <= 0)
        {
            doesLootDrop = Random.Range(0.0f, 100.0f);

            if (addScore != null)
            {
                addScore.AddPoints(whatPlayer);
                if (doesLootDrop <= lootDropChance)
                {
                    callLoot.LootRoll(Random.Range(0.0f, 100.0f));
                }
                Destroy(gameObject);
            }
            //This is for testing with the target dummy.
            //Because all enemies have got  points to give except that guy.
            else
            {
                if(doesLootDrop <= lootDropChance)
                {
                    callLoot.LootRoll(Random.Range(0.0f, 100.0f));
                }
                Destroy(gameObject);
            }
        }
    }
}
