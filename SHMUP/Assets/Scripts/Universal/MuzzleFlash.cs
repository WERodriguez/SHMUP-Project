using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    //Primary weapon muzzle flash.
    public GameObject flashHolder;
    //Secondary weapon muzzle flashes.
    public GameObject[] flashHolderSecondaries;

    //Hold the sprites for muzzle flashes.
    public Sprite[] machineGunFlashSprites;
    public Sprite[] flakCannonFlashSprites;
    public Sprite[] plasmaGunFlashSprites;
    public Sprite[] PACFlashSprites;

    //Primary weapon lights
    public Light ballisticLight;
    public Light energyLight;

    //Secondary weapon lights.
    public Light[] ballisticLightSecondaries;
    public Light[] energyLightSecondaries;

    //Controls the sprite renderer
    public SpriteRenderer spriteRenderer;

    public float lightIntensity;

    private void Start()
    {
        Deactivate();
    }

    public void ActivateMachinegunFlash()
    {
        StartCoroutine(machineGunMuzzleFlash());
    }

    public void Deactivate()
    {
        ballisticLight.intensity = 0.0f;
        flashHolder.SetActive(false);
    }

    IEnumerator machineGunMuzzleFlash()
    {
        lightIntensity = 8.0f;
        flashHolder.SetActive(true);

        for (int i = 0; i < machineGunFlashSprites.Length; i++)
        {
            spriteRenderer.sprite = machineGunFlashSprites[i];
            ballisticLight.intensity = lightIntensity;
            lightIntensity -= 2;
            yield return new WaitForSeconds(0.02f);
        }

        Invoke("Deactivate",0.0f);
    }
}
