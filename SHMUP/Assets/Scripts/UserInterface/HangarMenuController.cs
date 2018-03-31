using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangarMenuController : MonoBehaviour
{
    private bool P1warning;
    private bool P1verticalSelect;
    private int P1horizontalGlowTracker;
    private int P1verticalGlowTracker;

    private bool P2warning;
    private bool P2versticalSelect;
    private int P2horizontalGlowTracker;
    private int P2verticalGlowTracker;

    private bool P1healthCheck;
    private bool P1shieldCheck;
    private bool P1primaryCheck;
    private bool P1secondaryCheck;

    private bool P2healthCheck;
    private bool P2shieldCheck;
    private bool P2primaryCheck;
    private bool P2secondaryCheck;

    public Text P1Credit;
    public Text P2Credit;

    public Text P1Warning;
    public Text P2Warning;

    public GameObject selectionButton;
    public GameObject nextButton;
    public GameObject disableP1Text;
    public GameObject disableP2Text;

    public GameObject P1menu;
    public GameObject P1health;
    public GameObject P1shield;
    public GameObject P1live;
    public GameObject P1primary;
    public GameObject P1secondary;
    public GameObject P1ammo;
    public GameObject P1healthShader;
    public GameObject P1shieldShader;
    public GameObject P1liveShader;
    public GameObject P1primaryShader;
    public GameObject P1secondaryShader;
    public GameObject P1ammoShader;
    public GameObject P1healthGlow;
    public GameObject P1shieldGlow;
    public GameObject P1liveGlow;
    public GameObject P1primaryGlow;
    public GameObject P1secondaryGlow;
    public GameObject P1ammoGlow;

    public GameObject P1warningCredit;
    public GameObject P1warningUpgrade;
    public GameObject P1;

    public GameObject P2menu;
    public GameObject P2health;
    public GameObject P2shield;
    public GameObject P2live;
    public GameObject P2primary;
    public GameObject P2secondary;
    public GameObject P2ammo;
    public GameObject P2healthShader;
    public GameObject P2shieldShader;
    public GameObject P2liveShader;
    public GameObject P2primaryShader;
    public GameObject P2secondaryShader;
    public GameObject P2ammoShader;
    public GameObject P2healthGlow;
    public GameObject P2shieldGlow;
    public GameObject P2liveGlow;
    public GameObject P2primaryGlow;
    public GameObject P2secondaryGlow;
    public GameObject P2ammoGlow;

    public GameObject P2warningCredit;
    public GameObject P2warningUpgrade;
    public GameObject P2;

    private void Awake()
    {
        DeactivateOption();

        DeactivateP1Menu();
        DeactivateP2Menu();

        DisableP1Warning();
        DisableP2Warning();
    }

    private void Start()
    {
        ActivateOption();

        SetBool();

        if (MainMenuController.onePlayer)
        {
            SetPlayer1Value();
            
            ActivateP1Menu();
        }
        if (!MainMenuController.onePlayer)
        {
            SetPlayer1Value();
            SetPlayer2Value();

            ActivateP1Menu();
            ActivateP2Menu();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            DisableP1Warning();
            ActivateP1Menu();
            ActivateP2Menu();
        }

        if (MainMenuController.onePlayer)
        {
            P1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
        }
        if (!MainMenuController.onePlayer)
        {
            P1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
            P2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;
        }
    }

    private void ActivateOption()
    {
        selectionButton.SetActive(true);
        nextButton.SetActive(true);
        P1menu.SetActive(true);
        P2menu.SetActive(true);
    }
    private void DeactivateOption()
    {
        selectionButton.SetActive(false);
        nextButton.SetActive(false);
        P1menu.SetActive(false);
        P2menu.SetActive(false);
    }

    private void ActivateP1Menu()
    {
        P1health.SetActive(true);
        P1shield.SetActive(true);
        P1live.SetActive(true);
        P1primary.SetActive(true);
        P1secondary.SetActive(true);
        P1ammo.SetActive(true);

        P1.SetActive(true);
    }
    private void DeactivateP1Menu()
    {
        P1health.SetActive(false);
        P1shield.SetActive(false);
        P1live.SetActive(false);
        P1primary.SetActive(false);
        P1secondary.SetActive(false);
        P1ammo.SetActive(false);

        P1.SetActive(false);
    }

    private void ActivateP2Menu()
    {
        P2health.SetActive(true);
        P2shield.SetActive(true);
        P2live.SetActive(true);
        P2primary.SetActive(true);
        P2secondary.SetActive(true);
        P2ammo.SetActive(true);

        P2.SetActive(true);
    }
    private void DeactivateP2Menu()
    {
        P2health.SetActive(false);
        P2shield.SetActive(false);
        P2live.SetActive(false);
        P2primary.SetActive(false);
        P2secondary.SetActive(false);
        P2ammo.SetActive(false);

        P2.SetActive(false);
    }

    private void DisableP1Warning()
    {
        disableP1Text.SetActive(false);

        P1warningCredit.SetActive(false);
        P1warningUpgrade.SetActive(false);
    }

    private void DisableP2Warning()
    {
        disableP2Text.SetActive(false);

        P2warningCredit.SetActive(false);
        P2warningUpgrade.SetActive(false);
    }

    private void SetBool()
    {
        P1healthCheck = false;
        P1shieldCheck = false;
        P1primaryCheck = false;
        P1secondaryCheck = false;

        P2healthCheck = false;
        P2shieldCheck = false;
        P2primaryCheck = false;
        P2secondaryCheck = false;
    }

    private void P1NotEnoughCredit()
    {
        DeactivateP1Menu();

        P1warningCredit.SetActive(true);
        disableP1Text.SetActive(true);
    }
    private void P1AlreadyUpgrade()
    {
        DeactivateP1Menu();

        P1warningUpgrade.SetActive(true);
        disableP2Text.SetActive(true);
    }

    private void P2NotEnoughCredit()
    {
        DeactivateP2Menu();

        P2warningCredit.SetActive(true);
        disableP1Text.SetActive(true);
    }
    private void P2AlreadyUpgrade()
    {
        DeactivateP2Menu();

        P2warningUpgrade.SetActive(true);
        disableP2Text.SetActive(true);
    }

    private void ResetPlayer1Value()
    {
        PlayerHealthSystem.P1currentLives = 0;
        PlayerHealthSystem.P1currentHealth = 0;
        PlayerHealthSystem.P1currentShields = 0;

        PlayerWeaponController.P1savedWeaponLevel = 1;
        PlayerWeaponController.P1savedSecondaryLevel = 0;
        PlayerWeaponController.P1savedSuperAmmo = 0;
    }
    private void ResetPlayer2Value()
    {
        PlayerHealthSystem.P2currentLives = 0;
        PlayerHealthSystem.P2currentHealth = 0;
        PlayerHealthSystem.P2currentShields = 0;

        PlayerWeaponController.P2savedWeaponLevel = 1;
        PlayerWeaponController.P2savedSecondaryLevel = 0;
        PlayerWeaponController.P2savedSuperAmmo = 0;
    }

    private void SetPlayer1Value()
    {
        PlayerHealthSystem.P1savedHealth = PlayerHealthSystem.P1currentHealth;
        PlayerHealthSystem.P1savedShields = PlayerHealthSystem.P1currentShields;
        PlayerHealthSystem.P1savedLives = PlayerHealthSystem.P1currentLives;

        PlayerWeaponController.P1savedWeaponLevel = PlayerWeaponController.P1currentWLevel;
        PlayerWeaponController.P1savedSecondaryLevel = PlayerWeaponController.P1currentSecondaryLevel;
        PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.P1currentSuperAmmo;
    }
    private void SetPlayer2Value()
    {
        PlayerHealthSystem.P2savedHealth = PlayerHealthSystem.P2currentHealth;
        PlayerHealthSystem.P2savedShields = PlayerHealthSystem.P2currentShields;
        PlayerHealthSystem.P2savedLives = PlayerHealthSystem.P2currentLives;

        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.P2currentWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.P2currentSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.P2currentSuperAmmo;
    }
    /*
    public void SelectionButton()
    {
        ResetPlayer1Value();
        ResetPlayer2Value();

        SceneManager.LoadScene("SelectionMenu");
    }

    public void NextButton()
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

    public void P1HealthButton()
    {
        if(PlayerHealthSystem.P1currentHealth >= PlayerHealthSystem.P1maxHealth)
        {
            P1Warni.text = "You already have full health";
        }

        if (P1healthCheck)
        {
            P1AlreadyUpgrade();
        }

        if(PlayerHealthSystem.P1currentHealth < PlayerHealthSystem.P1maxHealth && !P1healthCheck)
        {
            if(ScoreTracker.P1credit < 100)
            {
                P1NotEnoughCredit();
            }
            if(ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;
                P1Cra.text = "Player 1 has: " + ScoreTracker.P1credit;

                PlayerHealthSystem.P1currentHealth = PlayerHealthSystem.P1maxHealth;

                P1healthCheck = true;
            }
        }
    }
    public void P1ShieldButton()
    {
        if (PlayerHealthSystem.P1currentShields >= PlayerHealthSystem.P1maxShields)
        {
            player1Credit.text = "Your shield is fully charged";
        }

        if (P1shieldCheck)
        {
            P1AlreadyUpgrade();
        }

        if (PlayerHealthSystem.P1currentShields < PlayerHealthSystem.P1maxShields && !P1shieldCheck)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1NotEnoughCredit();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;
                player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;

                PlayerHealthSystem.P1currentShields = PlayerHealthSystem.P1maxShields;

                P1shieldCheck = true;
            }
        }
    }
    public void P1LiveButton()
    {
        if (PlayerHealthSystem.P1currentLives >= 5)
        {
            PlayerHealthSystem.P1currentLives = 5;

            player1Credit.text = "5 is the number of Max Lives";
        }

        if (PlayerHealthSystem.P1currentLives < 5)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1NotEnoughCredit();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;
                player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;

                PlayerHealthSystem.P1currentLives++;
            }
        }
    }
    public void P1PrimaryButton()
    {
        if(PlayerWeaponController.P1currentWLevel >= 5)
        {
            PlayerWeaponController.P1currentWLevel = 5;

            player1Credit.text = "Your primary weapon is at max level";
        }
        
        if (P1primaryCheck)
        {
            P1AlreadyUpgrade();
        }

        if (PlayerWeaponController.P1currentWLevel < 5 && !P1primaryCheck)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1NotEnoughCredit();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;
                player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;

                PlayerWeaponController.P1currentWLevel++;

                P1primaryCheck = true;
            }
        }
    }
    public void P1SecondaryButton()
    {
        if (PlayerWeaponController.P1currentSecondaryLevel >= 5)
        {
            PlayerWeaponController.P1currentSecondaryLevel = 5;

            player1Credit.text = "Your secondary weapon is at max level";
        }

        if (P1secondaryCheck)
        {
            P1AlreadyUpgrade();
        }

        if (PlayerWeaponController.P1currentSecondaryLevel < 5 && !P1secondaryCheck)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1NotEnoughCredit();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;
                player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;

                PlayerWeaponController.P1currentSecondaryLevel++;

                P1secondaryCheck = true;
            }
        }
    }
    public void P1AmmoButton()
    {
        if (PlayerWeaponController.P1currentSuperAmmo >= 5)
        {
            PlayerWeaponController.P1currentSuperAmmo = 5;

            player1Credit.text = "5 is the highest number of ammo you can have";
        }

        if (PlayerWeaponController.P1currentSuperAmmo < 5)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1NotEnoughCredit();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;
                player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;

                PlayerWeaponController.P1currentSuperAmmo++;
            }
        }
    }

    public void P2HealthButton()
    {
        if (PlayerHealthSystem.P2currentHealth >= PlayerHealthSystem.P2maxHealth)
        {
            player2Credit.text = "You already have full health";
        }

        if (P2healthCheck)
        {
            P2AlreadyUpgrade();
        }

        if (PlayerHealthSystem.P2currentHealth < PlayerHealthSystem.P2maxHealth && !P2healthCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2NotEnoughCredit();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;
                player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;

                PlayerHealthSystem.P2currentHealth = PlayerHealthSystem.P2maxHealth;

                P2healthCheck = true;
            }
        }
    }
    public void P2ShieldButton()
    {
        if (PlayerHealthSystem.P2currentShields >= PlayerHealthSystem.P2maxShields)
        {
            player2Credit.text = "Your shield is fully charged";
        }

        if (P2shieldCheck)
        {
            P2AlreadyUpgrade();
        }

        if (PlayerHealthSystem.P2currentShields < PlayerHealthSystem.P2maxShields && !P2shieldCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2NotEnoughCredit();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;
                player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;

                PlayerHealthSystem.P2currentShields = PlayerHealthSystem.P2maxShields;

                P2shieldCheck = true;
            }
        }
    }
    public void P2LiveButton()
    {
        if (PlayerHealthSystem.P2currentLives >= 5)
        {
            PlayerHealthSystem.P2currentLives = 5;

            player2Credit.text = "5 is the number of Max Lives";
        }

        if (PlayerHealthSystem.P2currentLives < 5)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2NotEnoughCredit();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;
                player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;

                PlayerHealthSystem.P2currentLives++;
            }
        }
    }
    public void P2PrimaryButton()
    {
        if (PlayerWeaponController.P2currentWLevel >= 5)
        {
            PlayerWeaponController.P2currentWLevel = 5;

            player2Credit.text = "Your primary weapon is at max level";
        }

        if (P2primaryCheck)
        {
            P2AlreadyUpgrade();
        }

        if (PlayerWeaponController.P2currentWLevel < 5 && !P2primaryCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2NotEnoughCredit();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;
                player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;

                PlayerWeaponController.P2currentWLevel++;

                P2primaryCheck = true;
            }
        }
    }
    public void P2SecondaryButton()
    {
        if (PlayerWeaponController.P2currentSecondaryLevel >= 5)
        {
            PlayerWeaponController.P2currentSecondaryLevel = 5;

            player2Credit.text = "Your secondary weapon is at max level";
        }

        if (P2secondaryCheck)
        {
            P2AlreadyUpgrade();
        }

        if (PlayerWeaponController.P2currentSecondaryLevel < 5 && !P2secondaryCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2NotEnoughCredit();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;
                player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;

                PlayerWeaponController.P2currentSecondaryLevel++;

                P2secondaryCheck = true;
            }
        }
    }
    public void P2AmmoButton()
    {
        if (PlayerWeaponController.P2currentSuperAmmo >= 5)
        {
            PlayerWeaponController.P2currentSuperAmmo = 5;

            player2Credit.text = "5 is the highest number of ammo you can have";
        }

        if (PlayerWeaponController.P2currentSuperAmmo < 5)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2NotEnoughCredit();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;
                player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;

                PlayerWeaponController.P2currentSuperAmmo++;
            }
        }
    }
    */
}
