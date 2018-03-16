using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangarMenuController : MonoBehaviour
{
    private int currentP1credit;
    private int currentP2credit;

    public Text P1credit;
    public Text P2credit;

    public GameObject selectionButton;
    public GameObject nextButton;

    public GameObject P1itemList;
    public GameObject P2itemList;

    private void Awake()
    {
        selectionButton.SetActive(false);
        nextButton.SetActive(false);
    }

    private void Start()
    {
        selectionButton.SetActive(true);
        nextButton.SetActive(true);

        if (MainMenuController.onePlayer)
        {
            P1itemList.SetActive(true);
        }
        else
        {
            P1itemList.SetActive(true);
            P2itemList.SetActive(true);
        }
    }

    private void Update()
    {
        if (MainMenuController.onePlayer)
        {
            StartCoroutine(SingleTimer());
        }
        else
        {
            StartCoroutine(DoubleTimer());
        }
    }

    IEnumerator SingleTimer()
    {
        yield return new WaitForSeconds(4f);/*
        matchScore.text = "" + currentTotalScore;

        yield return new WaitForSeconds(1f);
        personalScore.text = "" + currentScore_P1;

        yield return new WaitForSeconds(1f);
        credit.text = "" + currentP1credit;

        yield return new WaitForSeconds(1f);
        hull.text = "" + currentP1Health;

        yield return new WaitForSeconds(1f);
        shield.text = "" + currentP1Shields;

        yield return new WaitForSeconds(1f);
        live.text = "" + currentP1Lives;

        yield return new WaitForSeconds(1f);
        superAmmo.text = "" + currentP1SuperAmmo;*/
    }
    IEnumerator DoubleTimer()
    {
        yield return new WaitForSeconds(4f);/*
        P1matchScore.text = "" + currentTotalScore;
        P2matchScore.text = "" + currentTotalScore;

        yield return new WaitForSeconds(1f);
        P1personalScore.text = "" + currentScore_P1;
        P2personalScore.text = "" + currentScore_P2;

        yield return new WaitForSeconds(1f);
        P1credit.text = "" + currentP1credit;
        P2credit.text = "" + currentP2credit;

        yield return new WaitForSeconds(1f);
        P1hull.text = "" + currentP1Health;
        P2hull.text = "" + currentP2Health;

        yield return new WaitForSeconds(1f);
        P1shield.text = "" + currentP1Shields;
        P2shield.text = "" + currentP2Shields;

        yield return new WaitForSeconds(1f);
        P1live.text = "" + currentP1Lives;
        P2live.text = "" + currentP2Lives;

        yield return new WaitForSeconds(1f);
        P1superAmmo.text = "" + currentP1SuperAmmo;
        P2superAmmo.text = "" + currentP2SuperAmmo;*/
    }

    private void P1SetPrimaryLevel()
    {
    }
    private void P1SetSecondaryLevel()
    {
    }
    private void P1IncreaseAmmoCount()
    {
    }

    private void SetPlayer1Value()
    {
        PlayerHealthSystem.P1maxLives = PlayerHealthSystem.P1currentLives;
        PlayerHealthSystem.P1maxHealth = PlayerHealthSystem.P1currentHealth;
        PlayerHealthSystem.P1maxShields = PlayerHealthSystem.P1currentShields;

        PlayerWeaponController.P1savedWeaponLevel = PlayerWeaponController.P1currentWLevel;
        PlayerWeaponController.P1savedSecondaryLevel = PlayerWeaponController.P1currentSecondaryLevel;
        PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.P1currentSuperAmmo;
    }
    private void SetPlayer2Value()
    {
        PlayerHealthSystem.P2maxLives = PlayerHealthSystem.P2currentLives;
        PlayerHealthSystem.P2maxHealth = PlayerHealthSystem.P2currentHealth;
        PlayerHealthSystem.P2maxShields = PlayerHealthSystem.P2currentShields;

        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.P2currentWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.P2currentSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.P2currentSuperAmmo;
    }

    public void SelectionButton()
    {
        SceneManager.LoadScene("SelectionMenu");
    }

    public void NexButton()
    {
        if (MainMenuController.onePlayer)
        {
            SetPlayer1Value();
        }
        else
        {
            SetPlayer1Value();
            SetPlayer2Value();
        }

        SceneManager.LoadScene("Level1");
    }
}
