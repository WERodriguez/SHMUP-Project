using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeamCannon : MonoBehaviour
{
    //Grabs the health system from an enemy target.
    private PlayerHealthSystem health;

    //How Much Damage the beam does.
    public float damageAmmount;
    //How long between damage tics.
    public float damageTicRate;
    //How long it takes for the beam to charge before it fires.
    public float chargeTime;
    //How long the beam will last once active.
    public float beamDuration;
    //How long it takes for the beam to fizzle once its duration is over.
    public float beamFizzle;
    //Whether or not the beam still deals damage.
    private bool dealDamage;

    //Place Holder Particle effect.
    private GameObject beamCharge;
    //Place Holder Actual Beam.
    private GameObject beam;

    //Holds components in child objects.
    public Component[] childRenderers;
    private CapsuleCollider beamCollider;
    public float fadePerSecond;
    public bool canIFadeYet;

    //HandlesAudio
    public AudioClip[] beamSounds;
    public AudioSource beamAudioSource;

    // Use this for initialization
    void Start ()
    {
        beamAudioSource = GetComponent<AudioSource>();

        beamSounds = new AudioClip[]
        {
            (AudioClip)Resources.Load("Sounds/BeamCannonFiringV2"),
            (AudioClip)Resources.Load("Sounds/BeamCannonPowerDown"),
        };

        dealDamage = false;
        canIFadeYet = false;
        beamCollider = GetComponent<CapsuleCollider>();
        //This is the really weird way Unity decided to set colliders to active/inactive.
        //Since the collider is on by default. This line turns off the collider on start.
        //When this line pops up again it will turn on the collider.
        beamCollider.enabled = !beamCollider.enabled;
        StartCoroutine(BeamFire());
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Checks if the beam can fade or if it's done fading.
        if(canIFadeYet)
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
        if (other.CompareTag("Boundary") || other.CompareTag("LightEnemy") || other.CompareTag("MediumEnemy") || other.CompareTag("HeavyEnemy") || other.CompareTag("OverEnemy") || other.CompareTag("EnemyBullet"))
        {
            return;
        }

        health = other.GetComponent<PlayerHealthSystem>();

        if (health == null)
        {
            return;
        }
        dealDamage = true;
        StartCoroutine(BeamDamage());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("LightEnemy") || other.CompareTag("MediumEnemy") || other.CompareTag("HeavyEnemy") || other.CompareTag("OverEnemy") || other.CompareTag("EnemyBullet"))
        {
            return;
        }

        health = other.GetComponent<PlayerHealthSystem>();

        if (health == null)
        {
            return;
        }

        dealDamage = false;
        StopCoroutine(BeamDamage());
    }

    IEnumerator BeamFire()
    {
        //Activates place holder charge effect.
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(chargeTime);
        //Deactivates charge effect.
        transform.GetChild(1).gameObject.SetActive(false);
        //Activates the beam.

        beamAudioSource.PlayOneShot(beamSounds[0]);

        beamCollider.enabled = !beamCollider.enabled;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(beamDuration);

        //Tells the beam it can start fading.
        canIFadeYet = true;
        beamAudioSource.PlayOneShot(beamSounds[1]);

        yield return new WaitForSeconds(beamFizzle);
        //Tells the beam it can stop fading.
        canIFadeYet = false;
        //Disables the beam's graphics.
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        //Disables the beam's collider.
        //Yeah this is a really weird way they decided to set it up but this is how it works.
        beamCollider.enabled = !beamCollider.enabled;
        //Destroy's the game object because it no longer needs to exist!
        Destroy(gameObject);
    }
    IEnumerator BeamDamage()
    {
        while(dealDamage)
        {
            health.Damage(damageAmmount);
            yield return new WaitForSeconds(damageTicRate);
        }
    }
}
