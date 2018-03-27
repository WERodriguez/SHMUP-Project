using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public GameObject flashHolder;
    public GameObject[] flashHolderSecondaries;

    public Sprite[] mgFlashSprites;
    public Sprite[] flakFlashSprites;
    public Sprite[] pacFlashSprites;
    public Sprite[] plasmaGunFlashSprites;


    public SpriteRenderer primarySpriteRenderer;
    public SpriteRenderer[] secondarySpriteRenderers;

    public float flashTime;

    private void Start()
    {
        Deactivate();
        DeactivateSecondaries();
    }

    public void ActivateMachinegunFlash()
    {
        //StartCoroutine(MGMuzzleFlash());
        flashHolder.SetActive(true);

        int flashSpriteIndex = Random.Range(0, mgFlashSprites.Length);
        primarySpriteRenderer.sprite = mgFlashSprites[flashSpriteIndex];

        Invoke("Deactivate", flashTime);
    }

    public void ActivateFlakCannonFlash()
    {
        StartCoroutine(FlakMuzzleFlash());
    }

    public void ActivatePACFlash()
    {
        StartCoroutine(PACMuzzleFlash());
    }

    public void ActivatePlasmaGunFlash()
    {
        StartCoroutine(PlasmaGunMuzzleFlash());
    }

    public void Deactivate()
    {
        flashHolder.SetActive(false);
    }

    public void DeactivateSecondaries()
    {
        //ballisticLight.intensity = 0.0f;
        for (int i = 0; i < flashHolderSecondaries.Length; i++)
        {
            flashHolderSecondaries[i].SetActive(false);
        }
    }

    IEnumerator MGMuzzleFlash()
    {
        flashHolder.SetActive(true);

        for (int i = 0; i < mgFlashSprites.Length; i++)
        {
            primarySpriteRenderer.sprite = mgFlashSprites[i];
            yield return new WaitForSeconds(0.03f);
        }

        Deactivate();
    }

    IEnumerator FlakMuzzleFlash()
    {
        flashHolder.SetActive(true);

        for (int i = 0; i < flakFlashSprites.Length; i++)
        {
            primarySpriteRenderer.sprite = flakFlashSprites[i];
            yield return new WaitForSeconds(0.03f);
        }

        Deactivate();
    }

    IEnumerator PACMuzzleFlash()
    {
        flashHolder.SetActive(true);

        //int flashSpriteIndex = Random.Range(0, mgFlashSprites.Length);
        for (int i = 0; i < pacFlashSprites.Length; i++)
        {
            primarySpriteRenderer.sprite = pacFlashSprites[i];
            yield return new WaitForSeconds(0.04f);
        }

        Deactivate();
    }

    IEnumerator PlasmaGunMuzzleFlash()
    {
        for (int i = 0; i < flashHolderSecondaries.Length; i++)
        {
            flashHolderSecondaries[i].SetActive(true);
        }

        for (int i = 0; i < pacFlashSprites.Length; i++)
        {
            secondarySpriteRenderers[0].sprite = plasmaGunFlashSprites[i];
            secondarySpriteRenderers[1].sprite = plasmaGunFlashSprites[i];
            yield return new WaitForSeconds(0.04f);
        }

        DeactivateSecondaries();
    }

    public void ActivateSweeperPodsFlash()
    {
        for (int i = 0; i < flashHolderSecondaries.Length; i++)
        {
            flashHolderSecondaries[i].SetActive(true);
        }

        int flashSpriteIndex1 = Random.Range(0, mgFlashSprites.Length);
        int flashSpriteIndex2 = Random.Range(0, mgFlashSprites.Length);

        secondarySpriteRenderers[0].sprite = mgFlashSprites[flashSpriteIndex1];
        secondarySpriteRenderers[1].sprite = mgFlashSprites[flashSpriteIndex2];

        Invoke("DeactivateSecondaries", flashTime);
    }
}