using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionMenuController : MonoBehaviour
{
    public Text characterStat;
    public GameObject ship1Stat;
    public GameObject ship2Stat;
    public GameObject ship3Stat;
    public GameObject ship4Stat;
    public GameObject ship5Stat;
    public GameObject primary1Stat;
    public GameObject primary2Stat;
    public GameObject primary3Stat;
    public GameObject secondary1Stat;
    public GameObject secondary2Stat;
    public GameObject secondary3Stat;
    public GameObject special1Stat;
    public GameObject special2Stat;
    public GameObject special3Stat;

    public Text P1characterStat;
    public GameObject P1ship1Stat;
    public GameObject P1ship2Stat;
    public GameObject P1ship3Stat;
    public GameObject P1ship4Stat;
    public GameObject P1ship5Stat;
    public GameObject P1primary1Stat;
    public GameObject P1primary2Stat;
    public GameObject P1primary3Stat;
    public GameObject P1secondary1Stat;
    public GameObject P1secondary2Stat;
    public GameObject P1secondary3Stat;
    public GameObject P1special1Stat;
    public GameObject P1special2Stat;
    public GameObject P1special3Stat;

    public Text P2characterStat;
    public GameObject P2ship1Stat;
    public GameObject P2ship2Stat;
    public GameObject P2ship3Stat;
    public GameObject P2ship4Stat;
    public GameObject P2ship5Stat;
    public GameObject P2primary1Stat;
    public GameObject P2primary2Stat;
    public GameObject P2primary3Stat;
    public GameObject P2secondary1Stat;
    public GameObject P2secondary2Stat;
    public GameObject P2secondary3Stat;
    public GameObject P2special1Stat;
    public GameObject P2special2Stat;
    public GameObject P2special3Stat;

    private int glowTracker;
    private int P1glowTracker;
    private int P2glowTracker;
    private int maxSingleGlowTracker;
    private int maxP2GLowTracker;

    private bool choosing;
    private bool P1choosing;
    private bool P2choosing;

    private bool waiting;
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

    private AudioClip[] soundEffect;
    private AudioSource[] buttonSoundEffect;

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
        breakInstruction = false;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
	{
		if (TitleController.arcadeQuit)
		{
			if (Input.GetButtonDown ("ArcadeQuit"))
			{
				Application.Quit ();
			}
		}

        if (waiting)
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
                        characterStat.text = "Name: Sparky\nDescription: Truck driver turned toaster hunter after losing her truck";
                    }
                    if (ship == true)
                    {
                        DeactivateSingleShipSelect();
                        ship1.SetActive(true);

                        DeactivateStat();
                        ship1Stat.SetActive(true);
                    }
                    if (primary == true)
                    {
                        DeactivateSinglePrimarySelect();
                        primary1.SetActive(true);

                        DeactivateStat();
                        primary1Stat.SetActive(true);
                    }
                    if (secondary == true)
                    {
                        DeactivateSingleSecondarySelect();
                        secondary1.SetActive(true);

                        DeactivateStat();
                        secondary1Stat.SetActive(true);
                    }
                    if (special == true)
                    {
                        DeactivateSingleSpecialSelect();
                        special1.SetActive(true);

                        DeactivateStat();
                        special1Stat.SetActive(true);
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
                        characterStat.text = "Name: Nomad\nDescription: A confident, hotshot pilot that hunts the machine menace wherever it goes.";
                    }
                    if (ship == true)
                    {
                        DeactivateSingleShipSelect();
                        ship2.SetActive(true);

                        DeactivateStat();
                        ship2Stat.SetActive(true);
                    }
                    if (primary == true)
                    {
                        DeactivateSinglePrimarySelect();
                        primary2.SetActive(true);

                        DeactivateStat();
                        primary2Stat.SetActive(true);
                    }
                    if (secondary == true)
                    {
                        DeactivateSingleSecondarySelect();
                        secondary2.SetActive(true);

                        DeactivateStat();
                        secondary2Stat.SetActive(true);
                    }
                    if (special == true)
                    {
                        DeactivateSingleSpecialSelect();
                        special2.SetActive(true);

                        DeactivateStat();
                        special2Stat.SetActive(true);
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
                        characterStat.text = "Name: Dozer\nDescription: Former truck driver on a quest for vengeance against the machines";
                    }
                    if (ship == true)
                    {
                        DeactivateSingleShipSelect();
                        ship3.SetActive(true);

                        DeactivateStat();
                        ship3Stat.SetActive(true);
                    }
                    if (primary == true)
                    {
                        DeactivateSinglePrimarySelect();
                        primary3.SetActive(true);

                        DeactivateStat();
                        primary3Stat.SetActive(true);
                    }
                    if (secondary == true)
                    {
                        DeactivateSingleSecondarySelect();
                        secondary3.SetActive(true);

                        DeactivateStat();
                        secondary3Stat.SetActive(true);
                    }
                    if (special == true)
                    {
                        DeactivateSingleSpecialSelect();
                        special3.SetActive(true);

                        DeactivateStat();
                        special3Stat.SetActive(true);
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
                        ship4Stat.SetActive(true);
                    }
                    if (primary == true)
                    {
                        P1toggleData = 3;

                        DeactivateSinglePrimarySelect();
                        primary3.SetActive(true);

                        DeactivateStat();
                        primary3Stat.SetActive(true);
                    }
                    if (secondary == true)
                    {
                        P1toggleData = 3;

                        DeactivateSingleSecondarySelect();
                        secondary3.SetActive(true);

                        DeactivateStat();
                        secondary3Stat.SetActive(true);
                    }
                    if (special == true)
                    {
                        P1toggleData = 3;

                        DeactivateSingleSpecialSelect();
                        special3.SetActive(true);

                        DeactivateStat();
                        special3Stat.SetActive(true);
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
                        ship5Stat.SetActive(true);
                    }
                    if (primary == true)
                    {
                        P1toggleData = 3;

                        DeactivateSinglePrimarySelect();
                        primary3.SetActive(true);

                        DeactivateStat();
                        primary3Stat.SetActive(true);
                    }
                    if (secondary == true)
                    {
                        P1toggleData = 3;

                        DeactivateSingleSecondarySelect();
                        secondary3.SetActive(true);

                        DeactivateStat();
                        secondary3Stat.SetActive(true);
                    }
                    if (special == true)
                    {
                        P1toggleData = 3;

                        DeactivateSingleSpecialSelect();
                        special3.SetActive(true);

                        DeactivateStat();
                        special3Stat.SetActive(true);
                    }
                }

                if (Input.GetButtonDown("P1VerticalChoiceUp") && !choosing)
                {
                    ScrollingSound();

                    glowTracker--;
                }
                if (Input.GetButtonDown("P1VerticalChoiceDown") && !choosing)
                {
                    ScrollingSound();

                    glowTracker++;
                }

                if (Input.GetButtonDown("P1HorizontalChoiceLeft"))
                {
                    ScrollingSound();

                    ResetToggleGlow();
                    toggleLeftGlow.fillAmount = 1;

                    P1toggleData--;
                }
                if (Input.GetButtonDown("P1HorizontalChoiceRight"))
                {
                    ScrollingSound();

                    ResetToggleGlow();
                    toggleRightGlow.fillAmount = 1;

                    P1toggleData++;
                }

                if (Input.GetButtonDown("Fire_P1") || FlexToggle.myFlexBool == true)
                {
                    FlexToggle.myFlexBool = false;

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
                            SingleStartButton();
                        }
                    }
                    else
                    {
                        if (P1toggleData == 1)
                        {
                            if (character == true)
                            {
                                P1characterType = 1;
                                characterButtonShader.SetActive(true);
                            }
                            if (ship == true)
                            {
                                P1shipType = 1;
                                shipButtonShader.SetActive(true);

                                P1LightShipData();
                                Player1Data();
                            }
                            if (primary == true)
                            {
                                P1primaryType = 1;
                                primaryButtonShader.SetActive(true);
                            }
                            if (secondary == true)
                            {
                                P1secondaryType = 1;
                                secondaryButtonShader.SetActive(true);
                            }
                            if (special == true)
                            {
                                P1specialType = 1;
                                specialButtonShader.SetActive(true);
                            }
                        }
                        if (P1toggleData == 2)
                        {
                            if (character == true)
                            {
                                P1characterType = 2;
                                characterButtonShader.SetActive(true);
                            }
                            if (ship == true)
                            {
                                P1shipType = 2;
                                shipButtonShader.SetActive(true);

                                P1MediumShipData();
                                Player1Data();
                            }
                            if (primary == true)
                            {
                                P1primaryType = 2;
                                primaryButtonShader.SetActive(true);
                            }
                            if (secondary == true)
                            {
                                P1secondaryType = 2;
                                secondaryButtonShader.SetActive(true);
                            }
                            if (special == true)
                            {
                                P1specialType = 2;
                                specialButtonShader.SetActive(true);
                            }
                        }
                        if (P1toggleData == 3)
                        {
                            if (character == true)
                            {
                                P1characterType = 3;
                                characterButtonShader.SetActive(true);
                            }
                            if (ship == true)
                            {
                                P1shipType = 3;
                                shipButtonShader.SetActive(true);

                                P1HeavyShipData();
                                Player1Data();
                            }
                            if (primary == true)
                            {
                                P1primaryType = 3;
                                primaryButtonShader.SetActive(true);
                            }
                            if (secondary == true)
                            {
                                P1secondaryType = 3;
                                secondaryButtonShader.SetActive(true);
                            }
                            if (special == true)
                            {
                                P1specialType = 3;
                                specialButtonShader.SetActive(true);
                            }
                        }
                        if (P1toggleData == 4)
                        {
                            if (character == true)
                            {
                                P1characterType = 4;
                                characterButtonShader.SetActive(true);
                            }
                            if (ship == true)
                            {
                                P1shipType = 4;
                                shipButtonShader.SetActive(true);

                                P1LamboShooterData();
                                Player1Data();
                            }
                            if (primary == true)
                            {
                                P1primaryType = 3;
                                primaryButtonShader.SetActive(true);
                            }
                            if (secondary == true)
                            {
                                P1secondaryType = 3;
                                secondaryButtonShader.SetActive(true);
                            }
                            if (special == true)
                            {
                                P1specialType = 3;
                                specialButtonShader.SetActive(true);
                            }
                        }
                        if (P1toggleData == 5)
                        {
                            if (character == true)
                            {
                                P1characterType = 4;
                                characterButtonShader.SetActive(true);
                            }
                            if (ship == true)
                            {
                                P1shipType = 5;
                                shipButtonShader.SetActive(true);

                                P1TruckShooterData();
                                Player1Data();
                            }
                            if (primary == true)
                            {
                                P1primaryType = 3;
                                primaryButtonShader.SetActive(true);
                            }
                            if (secondary == true)
                            {
                                P1secondaryType = 3;
                                secondaryButtonShader.SetActive(true);
                            }
                            if (special == true)
                            {
                                P1specialType = 3;
                                specialButtonShader.SetActive(true);
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
                if (P1glowTracker == 2)
                {
                    ResetP1Glow();
                    P1shipButtonGlow.fillAmount = 1;
                }
                if (P1glowTracker == 3)
                {
                    ResetP1Glow();
                    P1primaryButtonGlow.fillAmount = 1;
                }
                if (P1glowTracker == 4)
                {
                    ResetP1Glow();
                    P1secondaryButtonGlow.fillAmount = 1;
                }
                if (P1glowTracker == 5)
                {
                    ResetP1Glow();
                    P1specialButtonGlow.fillAmount = 1;
                }
                if (P1glowTracker >= 6)
                {
                    P1glowTracker = 6;

                    ResetP1Glow();
                    doubleReturnButtonGlow.fillAmount = 1;
                }

                if (P2glowTracker <= 1)
                {
                    P2glowTracker = 1;

                    ResetP2Glow();
                    P2characterButtonGlow.fillAmount = 1;
                }
                if (P2glowTracker == 2)
                {
                    ResetP2Glow();
                    P2shipButtonGlow.fillAmount = 1;
                }
                if (P2glowTracker == 3)
                {
                    ResetP2Glow();
                    P2primaryButtonGlow.fillAmount = 1;
                }
                if (P2glowTracker == 4)
                {
                    ResetP2Glow();
                    P2secondaryButtonGlow.fillAmount = 1;
                }
                if (P2glowTracker == 5)
                {
                    ResetP2Glow();
                    P2specialButtonGlow.fillAmount = 1;
                }
                if (P2glowTracker >= 6)
                {
                    P2glowTracker = 6;

                    ResetP2Glow();
                    doubleStartButtonGlow.fillAmount = 1;
                }

                if (P1toggleData <= 1)
                {
                    P1toggleData = 1;

                    if (P1character == true)
                    {
                        DeactivateP1CharacterSelect();
                        P1character1.SetActive(true);

                        DeactivateP1Stat();
                        P1characterStat.enabled = true;
                        P1characterStat.text = "Name: Sparky\nDescription: Truck driver turned toaster hunter after losing her truck";
                    }
                    if (P1ship == true)
                    {
                        DeactivateP1ShipSelect();
                        P1ship1.SetActive(true);

                        DeactivateP1Stat();
                        P1ship1Stat.SetActive(true);
                    }
                    if (P1primary == true)
                    {
                        DeactivateP1PrimarySelect();
                        P1primary1.SetActive(true);

                        DeactivateP1Stat();
                        P1primary1Stat.SetActive(true);
                    }
                    if (P1secondary == true)
                    {
                        DeactivateP1SecondarySelect();
                        P1secondary1.SetActive(true);

                        DeactivateP1Stat();
                        P1secondary1Stat.SetActive(true);
                    }
                    if (P1special == true)
                    {
                        DeactivateP1SpecialSelect();
                        P1special1.SetActive(true);

                        DeactivateP1Stat();
                        P1special1Stat.SetActive(true);
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
                        P1characterStat.text = "Name: Nomad\nDescription: A confident, hotshot pilot that hunts the machine menace wherever it goes.";
                    }
                    if (P1ship == true)
                    {
                        DeactivateP1ShipSelect();
                        P1ship2.SetActive(true);

                        DeactivateP1Stat();
                        P1ship2Stat.SetActive(true);
                    }
                    if (P1primary == true)
                    {
                        DeactivateP1PrimarySelect();
                        P1primary2.SetActive(true);

                        DeactivateP1Stat();
                        P1primary2Stat.SetActive(true);
                    }
                    if (P1secondary == true)
                    {
                        DeactivateP1SecondarySelect();
                        P1secondary2.SetActive(true);

                        DeactivateP1Stat();
                        P1secondary2Stat.SetActive(true);
                    }
                    if (P1special == true)
                    {
                        DeactivateP1SpecialSelect();
                        P1special2.SetActive(true);

                        DeactivateP1Stat();
                        P1special2Stat.SetActive(true);
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
                        P1characterStat.text = "Name: Dozer\nDescription: Former truck driver on a quest for vengeance against the machines";
                    }
                    if (P1ship == true)
                    {
                        DeactivateP1ShipSelect();
                        P1ship3.SetActive(true);

                        DeactivateP1Stat();
                        P1ship3Stat.SetActive(true);
                    }
                    if (P1primary == true)
                    {
                        DeactivateP1PrimarySelect();
                        P1primary3.SetActive(true);

                        DeactivateP1Stat();
                        P1primary3Stat.SetActive(true);
                    }
                    if (P1secondary == true)
                    {
                        DeactivateP1SecondarySelect();
                        P1secondary3.SetActive(true);

                        DeactivateP1Stat();
                        P1secondary3Stat.SetActive(true);
                    }
                    if (P1special == true)
                    {
                        DeactivateP1SpecialSelect();
                        P1special3.SetActive(true);

                        DeactivateP1Stat();
                        P1special3Stat.SetActive(true);
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
                        P1ship4Stat.SetActive(true);
                    }
                    if (P1primary == true)
                    {
                        P1toggleData = 3;

                        DeactivateP1PrimarySelect();
                        P1primary3.SetActive(true);

                        DeactivateP1Stat();
                        P1primary3Stat.SetActive(true);
                    }
                    if (P1secondary == true)
                    {
                        P1toggleData = 3;

                        DeactivateP1SecondarySelect();
                        P1secondary3.SetActive(true);

                        DeactivateP1Stat();
                        P1secondary3Stat.SetActive(true);
                    }
                    if (P1special == true)
                    {
                        P1toggleData = 3;

                        DeactivateP1SpecialSelect();
                        P1special3.SetActive(true);

                        DeactivateP1Stat();
                        P1special3Stat.SetActive(true);
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
                        P1ship5Stat.SetActive(true);
                    }
                    if (P1primary == true)
                    {
                        P1toggleData = 3;

                        DeactivateP1PrimarySelect();
                        P1primary3.SetActive(true);

                        DeactivateP1Stat();
                        P1primary3Stat.SetActive(true);
                    }
                    if (P1secondary == true)
                    {
                        P1toggleData = 3;

                        DeactivateP1SecondarySelect();
                        P1secondary3.SetActive(true);

                        DeactivateP1Stat();
                        P1secondary3Stat.SetActive(true);
                    }
                    if (P1special == true)
                    {
                        P1toggleData = 3;

                        DeactivateP1SpecialSelect();
                        P1special3.SetActive(true);

                        DeactivateP1Stat();
                        P1special3Stat.SetActive(true);
                    }
                }

                if (P2toggleData <= 1)
                {
                    P2toggleData = 1;

                    if (P2character == true)
                    {
                        DeactivateP2CharacterSelect();
                        P2character1.SetActive(true);

                        DeactivateP2Stat();
                        P2characterStat.enabled = true;
                        P2characterStat.text = "Name: Sparky\nDescription: Truck driver turned toaster hunter after losing her truck";
                    }
                    if (P2ship == true)
                    {
                        DeactivateP2ShipSelect();
                        P2ship1.SetActive(true);

                        DeactivateP2Stat();
                        P2ship1Stat.SetActive(true);
                    }
                    if (P2primary == true)
                    {
                        DeactivateP2PrimarySelect();
                        P2primary1.SetActive(true);

                        DeactivateP2Stat();
                        P2primary1Stat.SetActive(true);
                    }
                    if (P2secondary == true)
                    {
                        DeactivateP2SecondarySelect();
                        P2secondary1.SetActive(true);

                        DeactivateP2Stat();
                        P2secondary1Stat.SetActive(true);
                    }
                    if (P2special == true)
                    {
                        DeactivateP2SpecialSelect();
                        P2special1.SetActive(true);

                        DeactivateP2Stat();
                        P2special1Stat.SetActive(true);
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
                        P2characterStat.text = "Name: Nomad\nDescription: A confident, hotshot pilot that hunts the machine menace wherever it goes.";
                    }
                    if (P2ship == true)
                    {
                        DeactivateP2ShipSelect();
                        P2ship2.SetActive(true);

                        DeactivateP2Stat();
                        P2ship2Stat.SetActive(true);
                    }
                    if (P2primary == true)
                    {
                        DeactivateP2PrimarySelect();
                        P2primary2.SetActive(true);

                        DeactivateP2Stat();
                        P2primary2Stat.SetActive(true);
                    }
                    if (P2secondary == true)
                    {
                        DeactivateP2SecondarySelect();
                        P2secondary2.SetActive(true);

                        DeactivateP2Stat();
                        P2secondary2Stat.SetActive(true);
                    }
                    if (P2special == true)
                    {
                        DeactivateP2SpecialSelect();
                        P2special2.SetActive(true);

                        DeactivateP2Stat();
                        P2special2Stat.SetActive(true);
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
                        P2characterStat.text = "Name: Dozer\nDescription: Former truck driver on a quest for vengeance against the machines";
                    }
                    if (P2ship == true)
                    {
                        DeactivateP2ShipSelect();
                        P2ship3.SetActive(true);

                        DeactivateP2Stat();
                        P2ship3Stat.SetActive(true);
                    }
                    if (P2primary == true)
                    {
                        DeactivateP2PrimarySelect();
                        P2primary3.SetActive(true);

                        DeactivateP2Stat();
                        P2primary3Stat.SetActive(true);
                    }
                    if (P2secondary == true)
                    {
                        DeactivateP2SecondarySelect();
                        P2secondary3.SetActive(true);

                        DeactivateP2Stat();
                        P2secondary3Stat.SetActive(true);
                    }
                    if (P2special == true)
                    {
                        DeactivateP2SpecialSelect();
                        P2special3.SetActive(true);

                        DeactivateP2Stat();
                        P2special3Stat.SetActive(true);
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
                        P2ship4Stat.SetActive(true);
                    }
                    if (P2primary == true)
                    {
                        P2toggleData = 3;

                        DeactivateP2PrimarySelect();
                        P2primary3.SetActive(true);

                        DeactivateP2Stat();
                        P2primary3Stat.SetActive(true);
                    }
                    if (P2secondary == true)
                    {
                        P2toggleData = 3;

                        DeactivateP2SecondarySelect();
                        P2secondary3.SetActive(true);

                        DeactivateP2Stat();
                        P2secondary3Stat.SetActive(true);
                    }
                    if (P2special == true)
                    {
                        P2toggleData = 3;

                        DeactivateP2SpecialSelect();
                        P2special3.SetActive(true);

                        DeactivateP2Stat();
                        P2special3Stat.SetActive(true);
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
                        P2ship5Stat.SetActive(true);
                    }
                    if (P2primary == true)
                    {
                        P2toggleData = 3;

                        DeactivateP2PrimarySelect();
                        P2primary3.SetActive(true);

                        DeactivateP2Stat();
                        P2primary3Stat.SetActive(true);
                    }
                    if (P2secondary == true)
                    {
                        P2toggleData = 3;

                        DeactivateP2SecondarySelect();
                        P2secondary3.SetActive(true);

                        DeactivateP2Stat();
                        P2secondary3Stat.SetActive(true);
                    }
                    if (P2special == true)
                    {
                        P2toggleData = 3;

                        DeactivateP2SpecialSelect();
                        P2special3.SetActive(true);

                        DeactivateP2Stat();
                        P2special3Stat.SetActive(true);
                    }
                }

                if (Input.GetButtonDown("P1VerticalChoiceUp") && !P1choosing)
                {
                    ScrollingSound();

                    P1glowTracker--;
                }
                if (Input.GetButtonDown("P1VerticalChoiceDown") && !P1choosing)
                {
                    ScrollingSound();

                    P1glowTracker++;
                }

                if ((Input.GetButtonDown("P2VerticalChoiceUp") || Input.GetKeyDown(KeyCode.Keypad8)) && !P2choosing)
                {
                    ScrollingSound();

                    P2glowTracker--;
                }
                if ((Input.GetButtonDown("P2VerticalChoiceDown") || Input.GetKeyDown(KeyCode.Keypad5)) && !P2choosing)
                {
                    ScrollingSound();

                    P2glowTracker++;
                }

                if (Input.GetButtonDown("P1HorizontalChoiceLeft"))
                {
                    ScrollingSound();

                    ResetP1ToggleGlow();
                    P1toggleLeftGlow.fillAmount = 1;

                    P1toggleData--;
                }
                if (Input.GetButtonDown("P1HorizontalChoiceRight"))
                {
                    ScrollingSound();

                    ResetP1ToggleGlow();
                    P1toggleRightGlow.fillAmount = 1;

                    P1toggleData++;
                }

                if (Input.GetButtonDown("P2HorizontalChoiceLeft") || Input.GetKeyDown(KeyCode.Keypad4))
                {
                    ScrollingSound();

                    ResetP2ToggleGlow();
                    P2toggleLeftGlow.fillAmount = 1;

                    P2toggleData++;
                }
                if (Input.GetButtonDown("P2HorizontalChoiceRight") || Input.GetKeyDown(KeyCode.Keypad6))
                {
                    ScrollingSound();

                    ResetP2ToggleGlow();
                    P2toggleRightGlow.fillAmount = 1;

                    P2toggleData--;
                }

                if (Input.GetButtonDown("Fire_P1") || FlexToggle.myFlexBool == true)
                {
                    FlexToggle.myFlexBool = false;

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
                                P1characterButtonShader.SetActive(true);
                            }
                            if (P1ship == true)
                            {
                                P1shipType = 1;
                                P1shipButtonShader.SetActive(true);

                                P1LightShipData();
                                Player1Data();
                            }
                            if (P1primary == true)
                            {
                                P1primaryType = 1;
                                P1primaryButtonShader.SetActive(true);
                            }
                            if (P1secondary == true)
                            {
                                P1secondaryType = 1;
                                P1secondaryButtonShader.SetActive(true);
                            }
                            if (P1special == true)
                            {
                                P1specialType = 1;
                                P1specialButtonShader.SetActive(true);
                            }
                        }
                        if (P1toggleData == 2)
                        {
                            if (P1character == true)
                            {
                                P1characterType = 2;
                                P1characterButtonShader.SetActive(true);
                            }
                            if (P1ship == true)
                            {
                                P1shipType = 2;
                                P1shipButtonShader.SetActive(true);

                                P1MediumShipData();
                                Player1Data();
                            }
                            if (P1primary == true)
                            {
                                P1primaryType = 2;
                                P1primaryButtonShader.SetActive(true);
                            }
                            if (P1secondary == true)
                            {
                                P1secondaryType = 2;
                                P1secondaryButtonShader.SetActive(true);
                            }
                            if (P1special == true)
                            {
                                P1specialType = 2;
                                P1specialButtonShader.SetActive(true);
                            }
                        }
                        if (P1toggleData == 3)
                        {
                            if (P1character == true)
                            {
                                P1characterType = 3;
                                P1characterButtonShader.SetActive(true);
                            }
                            if (P1ship == true)
                            {
                                P1shipType = 3;
                                P1shipButtonShader.SetActive(true);

                                P1HeavyShipData();
                                Player1Data();
                            }
                            if (P1primary == true)
                            {
                                P1primaryType = 3;
                                P1primaryButtonShader.SetActive(true);
                            }
                            if (P1secondary == true)
                            {
                                P1secondaryType = 3;
                                P1secondaryButtonShader.SetActive(true);
                            }
                            if (P1special == true)
                            {
                                P1specialType = 3;
                                P1specialButtonShader.SetActive(true);
                            }
                        }
                        if (P1toggleData == 4)
                        {
                            if (P1character == true)
                            {
                                P1characterType = 4;
                                P1characterButtonShader.SetActive(true);
                            }
                            if (P1ship == true)
                            {
                                P1shipType = 4;
                                P1shipButtonShader.SetActive(true);

                                P1LamboShooterData();
                                Player1Data();
                            }
                            if (P1primary == true)
                            {
                                P1primaryType = 3;
                                P1primaryButtonShader.SetActive(true);
                            }
                            if (P1secondary == true)
                            {
                                P1secondaryType = 3;
                                P1secondaryButtonShader.SetActive(true);
                            }
                            if (P1special == true)
                            {
                                P1specialType = 3;
                                P1specialButtonShader.SetActive(true);
                            }
                        }
                        if (P1toggleData == 5)
                        {
                            if (P1character == true)
                            {
                                P1characterType = 4;
                                P1characterButtonShader.SetActive(true);
                            }
                            if (P1ship == true)
                            {
                                P1shipType = 5;
                                P1shipButtonShader.SetActive(true);

                                P1TruckShooterData();
                                Player1Data();
                            }
                            if (P1primary == true)
                            {
                                P1primaryType = 3;
                                P1primaryButtonShader.SetActive(true);
                            }
                            if (P1secondary == true)
                            {
                                P1secondaryType = 3;
                                P1secondaryButtonShader.SetActive(true);
                            }
                            if (P1special == true)
                            {
                                P1specialType = 3;
                                P1specialButtonShader.SetActive(true);
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
                if (Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
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
                            DoubleStartButton();
                        }
                    }
                    else
                    {
                        if (P2toggleData == 1)
                        {
                            if (P2character == true)
                            {
                                P2characterType = 1;
                                P2characterButtonShader.SetActive(true);
                            }
                            if (P2ship == true)
                            {
                                P2shipType = 1;
                                P2shipButtonShader.SetActive(true);

                                P2LightShipData();
                                Player2Data();
                            }
                            if (P2primary == true)
                            {
                                P2primaryType = 1;
                                P2primaryButtonShader.SetActive(true);
                            }
                            if (P2secondary == true)
                            {
                                P2secondaryType = 1;
                                P2secondaryButtonShader.SetActive(true);
                            }
                            if (P2special == true)
                            {
                                P2specialType = 1;
                                P2specialButtonShader.SetActive(true);
                            }
                        }
                        if (P2toggleData == 2)
                        {
                            if (P2character == true)
                            {
                                P2characterType = 2;
                                P2characterButtonShader.SetActive(true);
                            }
                            if (P2ship == true)
                            {
                                P2shipType = 2;
                                P2shipButtonShader.SetActive(true);

                                P2MediumShipData();
                                Player2Data();
                            }
                            if (P2primary == true)
                            {
                                P2primaryType = 2;
                                P2primaryButtonShader.SetActive(true);
                            }
                            if (P2secondary == true)
                            {
                                P2secondaryType = 2;
                                P2secondaryButtonShader.SetActive(true);
                            }
                            if (P2special == true)
                            {
                                P2specialType = 2;
                                P2specialButtonShader.SetActive(true);
                            }
                        }
                        if (P2toggleData == 3)
                        {
                            if (P2character == true)
                            {
                                P2characterType = 3;
                                P2characterButtonShader.SetActive(true);
                            }
                            if (P2ship == true)
                            {
                                P2shipType = 3;
                                P2shipButtonShader.SetActive(true);

                                P2HeavyShipData();
                                Player2Data();
                            }
                            if (P2primary == true)
                            {
                                P2primaryType = 3;
                                P2primaryButtonShader.SetActive(true);
                            }
                            if (P2secondary == true)
                            {
                                P2secondaryType = 3;
                                P2secondaryButtonShader.SetActive(true);
                            }
                            if (P2special == true)
                            {
                                P2specialType = 3;
                                P2specialButtonShader.SetActive(true);
                            }
                        }
                        if (P2toggleData == 4)
                        {
                            if (P2character == true)
                            {
                                P2characterType = 4;
                                P2characterButtonShader.SetActive(true);
                            }
                            if (P2ship == true)
                            {
                                P2shipType = 4;
                                P2shipButtonShader.SetActive(true);

                                P2LamboShooterData();
                                Player2Data();
                            }
                            if (P2primary == true)
                            {
                                P2primaryType = 3;
                                P2primaryButtonShader.SetActive(true);
                            }
                            if (P2secondary == true)
                            {
                                P2secondaryType = 3;
                                P2secondaryButtonShader.SetActive(true);
                            }
                            if (P2special == true)
                            {
                                P2specialType = 3;
                                P2specialButtonShader.SetActive(true);
                            }
                        }
                        if (P2toggleData == 5)
                        {
                            if (P2character == true)
                            {
                                P2characterType = 4;
                                P2characterButtonShader.SetActive(true);
                            }
                            if (P2ship == true)
                            {
                                P2shipType = 5;
                                P2shipButtonShader.SetActive(true);

                                P2TruckShooterData();
                                Player2Data();
                            }
                            if (P2primary == true)
                            {
                                P2primaryType = 3;
                                P2primaryButtonShader.SetActive(true);
                            }
                            if (P2secondary == true)
                            {
                                P2secondaryType = 3;
                                P2secondaryButtonShader.SetActive(true);
                            }
                            if (P2special == true)
                            {
                                P2specialType = 3;
                                P2specialButtonShader.SetActive(true);
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
    }
    IEnumerator Timer()
    {
        buttonSoundEffect = GetComponents<AudioSource>();
        soundEffect = new AudioClip[]
        {
            (AudioClip)Resources.Load("Music/MenuSound/ScrollingSound"),
        };

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

        yield return new WaitForSeconds(2.5f);

        waiting = true;
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
        ship1Stat.SetActive(false);
        ship2Stat.SetActive(false);
        ship3Stat.SetActive(false);
        ship4Stat.SetActive(false);
        ship5Stat.SetActive(false);
        primary1Stat.SetActive(false);
        primary2Stat.SetActive(false);
        primary3Stat.SetActive(false);
        secondary1Stat.SetActive(false);
        secondary2Stat.SetActive(false);
        secondary3Stat.SetActive(false);
        special1Stat.SetActive(false);
        special2Stat.SetActive(false);
        special3Stat.SetActive(false);
}
    private void DeactivateP1Stat()
    {
        P1characterStat.enabled = false;
        P1ship1Stat.SetActive(false);
        P1ship2Stat.SetActive(false);
        P1ship3Stat.SetActive(false);
        P1ship4Stat.SetActive(false);
        P1ship5Stat.SetActive(false);
        P1primary1Stat.SetActive(false);
        P1primary2Stat.SetActive(false);
        P1primary3Stat.SetActive(false);
        P1secondary1Stat.SetActive(false);
        P1secondary2Stat.SetActive(false);
        P1secondary3Stat.SetActive(false);
        P1special1Stat.SetActive(false);
        P1special2Stat.SetActive(false);
        P1special3Stat.SetActive(false);
    }
    private void DeactivateP2Stat()
    {
        P2characterStat.enabled = false;
        P2ship1Stat.SetActive(false);
        P2ship2Stat.SetActive(false);
        P2ship3Stat.SetActive(false);
        P2ship4Stat.SetActive(false);
        P2ship5Stat.SetActive(false);
        P2primary1Stat.SetActive(false);
        P2primary2Stat.SetActive(false);
        P2primary3Stat.SetActive(false);
        P2secondary1Stat.SetActive(false);
        P2secondary2Stat.SetActive(false);
        P2secondary3Stat.SetActive(false);
        P2special1Stat.SetActive(false);
        P2special2Stat.SetActive(false);
        P2special3Stat.SetActive(false);
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
        PlayerHealthSystem.P1maxLives = 5;
    }
    //player 2 light ship
    private void P2LightShipData()
    {
        PlayerHealthSystem.P2maxHealth = 100;
        PlayerHealthSystem.P2maxShields = 75;
        PlayerHealthSystem.P2maxLives = 5;
    }

    //player 1 medium ship
    private void P1MediumShipData()
    {
        PlayerHealthSystem.P1maxHealth = 125;
        PlayerHealthSystem.P1maxShields = 100;
        PlayerHealthSystem.P1maxLives = 5;
    }
    //player 2 medium ship
    private void P2MediumShipData()
    {
        PlayerHealthSystem.P2maxHealth = 125;
        PlayerHealthSystem.P2maxShields = 100;
        PlayerHealthSystem.P2maxLives = 5;
    }

    //plaer 1 heavy ship
    private void P1HeavyShipData()
    {
        PlayerHealthSystem.P1maxHealth = 150;
        PlayerHealthSystem.P1maxShields = 125;
        PlayerHealthSystem.P1maxLives = 5;
    }
    //plaer 2 heavy ship
    private void P2HeavyShipData()
    {
        PlayerHealthSystem.P2maxHealth = 150;
        PlayerHealthSystem.P2maxShields = 125;
        PlayerHealthSystem.P2maxLives = 5;
    }

    //player 1 lambo shooter
    private void P1LamboShooterData()
    {
        PlayerHealthSystem.P1maxHealth = 50;
        PlayerHealthSystem.P1maxShields = 125;
        PlayerHealthSystem.P1maxLives = 5;
    }
    //player 2 lambo shooter
    private void P2LamboShooterData()
    {
        PlayerHealthSystem.P2maxHealth = 50;
        PlayerHealthSystem.P2maxShields = 125;
        PlayerHealthSystem.P2maxLives = 5;
    }

    //player 1 truck shooter
    private void P1TruckShooterData()
    {
        PlayerHealthSystem.P1maxHealth = 200;
        PlayerHealthSystem.P1maxShields = 200;
        PlayerHealthSystem.P1maxLives = 5;
    }
    //player 2 truck shooter
    private void P2TruckShooterData()
    {
        PlayerHealthSystem.P2maxHealth = 200;
        PlayerHealthSystem.P2maxShields = 200;
        PlayerHealthSystem.P2maxLives = 5;
    }

    //player 1 ship data
    private void Player1Data()
    {
        PlayerHealthSystem.P1savedHealth = PlayerHealthSystem.P1maxHealth;
        PlayerHealthSystem.P1savedShields = PlayerHealthSystem.P1maxShields;
        PlayerHealthSystem.P1savedLives = 3;
    }
    //player 2 ship data
    private void Player2Data()
    {
        PlayerHealthSystem.P2savedHealth = PlayerHealthSystem.P2maxHealth;
        PlayerHealthSystem.P2savedShields = PlayerHealthSystem.P2maxShields;
        PlayerHealthSystem.P2savedLives = 3;
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
        Player1WeaponData();

        ResetBool();

        SceneManager.LoadScene("Level1");
    }
    public void DoubleStartButton()
    {
        Player1WeaponData();
        Player2WeaponData();

        ResetBool();

        SceneManager.LoadScene("Level1");
    }

    public void ReturnButton()
    {
        Destroy(GameObject.Find("MenuMusicController"));
        Destroy(GameObject.Find("HangarMusicController"));

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
        P2special = true;
    }

    private void ScrollingSound()
    {
        buttonSoundEffect[0].Stop();
        buttonSoundEffect[0].clip = soundEffect[0];
        buttonSoundEffect[0].Play();
    }
}
