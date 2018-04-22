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

    //Checks if it is dead and stops shenanigans from happening like multi wreck spawns.
    public bool isDead;
    //Checks if boss.
    public bool isBoss;
    //Checks if multiStage boss
    public bool isMultiStageBoss;
    //Checks if boss part.
    public bool isBossPart;
    //Booleans for enemy type
    public bool heavyEnemy;

    //How fast the alpha channel is changed.
    public float fadePerSecond;
    //How long the fade will last.
    public float fadeDuration;
    //Next boss stage to spawn.
    public GameObject nextStage;
    //Explosioooons to spawn on dramatic death.
    public GameObject[] explosions;
    //What it says.
    public float timeBetweenExplosions;
    //Ranges that explosions can spawn at during overly dramatic switch. 
    //Used with Random.Range(minimum Float, max Float)
    public float xRange;
    public float yRange;
    public float zRange;


    //For boss/bosspart death
    public GameObject scrap;
    public GameObject explosion;

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

    //Checks if a ship is invulnerable. Mostly for bosses.
    public bool invulnerable;

    void Start ()
    {
        currentHealth = maxHealth;
        currentShields = maxShields;

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
        if(invulnerable)
        {
            return;
        }
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

        if (currentHealth <= 0 && isMultiStageBoss && !isDead)
        {
            isDead = true;
            Debug.Log("I'm Supposed To Die");
            StartCoroutine(DeadStage());

            doesLootDrop = Random.Range(0.0f, 100.0f);

            if (addScore != null)
            {
                addScore.AddPoints(whatPlayer);
                if (doesLootDrop <= lootDropChance)
                {
                    callLoot.LootRoll(Random.Range(0.0f, 100.0f));
                }
            }

            return;
        }
        else if (currentHealth <= 0 && isBoss && !isDead)
        {
            isDead = true;

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
        else if (currentHealth <= 0 && isBossPart && !isDead)
        {
            isDead = true;
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
        else if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            doesLootDrop = Random.Range(0.0f, 100.0f);

            if (this.gameObject.tag == "LightEnemy")
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
            if (this.gameObject.tag == "MediumEnemy")
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
            if (this.gameObject.tag == "HeavyEnemy")
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
            if (this.gameObject.tag == "OverEnemy")
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

                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                if (heavyEnemy)
                {
                    Instantiate(scrap, gameObject.transform.position, gameObject.transform.rotation);
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

    IEnumerator DeadStage()
    {
        StartCoroutine(dramaticExplosions());
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(fadeDuration);
        Instantiate(nextStage, gameObject.transform.position, Quaternion.Euler(0, 180, 0));
        Destroy(gameObject);
    }

    IEnumerator dramaticExplosions()
    {
        while (true)
        {
            //Instantiates explosions from an array that holds 3 explosions.
            //X and Z coordinates of explosions are random. Y and rotation are static.            
            Instantiate(explosions[Random.Range(0, 3)], new Vector3(gameObject.transform.position.x + Random.Range(-xRange, xRange),
                gameObject.transform.position.y + Random.Range(-yRange, yRange),
                gameObject.transform.position.z + Random.Range(-zRange, zRange)), gameObject.transform.rotation);

            yield return new WaitForSeconds(timeBetweenExplosions);
        }
    }
}
