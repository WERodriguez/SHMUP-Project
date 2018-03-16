using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangarMenuController : MonoBehaviour
{
    public static bool P1gunTest;
    public static bool P1finalPrimary;
    public static bool P1finalSecondary;
    public static bool P1majestic;

    public static bool P2gunTest;
    public static bool P2finalPrimary;
    public static bool P2finalSecondary;
    public static bool P2majestic;

    public static int P1primaryLevelSaved;
    public static int P1secondaryLevelSaved;

    public static int P2primaryLevelSaved;
    public static int P2secondaryLevelSaved;

    private float player1MaxHealth;
    private float player1MaxShield;

    private float player2MaxHealth;
    private float player2MaxShield;

    private bool P1healthCheck;
    private bool P1shieldCheck;
    private bool P1primaryCheck;
    private bool P1secondaryCheck;

    private bool P2healthCheck;
    private bool P2shieldCheck;
    private bool P2primaryCheck;
    private bool P2secondaryCheck;

    public Text player1Credit;
    public Text player2Credit;

    public GameObject selectionButton;
    public GameObject nextButton;
    public GameObject disableText;

    public GameObject P1menu;
    public GameObject P1health;
    public GameObject P1shield;
    public GameObject P1live;
    public GameObject P1primary;
    public GameObject P1secondary;
    public GameObject P1ammo;
    public GameObject P1primaryTest;
    public GameObject P1secondaryTest;
    public GameObject P1supperTest;
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
    public GameObject P2primaryTest;
    public GameObject P2secondaryTest;
    public GameObject P2supperTest;
    public GameObject P2warningCredit;
    public GameObject P2warningUpgrade;
    public GameObject P2;

    private void Awake()
    {
        DeactivateOption();

        DeactivateP1Menu();
        DeactivateP2Menu();

        DisableWarning();
    }

    private void Start()
    {
        ActivateOption();

        SetBool();

        if (MainMenuController.onePlayer)
        {
            SavePlayer1Data();
            SetPlayer1Value();
            
            ActivateP1Menu();
        }
        if (!MainMenuController.onePlayer)
        {
            SavePlayer1Data();
            SavePlayer2Data();

            SetPlayer1Value();
            SetPlayer2Value();

            ActivateP1Menu();
            ActivateP2Menu();
        }
    }

    private void Update()
    {
        if(MainMenuController.onePlayer)
        {
            player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
        }
        if(!MainMenuController.onePlayer)
        {
            player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
            player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            DisableWarning();
            ActivateP1Menu();
            ActivateP2Menu();
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
        P1primaryTest.SetActive(true);
        P1secondaryTest.SetActive(true);
        P1supperTest.SetActive(true);
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
        P1primaryTest.SetActive(false);
        P1secondaryTest.SetActive(false);
        P1supperTest.SetActive(false);
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
        P2primaryTest.SetActive(true);
        P2secondaryTest.SetActive(true);
        P2supperTest.SetActive(true);
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
        P2primaryTest.SetActive(false);
        P2secondaryTest.SetActive(false);
        P2supperTest.SetActive(false);
        P2.SetActive(false);
    }

    private void DisableWarning()
    {
        disableText.SetActive(false);

        P1warningCredit.SetActive(false);
        P1warningUpgrade.SetActive(false);

        P2warningCredit.SetActive(false);
        P2warningUpgrade.SetActive(false);
    }

    private void SetBool()
    {
        P1gunTest = false;
        P1finalPrimary = false;
        P1finalSecondary = false;
        P1majestic = false;

        P2gunTest = false;
        P2finalPrimary = false;
        P2finalSecondary = false;
        P2majestic = false;

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
        disableText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            DisableWarning();
            ActivateP1Menu();
        }
    }
    private void P1AlreadyUpgrade()
    {
        DeactivateP1Menu();

        P1warningUpgrade.SetActive(true);
        disableText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            DisableWarning();
            ActivateP1Menu();
        }
    }

    private void P2NotEnoughCredit()
    {
        DeactivateP2Menu();

        P2warningCredit.SetActive(true);
        disableText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            DisableWarning();
            ActivateP2Menu();
        }
    }
    private void P2AlreadyUpgrade()
    {
        DeactivateP2Menu();

        P2warningUpgrade.SetActive(true);
        disableText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            DisableWarning();
            ActivateP2Menu();
        }
    }

    private void SavePlayer1Data()
    {
        P1primaryLevelSaved = PlayerWeaponController.P1currentWLevel;
        P1secondaryLevelSaved = PlayerWeaponController.P1currentSecondaryLevel;

        player1MaxHealth = PlayerHealthSystem.P1maxHealth;
        player1MaxShield = PlayerHealthSystem.P1maxShields;
    }
    private void SavePlayer2Data()
    {
        P2primaryLevelSaved = PlayerWeaponController.P2currentWLevel;
        P2secondaryLevelSaved = PlayerWeaponController.P2currentSecondaryLevel;

        player2MaxHealth = PlayerHealthSystem.P2maxHealth;
        player2MaxShield = PlayerHealthSystem.P2maxShields;
    }

    private void SetPlayer1Value()
    {
        PlayerHealthSystem.P1maxHealth = PlayerHealthSystem.P1currentHealth;
        PlayerHealthSystem.P1maxShields = PlayerHealthSystem.P1currentShields;
        PlayerHealthSystem.P1maxLives = PlayerHealthSystem.P1currentLives;

        PlayerWeaponController.P1savedWeaponLevel = PlayerWeaponController.P1currentWLevel;
        PlayerWeaponController.P1savedSecondaryLevel = PlayerWeaponController.P1currentSecondaryLevel;
        PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.P1currentSuperAmmo;
    }
    private void SetPlayer2Value()
    {
        PlayerHealthSystem.P2maxHealth = PlayerHealthSystem.P2currentHealth;
        PlayerHealthSystem.P2maxShields = PlayerHealthSystem.P2currentShields;
        PlayerHealthSystem.P2maxLives = PlayerHealthSystem.P2currentLives;

        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.P2currentWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.P2currentSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.P2currentSuperAmmo;
    }

    public void SelectionButton()
    {
        SceneManager.LoadScene("SelectionMenu");
    }

    public void NextButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void P1HealthButton()
    {
        if(PlayerHealthSystem.P1currentHealth >= player1MaxHealth)
        {
            player1Credit.text = "You already have full health";
        }

        if (P1healthCheck)
        {
            P1AlreadyUpgrade();
        }

        if(PlayerHealthSystem.P1currentHealth < player1MaxHealth && !P1healthCheck)
        {
            if(ScoreTracker.P1credit < 100)
            {
                P1NotEnoughCredit();
            }
            if(ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;
                player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;

                PlayerHealthSystem.P1currentHealth = player1MaxHealth;

                P1healthCheck = true;
            }
        }
    }
    public void P1ShieldButton()
    {
        if (PlayerHealthSystem.P1currentShields >= player1MaxShield)
        {
            player1Credit.text = "Your shield is fully charged";
        }

        if (P1shieldCheck)
        {
            P1AlreadyUpgrade();
        }

        if (PlayerHealthSystem.P1currentShields < player1MaxShield && !P1shieldCheck)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1NotEnoughCredit();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;
                player1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;

                PlayerHealthSystem.P1currentShields = player1MaxShield;

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
        if (P1primaryCheck)
        {
            P1AlreadyUpgrade();
        }

        if (!P1primaryCheck)
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
        if (P1secondaryCheck)
        {
            P1AlreadyUpgrade();
        }

        if (!P1secondaryCheck)
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
    public void P1PrimaryTestButton()
    {
        P1gunTest = true;
        P1finalPrimary = true;
    }
    public void P1SecondaryTestButton()
    {
        P1gunTest = true;
        P1finalSecondary = true;
    }
    public void P1SuperWeaponTestButton()
    {
        P1majestic = true;
    }

    public void P2HealthButton()
    {
        if (PlayerHealthSystem.P2currentHealth >= player2MaxHealth)
        {
            player2Credit.text = "You already have full health";
        }

        if (P2healthCheck)
        {
            P2AlreadyUpgrade();
        }

        if (PlayerHealthSystem.P2currentHealth < player2MaxHealth && !P2healthCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2NotEnoughCredit();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;
                player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;

                PlayerHealthSystem.P2currentHealth = player2MaxHealth;

                P2healthCheck = true;
            }
        }
    }
    public void P2ShieldButton()
    {
        if (PlayerHealthSystem.P2currentShields >= player2MaxShield)
        {
            player2Credit.text = "Your shield is fully charged";
        }

        if (P2shieldCheck)
        {
            P2AlreadyUpgrade();
        }

        if (PlayerHealthSystem.P2currentShields < player2MaxShield && !P2shieldCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2NotEnoughCredit();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;
                player2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;

                PlayerHealthSystem.P2currentShields = player2MaxShield;

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
        if (P2primaryCheck)
        {
            P2AlreadyUpgrade();
        }

        if (!P2primaryCheck)
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
        if (P2secondaryCheck)
        {
            P2AlreadyUpgrade();
        }

        if (!P2secondaryCheck)
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
    public void P2PrimaryTestButton()
    {
        P2gunTest = true;
        P2finalPrimary = true;
    }
    public void P2SecondaryTestButton()
    {
        P2gunTest = true;
        P2finalSecondary = true;
    }
    public void P2SuperWeaponTestButton()
    {
        P2majestic = true;
    }
}
