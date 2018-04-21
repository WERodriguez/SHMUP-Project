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
    private PlayerHealthSystem playerHealthSystem;

    //HandlesAudio
    public AudioClip[] shieldSounds;
    public AudioSource shieldAudioSource;

    void Start()
    {
        playerHealthSystem = gameObject.GetComponentInParent<PlayerHealthSystem>();
        playerHealthSystem.invulnerable = true;
        shieldAudioSource = GetComponent<AudioSource>();
        shieldSounds = new AudioClip[]
        {
            (AudioClip)Resources.Load("Sounds/SuperShieldActiveV3"),
            (AudioClip)Resources.Load("Sounds/SuperShieldDeactivate"),
            (AudioClip)Resources.Load("Sounds/SuperShieldImpact")
        };

        dealDamage = false;
        StartCoroutine(ShieldActive());
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
            shieldAudioSource.PlayOneShot(shieldSounds[2]);
            Destroy(other.gameObject);
            return;
        }
        else if (other.CompareTag("EnemyBullet") && health != null)
        {
            shieldAudioSource.PlayOneShot(shieldSounds[2]);
            health.Damage(1000, whoDoIBelongTo);
            return;
        }
        if (health == null)
        {
            StopCoroutine(ShieldDamage());
            return;
        }

        shieldAudioSource.PlayOneShot(shieldSounds[2]);
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
        shieldAudioSource.PlayOneShot(shieldSounds[0]);
        yield return new WaitForSeconds(shieldDuration);
        shieldAudioSource.PlayOneShot(shieldSounds[1]);

        yield return new WaitForSeconds(shieldFizzle);

        yield return new WaitForSeconds(0.01f);
        playerHealthSystem.invulnerable = false;
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
