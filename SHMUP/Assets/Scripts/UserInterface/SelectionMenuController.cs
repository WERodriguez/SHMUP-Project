using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionMenuController : MonoBehaviour
{
    public Text characterStat;
    public Text shipStat;
    public Text primaryStat;
    public Text secondaryStat;
    public Text specialStat;

    public Text P1characterStat;
    public Text P1shipStat;
    public Text P1primaryStat;
    public Text P1secondaryStat;
    public Text P1specialStat;

    public Text P2characterStat;
    public Text P2shipStat;
    public Text P2primaryStat;
    public Text P2secondaryStat;
    public Text P2specialStat;

    private int glowTracker;
    private int P1glowTracker;
    private int P2glowTracker;
    private int maxSingleGlowTracker;
    private int maxP2GLowTracker;

    private bool choosing;
    private bool P1choosing;
    private bool P2choosing;

    private bool waiting;
    private bool gamePlay;
    private bool breakInstruction;

    public Image singleReturnButtonGlow;
    public Image singleStartButtonGlow;
    public Image doubleReturnButtonGlow;
    public Image doubleStartButtonGlow;

    public Image characterButtonGlow;
    public Image shipButtonGlow;
    public Image primaryButtonGlow;
    public Image secondaryButtonGlow;
    public Image specialButtonGlow;
    public Image P1characterButtonGlow;
    public Image P1shipButtonGlow;
    public Image P1primaryButtonGlow;
    public Image P1secondaryButtonGlow;
    public Image P1specialButtonGlow;
    public Image P2characterButtonGlow;
    public Image P2shipButtonGlow;
    public Image P2primaryButtonGlow;
    public Image P2secondaryButtonGlow;
    public Image P2specialButtonGlow;

    public Image toggleLeftGlow;
    public Image toggleRightGlow;
    public Image P1toggleLeftGlow;
    public Image P1toggleRightGlow;
    public Image P2toggleLeftGlow;
    public Image P2toggleRightGlow;

    public static int P1characterType;
    public static int P1shipType;
    public static int P1primaryType;
    public static int P1secondaryType;
    public static int P1specialType;

    public static int P2characterType;
    public static int P2shipType;
    public static int P2primaryType;
    public static int P2secondaryType;
    public static int P2specialType;

    private int P1toggleData;
    private bool character;
    private bool ship;
    private bool primary;
    private bool secondary;
    private bool special;
    private bool P1character;
    private bool P1ship;
    private bool P1primary;
    private bool P1secondary;
    private bool P1special;

    private int P2toggleData;
    private bool P2character;
    private bool P2ship;
    private bool P2primary;
    private bool P2secondary;
    private bool P2special;

    public GameObject singleMenu;
    public GameObject P1Menu;
    public GameObject P2Menu;
    public GameObject singleMenuBackground;
    public GameObject doubleMenuBackground;

    public GameObject guideLine;
    public GameObject guidelineBackground;

    public GameObject singleReturnButton;
    public GameObject singleStartButton;
    public GameObject doubleReturnButton;
    public GameObject doubleStartButton;

    public GameObject characterButton;
    public GameObject shipButton;
    public GameObject primaryButton;
    public GameObject secondaryButton;
    public GameObject specialButton;
    public GameObject P1characterButton;
    public GameObject P1shipButton;
    public GameObject P1primaryButton;
    public GameObject P1secondaryButton;
    public GameObject P1specialButton;
    public GameObject P2characterButton;
    public GameObject P2shipButton;
    public GameObject P2primaryButton;
    public GameObject P2secondaryButton;
    public GameObject P2specialButton;

    public GameObject characterButtonShader;
    public GameObject shipButtonShader;
    public GameObject primaryButtonShader;
    public GameObject secondaryButtonShader;
    public GameObject specialButtonShader;
    public GameObject P1characterButtonShader;
    public GameObject P1shipButtonShader;
    public GameObject P1primaryButtonShader;
    public GameObject P1secondaryButtonShader;
    public GameObject P1specialButtonShader;
    public GameObject P2characterButtonShader;
    public GameObject P2shipButtonShader;
    public GameObject P2primaryButtonShader;
    public GameObject P2secondaryButtonShader;
    public GameObject P2specialButtonShader;

    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;
    public GameObject P1character1;
    public GameObject P1character2;
    public GameObject P1character3;
    public GameObject P1character4;
    public GameObject P2character1;
    public GameObject P2character2;
    public GameObject P2character3;
    public GameObject P2character4;

    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    public GameObject ship4;
    public GameObject ship5;
    public GameObject P1ship1;
    public GameObject P1ship2;
    public GameObject P1ship3;
    public GameObject P1ship4;
    public GameObject P1ship5;
    public GameObject P2ship1;
    public GameObject P2ship2;
    public GameObject P2ship3;
    public GameObject P2ship4;
    public GameObject P2ship5;

    public GameObject primary1;
    public GameObject primary2;
    public GameObject primary3;
    public GameObject P1primary1;
    public GameObject P1primary2;
    public GameObject P1primary3;
    public GameObject P2primary1;
    public GameObject P2primary2;
    public GameObject P2primary3;

    public GameObject secondary1;
    public GameObject secondary2;
    public GameObject secondary3;
    public GameObject P1secondary1;
    public GameObject P1secondary2;
    public GameObject P1secondary3;
    public GameObject P2secondary1;
    public GameObject P2secondary2;
    public GameObject P2secondary3;

    public GameObject special1;
    public GameObject special2;
    public GameObject special3;
    public GameObject P1special1;
    public GameObject P1special2;
    public GameObject P1special3;
    public GameObject P2special1;
    public GameObject P2special2;
    public GameObject P2special3;

    public GameObject toggleLeft;
    public GameObject toggleRight;
    public GameObject P1toggleLeft;
    public GameObject P1toggleRight;
    public GameObject P2toggleLeft;
    public GameObject P2toggleRight;

    public Animator singleCharacter;
    public Animator singleShip;
    public Animator singlePrimary;
    public Animator singleSecondary;
    public Animator singleSpecial;
    public Animator singleReturn;
    public Animator doubleCharacter1;
    public Animator doubleShip1;
    public Animator doublePrimary1;
    public Animator doubleSecondary1;
    public Animator doubleSpecial1;
    public Animator doubleCharacter2;
    public Animator doubleShip2;
    public Animator doublePrimary2;
    public Animator doubleSecondary2;
    public Animator doubleSpecial2;

    private void Awake()
    {
        DeactivateSingleSelection();
        DeactivatePlayer1Selection();
        DeactivatePlayer2Selection();

        DeactivateSingleToggle();
        DeactivateP1Toggle();
        DeactivateP2Toggle();

        DeactivateSingleCharacterSelect();
        DeactivateP1CharacterSelect();
        DeactivateP2CharacterSelect();

        DeactivateSingleShipSelect();
        DeactivateP1ShipSelect();
        DeactivateP2ShipSelect();

        DeactivateSinglePrimarySelect();
        DeactivateP1PrimarySelect();
        DeactivateP2PrimarySelect();

        DeactivateSingleSecondarySelect();
        DeactivateP1SecondarySelect();
        DeactivateP2SecondarySelect();

        DeactivateSingleSpecialSelect();
        DeactivateP1SpecialSelect();
        DeactivateP2SpecialSelect();

        DeactivateShader();

        ResetBool();
        ResetInt();
        ResetP1ToggleData();
        ResetP2ToggleData();

        ResetGlow();
        ResetP1Glow();
        ResetP2Glow();

        ResetToggleGlow();
        ResetP1ToggleGlow();
        ResetP2ToggleGlow();

        DeactivateStat();
        DeactivateP1Stat();
        DeactivateP2Stat();

        maxSingleGlowTracker = 6;
        maxP2GLowTracker = 5;

        choosing = false;
        P1choosing = false;
        P2choosing = false;

        waiting = false;
        gamePlay = false;
        breakInstruction = false;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (waiting)
        {
            if (!gamePlay)
            {
                if (MainMenuController.onePlayer)
                {
                    if (P1characterType > 0 && P1shipType > 0 && P1primaryType > 0 && P1secondaryType > 0 && P1specialType > 0)
                    {
                        maxSingleGlowTracker = 7;

                        singleStartButton.SetActive(true);
                    }
                    else
                    {
                        singleStartButton.SetActive(false);
                    }

                    if (glowTracker > maxSingleGlowTracker)
                    {
                        glowTracker = maxSingleGlowTracker;
                    }
                    if (glowTracker <= 1)
                    {
                        glowTracker = 1;

                        ResetGlow();
                        singleReturnButtonGlow.fillAmount = 1;
                    }
                    if (glowTracker == 2)
                    {
                        ResetGlow();
                        characterButtonGlow.fillAmount = 1;
                    }
                    if (glowTracker == 3)
                    {
                        ResetGlow();
                        shipButtonGlow.fillAmount = 1;
                    }
                    if (glowTracker == 4)
                    {
                        ResetGlow();
                        primaryButtonGlow.fillAmount = 1;
                    }
                    if (glowTracker == 5)
                    {
                        ResetGlow();
                        secondaryButtonGlow.fillAmount = 1;
                    }
                    if (glowTracker == 6)
                    {
                        ResetGlow();
                        specialButtonGlow.fillAmount = 1;
                    }
                    if (glowTracker >= 7)
                    {
                        glowTracker = 7;

                        ResetGlow();
                        singleStartButtonGlow.fillAmount = 1;
                    }

                    if (P1toggleData <= 1)
                    {
                        ResetToggleGlow();
                        toggleLeftGlow.fillAmount = 1;

                        P1toggleData = 1;

                        if (character == true)
                        {
                            DeactivateSingleCharacterSelect();
                            character1.SetActive(true);

                            DeactivateStat();
                            characterStat.enabled = true;
                            characterStat.text = "Name: Character A\nDescription:";
                        }
                        if (ship == true)
                        {
                            DeactivateSingleShipSelect();
                            ship1.SetActive(true);

                            DeactivateStat();
                            shipStat.enabled = true;
                            shipStat.text = "Name: Light Ship\nDescription: \nHealth: 100\nShield: 75\nLives: 2/5";
                        }
                        if (primary == true)
                        {
                            DeactivateSinglePrimarySelect();
                            primary1.SetActive(true);

                            DeactivateStat();
                            primaryStat.enabled = true;
                            primaryStat.text = "Name: Machine Gun\nDescription: Basic rapid fire weapon. Spread increases with upgrades\nFire Rate: *****\nDamage: *\nArea of Effect: *";
                        }
                        if (secondary == true)
                        {
                            DeactivateSingleSecondarySelect();
                            secondary1.SetActive(true);

                            DeactivateStat();
                            secondaryStat.enabled = true;
                            secondaryStat.text = "Name: Homing Missiles\nDescription: Fires missiles that seek out targets. Fire rate and number of missiles increase with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ****\n";
                        }
                        if (special == true)
                        {
                            DeactivateSingleSpecialSelect();
                            special1.SetActive(true);

                            DeactivateStat();
                            specialStat.enabled = true;
                            specialStat.text = "Name: Mega Bomb\nDescription: Deploy a heavy bomb that expands to cover a large area for quick devastation.\nDamage: ****\nArea of Effect: *****\nDuration: **\n";
                        }
                    }
                    if (P1toggleData == 2)
                    {
                        if (character == true)
                        {
                            DeactivateSingleCharacterSelect();
                            character2.SetActive(true);

                            DeactivateStat();
                            characterStat.enabled = true;
                            characterStat.text = "Name: Nomad\nDescription: An overconfident, hotshot pilot that hunts the machine menace wherever it goes.";
                        }
                        if (ship == true)
                        {
                            DeactivateSingleShipSelect();
                            ship2.SetActive(true);

                            DeactivateStat();
                            shipStat.enabled = true;
                            shipStat.text = "Name: Medium Ship\nDescription: \nHealth: 125\nShield: 100\nLives: 2/5";
                        }
                        if (primary == true)
                        {
                            DeactivateSinglePrimarySelect();
                            primary2.SetActive(true);

                            DeactivateStat();
                            primaryStat.enabled = true;
                            primaryStat.text = "Name: Flak Cannon\nDescription: Area denial weapon. Shots explode mid air and damage enemies passing through the blast. Covers a wider area with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ***";
                        }
                        if (secondary == true)
                        {
                            DeactivateSingleSecondarySelect();
                            secondary2.SetActive(true);

                            DeactivateStat();
                            secondaryStat.enabled = true;
                            secondaryStat.text = "Name: Sweeper Pods\nDescription: Wing mounted machine gun pods. Sweep out to the sides with each upgrade to cover a large area.\nFire Rate: *****\nDamage: *\nArea of Effect: **";
                        }
                        if (special == true)
                        {
                            DeactivateSingleSpecialSelect();
                            special2.SetActive(true);

                            DeactivateStat();
                            specialStat.enabled = true;
                            specialStat.text = "Name: Beam Cannon\nDescription: Someone thought it was a good idea to mount a capital class cannon onto a fighter. Huge beam that shoots through multiple targets.\nDamage: *****\nArea of Effect: *****\nDuration: *****";
                        }
                    }
                    if (P1toggleData == 3)
                    {
                        if (character == true)
                        {
                            DeactivateSingleCharacterSelect();
                            character3.SetActive(true);

                            DeactivateStat();
                            characterStat.enabled = true;
                            characterStat.text = "Name: Character C\nDescription:";
                        }
                        if (ship == true)
                        {
                            DeactivateSingleShipSelect();
                            ship3.SetActive(true);

                            DeactivateStat();
                            shipStat.enabled = true;
                            shipStat.text = "Name: Light Ship\nDescription: \nHealth: 150\nShield: 125\nLives: 2/5";
                        }
                        if (primary == true)
                        {
                            DeactivateSinglePrimarySelect();
                            primary3.SetActive(true);

                            DeactivateStat();
                            primaryStat.enabled = true;
                            primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (secondary == true)
                        {
                            DeactivateSingleSecondarySelect();
                            secondary3.SetActive(true);

                            DeactivateStat();
                            secondaryStat.enabled = true;
                            secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (special == true)
                        {
                            DeactivateSingleSpecialSelect();
                            special3.SetActive(true);

                            DeactivateStat();
                            specialStat.enabled = true;
                            specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }
                    if (P1toggleData == 4)
                    {
                        if (character == true)
                        {
                            DeactivateSingleCharacterSelect();
                            character4.SetActive(true);

                            DeactivateStat();
                            characterStat.enabled = true;
                            characterStat.text = "Name: Jaeger\nDescription: A cocky, hot headed pilot on the hunt for more fame and glory.";
                        }
                        if (ship == true)
                        {
                            DeactivateSingleShipSelect();
                            ship4.SetActive(true);

                            DeactivateStat();
                            shipStat.enabled = true;
                            shipStat.text = "Name: Lambo Shooter\nDescription: \nHealth: 175\nShield: 150\nLives: 2/5";
                        }
                        if (primary == true)
                        {
                            P1toggleData = 3;

                            DeactivateSinglePrimarySelect();
                            primary3.SetActive(true);

                            DeactivateStat();
                            primaryStat.enabled = true;
                            primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (secondary == true)
                        {
                            P1toggleData = 3;

                            DeactivateSingleSecondarySelect();
                            secondary3.SetActive(true);

                            DeactivateStat();
                            secondaryStat.enabled = true;
                            secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (special == true)
                        {
                            P1toggleData = 3;

                            DeactivateSingleSpecialSelect();
                            special3.SetActive(true);

                            DeactivateStat();
                            specialStat.enabled = true;
                            specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }
                    if (P1toggleData >= 5)
                    {
                        if (character == true)
                        {
                            P1toggleData = 4;

                            DeactivateSingleCharacterSelect();
                            character4.SetActive(true);

                            DeactivateStat();
                            characterStat.enabled = true;
                            characterStat.text = "Name: Jaeger\nDescription: A cocky, hot headed pilot on the hunt for more fame and glory.";
                        }
                        if (ship == true)
                        {
                            P1toggleData = 5;

                            DeactivateSingleShipSelect();
                            ship5.SetActive(true);

                            DeactivateStat();
                            shipStat.enabled = true;
                            shipStat.text = "Name: Truck Shooter\nDescription: \nHealth: 200\nShield: 200\nLives: 2/5";
                        }
                        if (primary == true)
                        {
                            P1toggleData = 3;

                            DeactivateSinglePrimarySelect();
                            primary3.SetActive(true);

                            DeactivateStat();
                            primaryStat.enabled = true;
                            primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (secondary == true)
                        {
                            P1toggleData = 3;

                            DeactivateSingleSecondarySelect();
                            secondary3.SetActive(true);

                            DeactivateStat();
                            secondaryStat.enabled = true;
                            secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (special == true)
                        {
                            P1toggleData = 3;

                            DeactivateSingleSpecialSelect();
                            special3.SetActive(true);

                            DeactivateStat();
                            specialStat.enabled = true;
                            specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.W) && !choosing)
                    {
                        glowTracker--;
                    }
                    if (Input.GetKeyDown(KeyCode.S) && !choosing)
                    {
                        glowTracker++;
                    }

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        ResetToggleGlow();
                        toggleLeftGlow.fillAmount = 1;

                        P1toggleData--;
                    }
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        ResetToggleGlow();
                        toggleRightGlow.fillAmount = 1;

                        P1toggleData++;
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (!choosing)
                        {
                            if (glowTracker == 1)
                            {
                                ReturnButton();
                            }
                            if (glowTracker == 2)
                            {
                                SinglePlayerCharacterButton();
                            }
                            if (glowTracker == 3)
                            {
                                SinglePlayerShipButton();
                            }
                            if (glowTracker == 4)
                            {
                                SinglePlayerPrimaryButton();
                            }
                            if (glowTracker == 5)
                            {
                                SinglePlayerSecondaryButton();
                            }
                            if (glowTracker == 6)
                            {
                                SinglePlayerSpecialButton();
                            }
                            if (glowTracker == 7)
                            {
                                StartCoroutine(ActivateSingleStartButton());
                            }
                        }
                        else
                        {
                            if (P1toggleData == 1)
                            {
                                if (character == true)
                                {
                                    P1characterType = 1;
                                }
                                if (ship == true)
                                {
                                    P1shipType = 1;

                                    P1LightShipData();
                                    Player1Data();
                                }
                                if (primary == true)
                                {
                                    P1primaryType = 1;
                                }
                                if (secondary == true)
                                {
                                    P1secondaryType = 1;
                                }
                                if (special == true)
                                {
                                    P1specialType = 1;
                                }
                            }
                            if (P1toggleData == 2)
                            {
                                if (character == true)
                                {
                                    P1characterType = 2;
                                }
                                if (ship == true)
                                {
                                    P1shipType = 2;

                                    P1MediumShipData();
                                    Player1Data();
                                }
                                if (primary == true)
                                {
                                    P1primaryType = 2;
                                }
                                if (secondary == true)
                                {
                                    P1secondaryType = 2;
                                }
                                if (special == true)
                                {
                                    P1specialType = 2;
                                }
                            }
                            if (P1toggleData == 3)
                            {
                                if (character == true)
                                {
                                    P1characterType = 3;
                                }
                                if (ship == true)
                                {
                                    P1shipType = 3;

                                    P1HeavyShipData();
                                    Player1Data();
                                }
                                if (primary == true)
                                {
                                    P1primaryType = 3;
                                }
                                if (secondary == true)
                                {
                                    P1secondaryType = 3;
                                }
                                if (special == true)
                                {
                                    P1specialType = 3;
                                }
                            }
                            if (P1toggleData == 4)
                            {
                                if (character == true)
                                {
                                    P1characterType = 4;
                                }
                                if (ship == true)
                                {
                                    P1shipType = 4;

                                    P1LamboShooterData();
                                    Player1Data();
                                }
                                if (primary == true)
                                {
                                    P1primaryType = 3;
                                }
                                if (secondary == true)
                                {
                                    P1secondaryType = 3;
                                }
                                if (special == true)
                                {
                                    P1specialType = 3;
                                }
                            }
                            if (P1toggleData == 5)
                            {
                                if (character == true)
                                {
                                    P1characterType = 4;
                                }
                                if (ship == true)
                                {
                                    P1shipType = 5;

                                    P1TruckShooterData();
                                    Player1Data();
                                }
                                if (primary == true)
                                {
                                    P1primaryType = 3;
                                }
                                if (secondary == true)
                                {
                                    P1secondaryType = 3;
                                }
                                if (special == true)
                                {
                                    P1specialType = 3;
                                }
                            }

                            DeactivateSingleCharacterSelect();
                            DeactivateSingleShipSelect();
                            DeactivateSinglePrimarySelect();
                            DeactivateSingleSecondarySelect();
                            DeactivateSingleSpecialSelect();
                            DeactivateSingleToggle();
                            DeactivateStat();

                            ActivateSingleSelection();

                            ResetBool();
                            ResetGlow();

                            choosing = false;
                        }
                    }
                }
                else
                {
                    if (P1characterType > 0 && P1shipType > 0 && P1primaryType > 0 && P1secondaryType > 0 && P1specialType > 0 && P2characterType > 0 && P2shipType > 0 && P2primaryType > 0 && P2secondaryType > 0 && P2specialType > 0)
                    {
                        maxP2GLowTracker = 6;

                        doubleStartButton.SetActive(true);
                    }
                    else
                    {
                        doubleStartButton.SetActive(false);
                    }

                    if (P2glowTracker > maxP2GLowTracker)
                    {
                        P2glowTracker = maxP2GLowTracker;
                    }

                    if (P1glowTracker <= 1)
                    {
                        P1glowTracker = 1;

                        ResetP1Glow();
                        P1characterButtonGlow.fillAmount = 1;
                    }
                    if (P2glowTracker <= 1)
                    {
                        P2glowTracker = 1;

                        ResetP2Glow();
                        P2characterButtonGlow.fillAmount = 1;
                    }

                    if (P1glowTracker == 2)
                    {
                        ResetP1Glow();
                        P1shipButtonGlow.fillAmount = 1;
                    }
                    if (P2glowTracker == 2)
                    {
                        ResetP2Glow();
                        P2shipButtonGlow.fillAmount = 1;
                    }

                    if (P1glowTracker == 3)
                    {
                        ResetP1Glow();
                        P1primaryButtonGlow.fillAmount = 1;
                    }
                    if (P2glowTracker == 3)
                    {
                        ResetP2Glow();
                        P2primaryButtonGlow.fillAmount = 1;
                    }

                    if (P1glowTracker == 4)
                    {
                        ResetP1Glow();
                        P1secondaryButtonGlow.fillAmount = 1;
                    }
                    if (P2glowTracker == 4)
                    {
                        ResetP2Glow();
                        P2secondaryButtonGlow.fillAmount = 1;
                    }

                    if (P1glowTracker == 5)
                    {
                        ResetP1Glow();
                        P1specialButtonGlow.fillAmount = 1;
                    }
                    if (P2glowTracker == 5)
                    {
                        ResetP2Glow();
                        P2specialButtonGlow.fillAmount = 1;
                    }

                    if (P1glowTracker >= 6)
                    {
                        P1glowTracker = 6;

                        ResetP1Glow();
                        doubleReturnButtonGlow.fillAmount = 1;
                    }
                    if (P2glowTracker >= 6)
                    {
                        P2glowTracker = 6;

                        ResetP2Glow();
                        doubleStartButtonGlow.fillAmount = 1;
                    }

                    if (P1toggleData <= 1)
                    {
                        ResetP1ToggleGlow();
                        P1toggleLeftGlow.fillAmount = 1;

                        P1toggleData = 1;

                        if (P1character == true)
                        {
                            DeactivateP1CharacterSelect();
                            P1character1.SetActive(true);

                            DeactivateP1Stat();
                            P1characterStat.enabled = true;
                            P1characterStat.text = "Name: Character A\nDescription:";
                        }
                        if (P1ship == true)
                        {
                            DeactivateP1ShipSelect();
                            P1ship1.SetActive(true);

                            DeactivateP1Stat();
                            P1shipStat.enabled = true;
                            P1shipStat.text = "Name: Light Ship\nDescription: \nHealth: 100\nShield: 75\nLives: 2/5";
                        }
                        if (P1primary == true)
                        {
                            DeactivateP1PrimarySelect();
                            P1primary1.SetActive(true);

                            DeactivateP1Stat();
                            P1primaryStat.enabled = true;
                            P1primaryStat.text = "Name: Machine Gun\nDescription: Basic rapid fire weapon. Spread increases with upgrades\nFire Rate: *****\nDamage: *\nArea of Effect: *";
                        }
                        if (P1secondary == true)
                        {
                            DeactivateP1SecondarySelect();
                            P1secondary1.SetActive(true);

                            DeactivateP1Stat();
                            P1secondaryStat.enabled = true;
                            P1secondaryStat.text = "Name: Homing Missiles\nDescription: Fires missiles that seek out targets. Fire rate and number of missiles increase with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ****";
                        }
                        if (P1special == true)
                        {
                            DeactivateP1SpecialSelect();
                            P1special1.SetActive(true);

                            DeactivateP1Stat();
                            P1specialStat.enabled = true;
                            P1specialStat.text = "Name: Mega Bomb\nDescription: Deploy a heavy bomb that expands to cover a large area for quick devastation.\nDamage: ****\nArea of Effect: *****\nDuration: **";
                        }
                    }
                    if (P2toggleData <= 1)
                    {
                        ResetP2ToggleGlow();
                        P2toggleLeftGlow.fillAmount = 1;

                        P2toggleData = 1;

                        if (P2character == true)
                        {
                            DeactivateP2CharacterSelect();
                            P2character1.SetActive(true);

                            DeactivateP2Stat();
                            P2characterStat.enabled = true;
                            P2characterStat.text = "Name: Character A\nDescription:";
                        }
                        if (P2ship == true)
                        {
                            DeactivateP2ShipSelect();
                            P2ship1.SetActive(true);

                            DeactivateP2Stat();
                            P2shipStat.enabled = true;
                            P2shipStat.text = "Name: Light Ship\nDescription: \nHealth: 100\nShield: 75\nLives: 2/5";
                        }
                        if (P2primary == true)
                        {
                            DeactivateP2PrimarySelect();
                            P2primary1.SetActive(true);

                            DeactivateP2Stat();
                            P2primaryStat.enabled = true;
                            P2primaryStat.text = "Name: Machine Gun\nDescription: Basic rapid fire weapon. Spread increases with upgrades\nFire Rate: *****\nDamage: *\nArea of Effect: *";
                        }
                        if (P2secondary == true)
                        {
                            DeactivateP2SecondarySelect();
                            P2secondary1.SetActive(true);

                            DeactivateP2Stat();
                            P2secondaryStat.enabled = true;
                            P2secondaryStat.text = "Name: Homing Missiles\nDescription: Fires missiles that seek out targets. Fire rate and number of missiles increase with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ****";
                        }
                        if (P2special == true)
                        {
                            DeactivateP2SpecialSelect();
                            P2special1.SetActive(true);

                            DeactivateP2Stat();
                            P2specialStat.enabled = true;
                            P2specialStat.text = "Name: Mega Bomb\nDescription: Deploy a heavy bomb that expands to cover a large area for quick devastation.\nDamage: ****\nArea of Effect: *****\nDuration: **";
                        }
                    }

                    if (P1toggleData == 2)
                    {
                        if (P1character == true)
                        {
                            DeactivateP1CharacterSelect();
                            P1character2.SetActive(true);

                            DeactivateP1Stat();
                            P1characterStat.enabled = true;
                            P1characterStat.text = "Name: Nomad\nDescription: An overconfident, hotshot pilot that hunts the machine menace wherever it goes.";
                        }
                        if (P1ship == true)
                        {
                            DeactivateP1ShipSelect();
                            P1ship2.SetActive(true);

                            DeactivateP1Stat();
                            P1shipStat.enabled = true;
                            P1shipStat.text = "Name: Medium Ship\nDescription: \nHealth: 125\nShield: 100\nLives: 2/5";
                        }
                        if (P1primary == true)
                        {
                            DeactivateP1PrimarySelect();
                            P1primary2.SetActive(true);

                            DeactivateP1Stat();
                            P1primaryStat.enabled = true;
                            P1primaryStat.text = "Name: Flak Cannon\nDescription: Area denial weapon. Shots explode mid air and damage enemies passing through the blast. Covers a wider area with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: *****";
                        }
                        if (P1secondary == true)
                        {
                            DeactivateP1SecondarySelect();
                            P1secondary2.SetActive(true);

                            DeactivateP1Stat();
                            P1secondaryStat.enabled = true;
                            P1secondaryStat.text = "Name: Sweeper Pods\nDescription: Wing mounted machine gun pods. Sweep out to the sides with each upgrade to cover a large area.\nFire Rate: *****\nDamage: *\nArea of Effect: **";
                        }
                        if (P1special == true)
                        {
                            DeactivateP1SpecialSelect();
                            P1special2.SetActive(true);

                            DeactivateP1Stat();
                            P1specialStat.enabled = true;
                            P1specialStat.text = "Name: Beam Cannon\nDescription: Someone thought it was a good idea to mount a capital class cannon onto a fighter. Huge beam that shoots through multiple targets.\nDamage: *****\nArea of Effect: *****\nDuration: *****";
                        }
                    }
                    if (P2toggleData == 2)
                    {
                        if (P2character == true)
                        {
                            DeactivateP2CharacterSelect();
                            P2character2.SetActive(true);

                            DeactivateP2Stat();
                            P2characterStat.enabled = true;
                            P2characterStat.text = "Name: Nomad\nDescription: An overconfident, hotshot pilot that hunts the machine menace wherever it goes.";
                        }
                        if (P2ship == true)
                        {
                            DeactivateP2ShipSelect();
                            P2ship2.SetActive(true);

                            DeactivateP2Stat();
                            P2shipStat.enabled = true;
                            P2shipStat.text = "Name: Medium Ship\nDescription: \nHealth: 125\nShield: 100\nLives: 2/5";
                        }
                        if (P2primary == true)
                        {
                            DeactivateP2PrimarySelect();
                            P2primary2.SetActive(true);

                            DeactivateP2Stat();
                            P2primaryStat.enabled = true;
                            P2primaryStat.text = "Name: Flak Cannon\nDescription: Area denial weapon. Shots explode mid air and damage enemies passing through the blast. Covers a wider area with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: *****";
                        }
                        if (P2secondary == true)
                        {
                            DeactivateP2SecondarySelect();
                            P2secondary2.SetActive(true);

                            DeactivateP2Stat();
                            P2secondaryStat.enabled = true;
                            P2secondaryStat.text = "Name: Sweeper Pods\nDescription: Wing mounted machine gun pods. Sweep out to the sides with each upgrade to cover a large area.\nFire Rate: *****\nDamage: *\nArea of Effect: **";
                        }
                        if (P2special == true)
                        {
                            DeactivateP2SpecialSelect();
                            P2special2.SetActive(true);

                            DeactivateP2Stat();
                            P2specialStat.enabled = true;
                            P2specialStat.text = "Name: Beam Cannon\nDescription: Someone thought it was a good idea to mount a capital class cannon onto a fighter. Huge beam that shoots through multiple targets.\nDamage: *****\nArea of Effect: *****\nDuration: *****";
                        }
                    }

                    if (P1toggleData == 3)
                    {
                        if (P1character == true)
                        {
                            DeactivateP1CharacterSelect();
                            P1character3.SetActive(true);

                            DeactivateP1Stat();
                            P1characterStat.enabled = true;
                            P1characterStat.text = "Name: Character C\nDescription: ";
                        }
                        if (P1ship == true)
                        {
                            DeactivateP1ShipSelect();
                            P1ship3.SetActive(true);

                            DeactivateP1Stat();
                            P1shipStat.enabled = true;
                            P1shipStat.text = "Name: Heavy Ship\nDescription: \nHealth: 150\nShield: 125\nLives: 2/5";
                        }
                        if (P1primary == true)
                        {
                            DeactivateP1PrimarySelect();
                            P1primary3.SetActive(true);

                            DeactivateP1Stat();
                            P1primaryStat.enabled = true;
                            P1primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (P1secondary == true)
                        {
                            DeactivateP1SecondarySelect();
                            P1secondary3.SetActive(true);

                            DeactivateP1Stat();
                            P1secondaryStat.enabled = true;
                            P1secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (P1special == true)
                        {
                            DeactivateP1SpecialSelect();
                            P1special3.SetActive(true);

                            DeactivateP1Stat();
                            P1specialStat.enabled = true;
                            P1specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }
                    if (P2toggleData == 3)
                    {
                        if (P2character == true)
                        {
                            DeactivateP2CharacterSelect();
                            P2character3.SetActive(true);

                            DeactivateP2Stat();
                            P2characterStat.enabled = true;
                            P2characterStat.text = "Name: Character C\nDescription:";
                        }
                        if (P2ship == true)
                        {
                            DeactivateP2ShipSelect();
                            P2ship3.SetActive(true);

                            DeactivateP2Stat();
                            P2shipStat.enabled = true;
                            P2shipStat.text = "Name: Heavy Ship\nDescription: \nHealth: 150\nShield: 125\nLives: 2/5";
                        }
                        if (P2primary == true)
                        {
                            DeactivateP2PrimarySelect();
                            P2primary3.SetActive(true);

                            DeactivateP2Stat();
                            P2primaryStat.enabled = true;
                            P2primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (P2secondary == true)
                        {
                            DeactivateP2SecondarySelect();
                            P2secondary3.SetActive(true);

                            DeactivateP2Stat();
                            P2secondaryStat.enabled = true;
                            P2secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (P2special == true)
                        {
                            DeactivateP2SpecialSelect();
                            P2special3.SetActive(true);

                            DeactivateP2Stat();
                            P2specialStat.enabled = true;
                            P2specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }

                    if (P1toggleData == 4)
                    {
                        if (P1character == true)
                        {
                            DeactivateP1CharacterSelect();
                            P1character4.SetActive(true);

                            DeactivateP1Stat();
                            P1characterStat.enabled = true;
                            P1characterStat.text = "Name: Jaeger\nDescription: A cocky, hot headed pilot on the hunt for more fame and glory.";
                        }
                        if (P1ship == true)
                        {
                            DeactivateP1ShipSelect();
                            P1ship4.SetActive(true);

                            DeactivateP1Stat();
                            P1shipStat.enabled = true;
                            P1shipStat.text = "Name: Lambo Shooter\nDescription: \nHealth: 175\nShield: 150\nLives: 2/5";
                        }
                        if (P1primary == true)
                        {
                            P1toggleData = 3;

                            DeactivateP1PrimarySelect();
                            P1primary3.SetActive(true);

                            DeactivateP1Stat();
                            P1primaryStat.enabled = true;
                            P1primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (P1secondary == true)
                        {
                            P1toggleData = 3;

                            DeactivateP1SecondarySelect();
                            P1secondary3.SetActive(true);

                            DeactivateP1Stat();
                            P1secondaryStat.enabled = true;
                            P1secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (P1special == true)
                        {
                            P1toggleData = 3;

                            DeactivateP1SpecialSelect();
                            P1special3.SetActive(true);

                            DeactivateP1Stat();
                            P1specialStat.enabled = true;
                            P1specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }
                    if (P2toggleData == 4)
                    {
                        if (P2character == true)
                        {
                            DeactivateP2CharacterSelect();
                            P2character4.SetActive(true);

                            DeactivateP2Stat();
                            P2characterStat.enabled = true;
                            P2characterStat.text = "Name: Jaeger\nDescription: A cocky, hot headed pilot on the hunt for more fame and glory.";
                        }
                        if (P2ship == true)
                        {
                            DeactivateP2ShipSelect();
                            P2ship4.SetActive(true);

                            DeactivateP2Stat();
                            P2shipStat.enabled = true;
                            P2shipStat.text = "Name: Lambo Shooter\nDescription: \nHealth: 175\nShield: 150\nLives: 2/5";
                        }
                        if (P2primary == true)
                        {
                            P2toggleData = 3;

                            DeactivateP2PrimarySelect();
                            P2primary3.SetActive(true);

                            DeactivateP2Stat();
                            P2primaryStat.enabled = true;
                            P2primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (P2secondary == true)
                        {
                            P2toggleData = 3;

                            DeactivateP2SecondarySelect();
                            P2secondary3.SetActive(true);

                            DeactivateP2Stat();
                            P2secondaryStat.enabled = true;
                            P2secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (P2special == true)
                        {
                            P2toggleData = 3;

                            DeactivateP2SpecialSelect();
                            P2special3.SetActive(true);

                            DeactivateP2Stat();
                            P2specialStat.enabled = true;
                            P2specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }

                    if (P1toggleData >= 5)
                    {
                        if (P1character == true)
                        {
                            P1toggleData = 4;

                            DeactivateP1CharacterSelect();
                            P1character4.SetActive(true);

                            DeactivateP1Stat();
                            P1characterStat.enabled = true;
                            P1characterStat.text = "Name: Jaeger\nDescription: A cocky, hot headed pilot on the hunt for more fame and glory.";
                        }
                        if (P1ship == true)
                        {
                            P1toggleData = 5;

                            DeactivateP1ShipSelect();
                            P1ship5.SetActive(true);

                            DeactivateP1Stat();
                            P1shipStat.enabled = true;
                            P1shipStat.text = "Name: Truck Shooter\nDescription: \nHealth: 200\nShield: 200\nLives: 2/5";
                        }
                        if (P1primary == true)
                        {
                            P1toggleData = 3;

                            DeactivateP1PrimarySelect();
                            P1primary3.SetActive(true);

                            DeactivateP1Stat();
                            P1primaryStat.enabled = true;
                            P1primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (P1secondary == true)
                        {
                            P1toggleData = 3;

                            DeactivateP1SecondarySelect();
                            P1secondary3.SetActive(true);

                            DeactivateP1Stat();
                            P1secondaryStat.enabled = true;
                            P1secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (P1special == true)
                        {
                            P1toggleData = 3;

                            DeactivateP1SpecialSelect();
                            P1special3.SetActive(true);

                            DeactivateP1Stat();
                            P1specialStat.enabled = true;
                            P1specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }
                    if (P2toggleData >= 5)
                    {
                        if (P2character == true)
                        {
                            P2toggleData = 4;

                            DeactivateP2CharacterSelect();
                            P2character4.SetActive(true);

                            DeactivateP2Stat();
                            P2characterStat.enabled = true;
                            P2characterStat.text = "Name: Jaeger\nDescription: A cocky, hot headed pilot on the hunt for more fame and glory.";
                        }
                        if (P2ship == true)
                        {
                            P2toggleData = 5;

                            DeactivateP2ShipSelect();
                            P2ship5.SetActive(true);

                            DeactivateP2Stat();
                            P2shipStat.enabled = true;
                            P2shipStat.text = "Name: Truck Shooter\nDescription: \nHealth: 200\nShield: 200\nLives: 2/5";
                        }
                        if (P2primary == true)
                        {
                            P2toggleData = 3;

                            DeactivateP2PrimarySelect();
                            P2primary3.SetActive(true);

                            DeactivateP2Stat();
                            P2primaryStat.enabled = true;
                            P2primaryStat.text = "Name: PAC\nDescription: High powered, slow firing weapon that penetrates multiple targets. Damage and size of shots increases with upgrades.\nFire Rate: *\nDamage: *****\nArea of Effect: ***";
                        }
                        if (P2secondary == true)
                        {
                            P2toggleData = 3;

                            DeactivateP2SecondarySelect();
                            P2secondary3.SetActive(true);

                            DeactivateP2Stat();
                            P2secondaryStat.enabled = true;
                            P2secondaryStat.text = "Name: Plasma Gun\nDescription: Fires highly volatile balls of plasma that explode mid air into smaller balls of plasma. Fire rate and spread increase with upgrades.\nFire Rate: ***\nDamage: ***\nArea of Effect: ****";
                        }
                        if (P2special == true)
                        {
                            P2toggleData = 3;

                            DeactivateP2SpecialSelect();
                            P2special3.SetActive(true);

                            DeactivateP2Stat();
                            P2specialStat.enabled = true;
                            P2specialStat.text = "Name: Super Shield\nDescription: Fires up a defensive barrier that destroys enemy projectiles, missiles, and even damages ships.\nDamage: **\nArea of Effect: **\nDuration: *****";
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.W) && !P1choosing)
                    {
                        P1glowTracker--;
                    }
                    if ((Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)) && !P2choosing)
                    {
                        P2glowTracker--;
                    }

                    if (Input.GetKeyDown(KeyCode.S) && !P1choosing)
                    {
                        P1glowTracker++;
                    }
                    if ((Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) && !P2choosing)
                    {
                        P2glowTracker++;
                    }

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        ResetP1ToggleGlow();
                        P1toggleLeftGlow.fillAmount = 1;

                        P1toggleData--;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
                    {
                        ResetP2ToggleGlow();
                        P2toggleLeftGlow.fillAmount = 1;

                        P2toggleData--;
                    }

                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        ResetP1ToggleGlow();
                        P1toggleRightGlow.fillAmount = 1;

                        P1toggleData++;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
                    {
                        ResetP2ToggleGlow();
                        P2toggleRightGlow.fillAmount = 1;

                        P2toggleData++;
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (!P1choosing)
                        {
                            if (P1glowTracker == 1)
                            {
                                Player1CharacterButton();
                            }
                            if (P1glowTracker == 2)
                            {
                                Player1ShipButton();
                            }
                            if (P1glowTracker == 3)
                            {
                                Player1PrimaryButton();
                            }
                            if (P1glowTracker == 4)
                            {
                                Player1SecondaryButton();
                            }
                            if (P1glowTracker == 5)
                            {
                                Player1SpecialButton();
                            }
                            if (P1glowTracker == 6)
                            {
                                ReturnButton();
                            }
                        }
                        else
                        {
                            if (P1toggleData == 1)
                            {
                                if (P1character == true)
                                {
                                    P1characterType = 1;
                                }
                                if (P1ship == true)
                                {
                                    P1shipType = 1;

                                    P1LightShipData();
                                    Player1Data();
                                }
                                if (P1primary == true)
                                {
                                    P1primaryType = 1;
                                }
                                if (P1secondary == true)
                                {
                                    P1secondaryType = 1;
                                }
                                if (P1special == true)
                                {
                                    P1specialType = 1;
                                }
                            }
                            if (P1toggleData == 2)
                            {
                                if (P1character == true)
                                {
                                    P1characterType = 2;
                                }
                                if (P1ship == true)
                                {
                                    P1shipType = 2;

                                    P1MediumShipData();
                                    Player1Data();
                                }
                                if (P1primary == true)
                                {
                                    P1primaryType = 2;
                                }
                                if (P1secondary == true)
                                {
                                    P1secondaryType = 2;
                                }
                                if (P1special == true)
                                {
                                    P1specialType = 2;
                                }
                            }
                            if (P1toggleData == 3)
                            {
                                if (P1character == true)
                                {
                                    P1characterType = 3;
                                }
                                if (P1ship == true)
                                {
                                    P1shipType = 3;

                                    P1HeavyShipData();
                                    Player1Data();
                                }
                                if (P1primary == true)
                                {
                                    P1primaryType = 3;
                                }
                                if (P1secondary == true)
                                {
                                    P1secondaryType = 3;
                                }
                                if (P1special == true)
                                {
                                    P1specialType = 3;
                                }
                            }
                            if (P1toggleData == 4)
                            {
                                if (P1character == true)
                                {
                                    P1characterType = 4;
                                }
                                if (P1ship == true)
                                {
                                    P1shipType = 4;

                                    P1LamboShooterData();
                                    Player1Data();
                                }
                                if (P1primary == true)
                                {
                                    P1primaryType = 3;
                                }
                                if (P1secondary == true)
                                {
                                    P1secondaryType = 3;
                                }
                                if (P1special == true)
                                {
                                    P1specialType = 3;
                                }
                            }
                            if (P1toggleData == 5)
                            {
                                if (P1character == true)
                                {
                                    P1characterType = 4;
                                }
                                if (P1ship == true)
                                {
                                    P1shipType = 5;

                                    P1TruckShooterData();
                                    Player1Data();
                                }
                                if (P1primary == true)
                                {
                                    P1primaryType = 3;
                                }
                                if (P1secondary == true)
                                {
                                    P1secondaryType = 3;
                                }
                                if (P1special == true)
                                {
                                    P1specialType = 3;
                                }
                            }

                            DeactivateP1CharacterSelect();
                            DeactivateP1ShipSelect();
                            DeactivateP1PrimarySelect();
                            DeactivateP1SecondarySelect();
                            DeactivateP1SpecialSelect();
                            DeactivateP1Toggle();
                            DeactivateP1Stat();

                            ActivatePlayer1Selection();

                            ResetBool();
                            ResetP1Glow();

                            P1choosing = false;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
                    {
                        if (!P2choosing)
                        {
                            if (P2glowTracker == 1)
                            {
                                Player2CharacterButton();
                            }
                            if (P2glowTracker == 2)
                            {
                                Player2ShipButton();
                            }
                            if (P2glowTracker == 3)
                            {
                                Player2PrimaryButton();
                            }
                            if (P2glowTracker == 4)
                            {
                                Player2SecondaryButton();
                            }
                            if (P2glowTracker == 5)
                            {
                                Player2SpecialButton();
                            }
                            if (P2glowTracker == 6)
                            {
                                StartCoroutine(ActivateDoubleStartButton());
                            }
                        }
                        else
                        {
                            if (P2toggleData == 1)
                            {
                                if (P2character == true)
                                {
                                    P2characterType = 1;
                                }
                                if (P2ship == true)
                                {
                                    P2shipType = 1;

                                    P2LightShipData();
                                    Player2Data();
                                }
                                if (P2primary == true)
                                {
                                    P2primaryType = 1;
                                }
                                if (P2secondary == true)
                                {
                                    P2secondaryType = 1;
                                }
                                if (P2special == true)
                                {
                                    P2specialType = 1;
                                }
                            }
                            if (P2toggleData == 2)
                            {
                                if (P2character == true)
                                {
                                    P2characterType = 2;
                                }
                                if (P2ship == true)
                                {
                                    P2shipType = 2;

                                    P2MediumShipData();
                                    Player2Data();
                                }
                                if (P2primary == true)
                                {
                                    P2primaryType = 2;
                                }
                                if (P2secondary == true)
                                {
                                    P2secondaryType = 2;
                                }
                                if (P2special == true)
                                {
                                    P2specialType = 2;
                                }
                            }
                            if (P2toggleData == 3)
                            {
                                if (P2character == true)
                                {
                                    P2characterType = 3;
                                }
                                if (P2ship == true)
                                {
                                    P2shipType = 3;

                                    P2HeavyShipData();
                                    Player2Data();
                                }
                                if (P2primary == true)
                                {
                                    P2primaryType = 3;
                                }
                                if (P2secondary == true)
                                {
                                    P2secondaryType = 3;
                                }
                                if (P2special == true)
                                {
                                    P2specialType = 3;
                                }
                            }
                            if (P2toggleData == 4)
                            {
                                if (P2character == true)
                                {
                                    P2characterType = 4;
                                }
                                if (P2ship == true)
                                {
                                    P2shipType = 4;

                                    P2LamboShooterData();
                                    Player2Data();
                                }
                                if (P2primary == true)
                                {
                                    P2primaryType = 3;
                                }
                                if (P2secondary == true)
                                {
                                    P2secondaryType = 3;
                                }
                                if (P2special == true)
                                {
                                    P2specialType = 3;
                                }
                            }
                            if (P2toggleData == 5)
                            {
                                if (P2character == true)
                                {
                                    P2characterType = 4;
                                }
                                if (P2ship == true)
                                {
                                    P2shipType = 5;

                                    P2TruckShooterData();
                                    Player2Data();
                                }
                                if (P2primary == true)
                                {
                                    P2primaryType = 3;
                                }
                                if (P2secondary == true)
                                {
                                    P2secondaryType = 3;
                                }
                                if (P2special == true)
                                {
                                    P2specialType = 3;
                                }
                            }

                            DeactivateP2CharacterSelect();
                            DeactivateP2ShipSelect();
                            DeactivateP2PrimarySelect();
                            DeactivateP2SecondarySelect();
                            DeactivateP2SpecialSelect();
                            DeactivateP2Toggle();
                            DeactivateP2Stat();

                            ActivatePlayer2Selection();

                            ResetBool();
                            ResetP2Glow();

                            P2choosing = false;
                        }
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
                {
                    breakInstruction = true;

                    SkipButton();
                }
            }
        }
    }
    IEnumerator Timer()
    {
        PlayerWeaponController.baseWLevel = 1;
        PlayerWeaponController.baseSecondaryLevel = 0;
        PlayerWeaponController.superAmmoDefault = 3;

        if (MainMenuController.onePlayer)
        {
            ActivateSingleSelection();
            ActivateSingleInitialAnimation();
        }
        else
        {
            ActivatePlayer1Selection();
            ActivatePlayer2Selection();
            ActivateDoubleInitialAnimation();
        }

        guidelineBackground.SetActive(false);
        guideLine.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        waiting = true;
    }
    IEnumerator ActivateSingleStartButton()
    {
        gamePlay = true;

        Player1WeaponData();

        DeactivateSingleCharacterSelect();
        DeactivateSingleShipSelect();
        DeactivateSinglePrimarySelect();
        DeactivateSingleSecondarySelect();
        DeactivateSingleSpecialSelect();
        DeactivateSingleToggle();

        DeactivateSingleSelection();
        ResetBool();

        guidelineBackground.SetActive(true);
        guideLine.SetActive(true);

        if(breakInstruction)
        {
            yield break;
        }

        yield return new WaitForSeconds(9f);

        SceneManager.LoadScene("Level1");
    }
    IEnumerator ActivateDoubleStartButton()
    {
        gamePlay = true;

        Player1WeaponData();
        Player2WeaponData();

        DeactivateP1CharacterSelect();
        DeactivateP1ShipSelect();
        DeactivateP1PrimarySelect();
        DeactivateP1SecondarySelect();
        DeactivateP1SpecialSelect();
        DeactivateP1Toggle();

        DeactivateP2CharacterSelect();
        DeactivateP2ShipSelect();
        DeactivateP2PrimarySelect();
        DeactivateP2SecondarySelect();
        DeactivateP2SpecialSelect();
        DeactivateP2Toggle();

        DeactivatePlayer1Selection();
        DeactivatePlayer2Selection();

        ResetBool();

        guidelineBackground.SetActive(true);
        guideLine.SetActive(true);

        if (breakInstruction)
        {
            yield break;
        }

        yield return new WaitForSeconds(9f);

        SceneManager.LoadScene("Level1");
    }

    //turning object on or off
    private void ActivateSingleInitialAnimation()
    {
        singleCharacter.SetBool("InitialAnimation", true);
        singleShip.SetBool("InitialAnimation", true);
        singlePrimary.SetBool("InitialAnimation", true);
        singleSecondary.SetBool("InitialAnimation", true);
        singleSpecial.SetBool("InitialAnimation", true);
        singleReturn.SetBool("InitialAnimation", true);
    }
    private void ActivateDoubleInitialAnimation()
    {
        doubleCharacter1.SetBool("InitialAnimation", true);
        doubleShip1.SetBool("InitialAnimation", true);
        doublePrimary1.SetBool("InitialAnimation", true);
        doubleSecondary1.SetBool("InitialAnimation", true);
        doubleSpecial1.SetBool("InitialAnimation", true);

        doubleCharacter2.SetBool("InitialAnimation", true);
        doubleShip2.SetBool("InitialAnimation", true);
        doublePrimary2.SetBool("InitialAnimation", true);
        doubleSecondary2.SetBool("InitialAnimation", true);
        doubleSpecial2.SetBool("InitialAnimation", true);
    }

    private void ActivateSingleSelection()
    {
        singleMenu.SetActive(true);
        singleMenuBackground.SetActive(true);
        singleReturnButton.SetActive(true);
        characterButton.SetActive(true);
        shipButton.SetActive(true);
        primaryButton.SetActive(true);
        secondaryButton.SetActive(true);
        specialButton.SetActive(true);
    }
    private void DeactivateSingleSelection()
    {
        singleMenu.SetActive(false);
        singleMenuBackground.SetActive(false);
        singleReturnButton.SetActive(false);
        characterButton.SetActive(false);
        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);
        singleStartButton.SetActive(false);
    }

    private void ActivatePlayer1Selection()
    {
        P1Menu.SetActive(true);
        doubleMenuBackground.SetActive(true);
        doubleReturnButton.SetActive(true);
        P1characterButton.SetActive(true);
        P1shipButton.SetActive(true);
        P1primaryButton.SetActive(true);
        P1secondaryButton.SetActive(true);
        P1specialButton.SetActive(true);
    }
    private void DeactivatePlayer1Selection()
    {
        P1Menu.SetActive(false);
        doubleMenuBackground.SetActive(false);
        doubleReturnButton.SetActive(false);
        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
    }

    private void ActivatePlayer2Selection()
    {
        P2Menu.SetActive(true);
        doubleMenuBackground.SetActive(true);
        P2characterButton.SetActive(true);
        P2shipButton.SetActive(true);
        P2primaryButton.SetActive(true);
        P2secondaryButton.SetActive(true);
        P2specialButton.SetActive(true);
    }
    private void DeactivatePlayer2Selection()
    {
        P2Menu.SetActive(false);
        doubleMenuBackground.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);
        doubleStartButton.SetActive(false);
    }

    private void ActivateSingleToggle()
    {
        toggleLeft.SetActive(true);
        toggleRight.SetActive(true);
    }
    private void DeactivateSingleToggle()
    {
        toggleLeft.SetActive(false);
        toggleRight.SetActive(false);
    }

    private void ActivateP1Toggle()
    {
        P1toggleLeft.SetActive(true);
        P1toggleRight.SetActive(true);
    }
    private void DeactivateP1Toggle()
    {
        P1toggleLeft.SetActive(false);
        P1toggleRight.SetActive(false);
    }

    private void ActivateP2Toggle()
    {
        P2toggleLeft.SetActive(true);
        P2toggleRight.SetActive(true);
    }
    private void DeactivateP2Toggle()
    {
        P2toggleLeft.SetActive(false);
        P2toggleRight.SetActive(false);
    }

    private void DeactivateSingleCharacterSelect()
    {
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
        character4.SetActive(false);
    }
    private void DeactivateP1CharacterSelect()
    {
        P1character1.SetActive(false);
        P1character2.SetActive(false);
        P1character3.SetActive(false);
        P1character4.SetActive(false);
    }
    private void DeactivateP2CharacterSelect()
    {
        P2character1.SetActive(false);
        P2character2.SetActive(false);
        P2character3.SetActive(false);
        P2character4.SetActive(false);
    }

    private void DeactivateSingleShipSelect()
    {
        ship1.SetActive(false);
        ship2.SetActive(false);
        ship3.SetActive(false);
        ship4.SetActive(false);
        ship5.SetActive(false);
    }
    private void DeactivateP1ShipSelect()
    {
        P1ship1.SetActive(false);
        P1ship2.SetActive(false);
        P1ship3.SetActive(false);
        P1ship4.SetActive(false);
        P1ship5.SetActive(false);
    }
    private void DeactivateP2ShipSelect()
    {
        P2ship1.SetActive(false);
        P2ship2.SetActive(false);
        P2ship3.SetActive(false);
        P2ship4.SetActive(false);
        P2ship5.SetActive(false);
    }

    private void DeactivateSinglePrimarySelect()
    {
        primary1.SetActive(false);
        primary2.SetActive(false);
        primary3.SetActive(false);
    }
    private void DeactivateP1PrimarySelect()
    {
        P1primary1.SetActive(false);
        P1primary2.SetActive(false);
        P1primary3.SetActive(false);
    }
    private void DeactivateP2PrimarySelect()
    {
        P2primary1.SetActive(false);
        P2primary2.SetActive(false);
        P2primary3.SetActive(false);
    }

    private void DeactivateSingleSecondarySelect()
    {
        secondary1.SetActive(false);
        secondary2.SetActive(false);
        secondary3.SetActive(false);
    }
    private void DeactivateP1SecondarySelect()
    {
        P1secondary1.SetActive(false);
        P1secondary2.SetActive(false);
        P1secondary3.SetActive(false);
    }
    private void DeactivateP2SecondarySelect()
    {
        P2secondary1.SetActive(false);
        P2secondary2.SetActive(false);
        P2secondary3.SetActive(false);
    }

    private void DeactivateSingleSpecialSelect()
    {
        special1.SetActive(false);
        special2.SetActive(false);
        special3.SetActive(false);
    }
    private void DeactivateP1SpecialSelect()
    {
        P1special1.SetActive(false);
        P1special2.SetActive(false);
        P1special3.SetActive(false);
    }
    private void DeactivateP2SpecialSelect()
    {
        P2special1.SetActive(false);
        P2special2.SetActive(false);
        P2special3.SetActive(false);
    }

    private void DeactivateShader()
    {
        characterButtonShader.SetActive(false);
        shipButtonShader.SetActive(false);
        primaryButtonShader.SetActive(false);
        secondaryButtonShader.SetActive(false);
        specialButtonShader.SetActive(false);

        P1characterButtonShader.SetActive(false);
        P1shipButtonShader.SetActive(false);
        P1primaryButtonShader.SetActive(false);
        P1secondaryButtonShader.SetActive(false);
        P1specialButtonShader.SetActive(false);

        P2characterButtonShader.SetActive(false);
        P2shipButtonShader.SetActive(false);
        P2primaryButtonShader.SetActive(false);
        P2secondaryButtonShader.SetActive(false);
        P2specialButtonShader.SetActive(false);
    }

    private void DeactivateStat()
    {
        characterStat.enabled = false;
        shipStat.enabled = false;
        primaryStat.enabled = false;
        secondaryStat.enabled = false;
        specialStat.enabled = false;
    }
    private void DeactivateP1Stat()
    {
        P1characterStat.enabled = false;
        P1shipStat.enabled = false;
        P1primaryStat.enabled = false;
        P1secondaryStat.enabled = false;
        P1specialStat.enabled = false;
    }
    private void DeactivateP2Stat()
    {
        P2characterStat.enabled = false;
        P2shipStat.enabled = false;
        P2primaryStat.enabled = false;
        P2secondaryStat.enabled = false;
        P2specialStat.enabled = false;
    }

    //set data
    private void SetP1ToggleData()
    {
        P1toggleData = 1;
    }
    private void ResetP1ToggleData()
    {
        P1toggleData = 0;
    }

    private void SetP2ToggleData()
    {
        P2toggleData = 1;
    }
    private void ResetP2ToggleData()
    {
        P2toggleData = 0;
    }

    private void ResetInt()
    {
        P1characterType = 0;
        P1shipType = 0;
        P1primaryType = 0;
        P1secondaryType = 0;
        P1specialType = 0;

        P2characterType = 0;
        P2shipType = 0;
        P2primaryType = 0;
        P2secondaryType = 0;
        P2specialType = 0;
    }

    private void ResetBool()
    {
        character = false;
        ship = false;
        primary = false;
        secondary = false;
        special = false;
        P1character = false;
        P1ship = false;
        P1primary = false;
        P1secondary = false;
        P1special = false;
        P2character = false;
        P2ship = false;
        P2primary = false;
        P2secondary = false;
        P2special = false;
    }

    private void ResetGlow()
    {
        singleReturnButtonGlow.fillAmount = 0;
        singleStartButtonGlow.fillAmount = 0;

        characterButtonGlow.fillAmount = 0;
        shipButtonGlow.fillAmount = 0;
        primaryButtonGlow.fillAmount = 0;
        secondaryButtonGlow.fillAmount = 0;
        specialButtonGlow.fillAmount = 0;
    }
    private void ResetP1Glow()
    {
        doubleReturnButtonGlow.fillAmount = 0;

        P1characterButtonGlow.fillAmount = 0;
        P1shipButtonGlow.fillAmount = 0;
        P1primaryButtonGlow.fillAmount = 0;
        P1secondaryButtonGlow.fillAmount = 0;
        P1specialButtonGlow.fillAmount = 0;
    }
    private void ResetP2Glow()
    {
        doubleStartButtonGlow.fillAmount = 0;

        P2characterButtonGlow.fillAmount = 0;
        P2shipButtonGlow.fillAmount = 0;
        P2primaryButtonGlow.fillAmount = 0;
        P2secondaryButtonGlow.fillAmount = 0;
        P2specialButtonGlow.fillAmount = 0;
    }

    private void ResetToggleGlow()
    {
        toggleLeftGlow.fillAmount = 0;
        toggleRightGlow.fillAmount = 0;
    }
    private void ResetP1ToggleGlow()
    {
        P1toggleLeftGlow.fillAmount = 0;
        P1toggleRightGlow.fillAmount = 0;
    }
    private void ResetP2ToggleGlow()
    {
        P2toggleLeftGlow.fillAmount = 0;
        P2toggleRightGlow.fillAmount = 0;
    }

    //passing data
    //player 1 light ship
    private void P1LightShipData()
    {
        PlayerHealthSystem.P1maxHealth = 100;
        PlayerHealthSystem.P1maxShields = 75;
        PlayerHealthSystem.P1maxLives = 2;
    }
    //player 2 light ship
    private void P2LightShipData()
    {
        PlayerHealthSystem.P2maxHealth = 100;
        PlayerHealthSystem.P2maxShields = 75;
        PlayerHealthSystem.P2maxLives = 2;
    }

    //player 1 medium ship
    private void P1MediumShipData()
    {
        PlayerHealthSystem.P1maxHealth = 125;
        PlayerHealthSystem.P1maxShields = 100;
        PlayerHealthSystem.P1maxLives = 2;
    }
    //player 2 medium ship
    private void P2MediumShipData()
    {
        PlayerHealthSystem.P2maxHealth = 125;
        PlayerHealthSystem.P2maxShields = 100;
        PlayerHealthSystem.P2maxLives = 2;
    }

    //plaer 1 heavy ship
    private void P1HeavyShipData()
    {
        PlayerHealthSystem.P1maxHealth = 150;
        PlayerHealthSystem.P1maxShields = 125;
        PlayerHealthSystem.P1maxLives = 2;
    }
    //plaer 2 heavy ship
    private void P2HeavyShipData()
    {
        PlayerHealthSystem.P2maxHealth = 150;
        PlayerHealthSystem.P2maxShields = 125;
        PlayerHealthSystem.P2maxLives = 2;
    }

    //player 1 lambo shooter
    private void P1LamboShooterData()
    {
        PlayerHealthSystem.P1maxHealth = 175;
        PlayerHealthSystem.P1maxShields = 150;
        PlayerHealthSystem.P1maxLives = 2;
    }
    //player 2 lambo shooter
    private void P2LamboShooterData()
    {
        PlayerHealthSystem.P2maxHealth = 75;
        PlayerHealthSystem.P2maxShields = 150;
        PlayerHealthSystem.P2maxLives = 2;
    }

    //player 1 truck shooter
    private void P1TruckShooterData()
    {
        PlayerHealthSystem.P1maxHealth = 200;
        PlayerHealthSystem.P1maxShields = 200;
        PlayerHealthSystem.P1maxLives = 2;
    }
    //player 2 truck shooter
    private void P2TruckShooterData()
    {
        PlayerHealthSystem.P2maxHealth = 200;
        PlayerHealthSystem.P2maxShields = 200;
        PlayerHealthSystem.P2maxLives = 2;
    }

    //player 1 ship data
    private void Player1Data()
    {
        PlayerHealthSystem.P1savedHealth = PlayerHealthSystem.P1maxHealth;
        PlayerHealthSystem.P1savedShields = PlayerHealthSystem.P1maxShields;
        PlayerHealthSystem.P1savedLives = PlayerHealthSystem.P1maxLives;
    }
    //player 2 ship data
    private void Player2Data()
    {
        PlayerHealthSystem.P2savedHealth = PlayerHealthSystem.P2maxHealth;
        PlayerHealthSystem.P2savedShields = PlayerHealthSystem.P2maxShields;
        PlayerHealthSystem.P2savedLives = PlayerHealthSystem.P2maxLives;
    }

    //player 1 Weapon data
    private void Player1WeaponData()
    {
        PlayerWeaponController.P1savedWeaponLevel = PlayerWeaponController.baseWLevel;
        PlayerWeaponController.P1savedSecondaryLevel = PlayerWeaponController.baseSecondaryLevel;
        PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.superAmmoDefault;
    }
    //player 2 ship data
    private void Player2WeaponData()
    {
        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.baseWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.baseSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.superAmmoDefault;
    }

    //on click button
    public void SingleStartButton()
    {
        StartCoroutine(ActivateSingleStartButton());
    }
    public void DoubleStartButton()
    {
        StartCoroutine(ActivateDoubleStartButton());
    }

    public void SkipButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ReturnButton()
    {
        ResetBool();
        ResetInt();
        ResetP1ToggleData();
        ResetP2ToggleData();

        SceneManager.LoadScene("MainMenu");
    }

    public void P1LeftToggleButton()
    {
        P1toggleData++;
    }
    public void P1RightToggleButton()
    {
        P1toggleData--;
    }

    public void P2LeftToggleButton()
    {
        P2toggleData++;
    }
    public void P2RightToggleButton()
    {
        P2toggleData--;
    }

    public void SinglePlayerCharacterButton()
    {
        choosing = true;
        
        ActivateSingleToggle();
        SetP1ToggleData();

        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);

        characterButton.SetActive(true);
        characterButtonShader.SetActive(true);
        character = true;
    }
    public void Player1CharacterButton()
    {
        P1choosing = true;
        
        ActivateP1Toggle();
        SetP1ToggleData();

        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);

        P1characterButton.SetActive(true);
        P1characterButtonShader.SetActive(true);
        P1character = true;
    }
    public void Player2CharacterButton()
    {
        P2choosing = true;
        
        ActivateP2Toggle();
        SetP2ToggleData();
        
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P2characterButton.SetActive(true);
        P2characterButtonShader.SetActive(true);
        P2character = true;
    }

    public void SinglePlayerShipButton()
    {
        choosing = true;
        
        ActivateSingleToggle();
        SetP1ToggleData();

        characterButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);

        shipButton.SetActive(true);
        shipButtonShader.SetActive(true);
        ship = true;
    }
    public void Player1ShipButton()
    {
        P1choosing = true;
        
        ActivateP1Toggle();
        SetP1ToggleData();

        P1characterButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);

        P1shipButton.SetActive(true);
        P1shipButtonShader.SetActive(true);
        P1ship = true;
    }
    public void Player2ShipButton()
    {
        P2choosing = true;
        
        ActivateP2Toggle();
        SetP2ToggleData();
        
        P2characterButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P2shipButton.SetActive(true);
        P2shipButtonShader.SetActive(true);
        P2ship = true;
    }

    public void SinglePlayerPrimaryButton()
    {
        choosing = true;
        
        ActivateSingleToggle();
        SetP1ToggleData();

        characterButton.SetActive(false);
        shipButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);

        primaryButton.SetActive(true);
        primaryButtonShader.SetActive(true);
        primary = true;
    }
    public void Player1PrimaryButton()
    {
        P1choosing = true;

        ActivateP1Toggle();
        SetP1ToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);

        P1primaryButton.SetActive(true);
        P1primaryButtonShader.SetActive(true);
        P1primary = true;
    }
    public void Player2PrimaryButton()
    {
        P2choosing = true;
        
        ActivateP2Toggle();
        SetP2ToggleData();
        
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P2primaryButton.SetActive(true);
        P2primaryButtonShader.SetActive(true);
        P2primary = true;
    }

    public void SinglePlayerSecondaryButton()
    {
        choosing = true;
        
        ActivateSingleToggle();
        SetP1ToggleData();

        characterButton.SetActive(false);
        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        specialButton.SetActive(false);

        secondaryButton.SetActive(true);
        secondaryButtonShader.SetActive(true);
        secondary = true;
    }
    public void Player1SecondaryButton()
    {
        P1choosing = true;
        
        ActivateP1Toggle();
        SetP1ToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1specialButton.SetActive(false);

        P1secondaryButton.SetActive(true);
        P1secondaryButtonShader.SetActive(true);
        P1secondary = true;
    }
    public void Player2SecondaryButton()
    {
        P2choosing = true;
        
        ActivateP2Toggle();
        SetP2ToggleData();

        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P2secondaryButton.SetActive(true);
        P2secondaryButtonShader.SetActive(true);
        P2secondary = true;
    }

    public void SinglePlayerSpecialButton()
    {
        choosing = true;
        
        ActivateSingleToggle();
        SetP1ToggleData();

        characterButton.SetActive(false);
        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(true);
        specialButtonShader.SetActive(true);
        special = true;
    }
    public void Player1SpecialButton()
    {
        P1choosing = true;
        
        ActivateP1Toggle();
        SetP1ToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);

        P1specialButton.SetActive(true);
        P1specialButtonShader.SetActive(true);
        P1special = true;
    }
    public void Player2SpecialButton()
    {
        P2choosing = true;
        
        ActivateP2Toggle();
        SetP2ToggleData();
        
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);

        P2specialButton.SetActive(true);
        P2specialButtonShader.SetActive(true);
        P2special = true;
    }
}
