using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaShield : MonoBehaviour
{
    //Grabs the health system from an enemy target.
    private HealthSystem health;

    public bool whoDoIBelongTo;
    //How Much Damage the beam does.
    public float damageAmmount;
    //How long between damage tics.
    public float damageTicRate;
    //How long the shield will last once active.
    public float shieldDuration;
    //How long it takes for the shield to fizzle once its duration is over.
    public float shieldFizzle;
    //Whether or not the shield still deals damage.
    private bool dealDamage;

    //Place Holder shield graphics.
    private GameObject shield;

    //Holds components in child objects.
    public Component[] childRenderers;

    //How much to fade per second.
    public float fadePerSecond;
    //Should the thing start to fade.
    public bool canIFadeYet;


    // Use this for initialization
    void Start()
    {
        dealDamage = false;
        canIFadeYet = false;
        StartCoroutine(ShieldActive());
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the beam can fade or if it's done fading.
        if (canIFadeYet)
        {
            //StartCoroutine(FadeOut());
            childRenderers = GetComponentsInChildren<Renderer>();

            //Goes through all the children and fades them out.
            foreach (Renderer childObjectColor in childRenderers)
            {
                //Keeping this around just for notes. This is how you change material colors
                //childObjectToFade.material.color = Color.red;
                childObjectColor.material.color = new Color(childObjectColor.material.color.r, childObjectColor.material.color.g, childObjectColor.material.color.b,
                childObjectColor.material.color.a - (fadePerSecond * Time.deltaTime));
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player"))
        {
            return;
        }

        health = other.GetComponent<HealthSystem>();

        if (other.CompareTag("EnemyBullet") && health == null)
        {
            Destroy(other.gameObject);
            return;
        }
        else if (other.CompareTag("EnemyBullet") && health != null)
        {
            health.Damage(1000, whoDoIBelongTo);
            return;
        }
        if (health == null)
        {
            StopCoroutine(ShieldDamage());
            return;
        }

        dealDamage = true;
        StartCoroutine(ShieldDamage());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player"))
        {
            return;
        }

        health = other.GetComponent<HealthSystem>();

        if (other.CompareTag("EnemyBullet") && health == null)
        {
            Destroy(other.gameObject);
            return;
        }
        else if (other.CompareTag("EnemyBullet") && health != null)
        {
            health.Damage(1000, whoDoIBelongTo);
            return;
        }
        if (health == null)
        {
            StopCoroutine(ShieldDamage());
            return;
        }

        dealDamage = false;
        StopCoroutine(ShieldDamage());
    }

    IEnumerator ShieldActive()
    {
        yield return new WaitForSeconds(shieldDuration);

        //Tells the beam it can start fading.
        canIFadeYet = true;

        yield return new WaitForSeconds(shieldFizzle);
        //Tells the beam it can stop fading.
        canIFadeYet = false;
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
    IEnumerator ShieldDamage()
    {
        while (dealDamage)
        {
            health.Damage(damageAmmount, whoDoIBelongTo);
            yield return new WaitForSeconds(damageTicRate);        
        }       
    }
}
