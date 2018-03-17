using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionMenuController : MonoBehaviour
{
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

    private int toggleData;
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
    private bool P2character;
    private bool P2ship;
    private bool P2primary;
    private bool P2secondary;
    private bool P2special;

    public GameObject SingleMenu;
    public GameObject P1Menu;
    public GameObject P2Menu;

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

    public GameObject selectionText;

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
        ResetToggleData();

        DeactivateSelectionText();
    }

    private void Start()
    {
        PlayerWeaponController.baseWLevel = 1;
        PlayerWeaponController.baseSecondaryLevel = 0;
        PlayerWeaponController.superAmmoDefault = 3;

        if (MainMenuController.onePlayer)
        {
            ActivateSingleSelection();
        }
        else
        {
            ActivatePlayer1Selection();
            ActivatePlayer2Selection();
        }
    }

    private void Update()
    {
        if (MainMenuController.onePlayer)
        {
            if (P1characterType > 0 && P1shipType > 0 && P1primaryType > 0 && P1secondaryType > 0 && P1specialType > 0)
            {
                singleStartButton.SetActive(true);
            }
            else
            {
                singleStartButton.SetActive(false);
            }
        }
        else
        {
            if (P1characterType > 0 && P1shipType > 0 && P1primaryType > 0 && P1secondaryType > 0 && P1specialType > 0 && P2characterType > 0 && P2shipType > 0 && P2primaryType > 0 && P2secondaryType > 0 && P2specialType > 0)
            {
                doubleStartButton.SetActive(true);
            }
            else
            {
                doubleStartButton.SetActive(false);
            }
        }
        
        if(toggleData > 5)
        {
            toggleData = 5;
            return;
        }

        if (toggleData <= 0)
        {
            toggleData = 1;

            if (character == true)
            {
                DeactivateSingleCharacterSelect();
                character1.SetActive(true);
            }
            if (ship == true)
            {
                DeactivateSingleShipSelect();
                ship1.SetActive(true);
            }
            if (primary == true)
            {
                DeactivateSinglePrimarySelect();
                primary1.SetActive(true);
            }
            if (secondary == true)
            {
                DeactivateSingleSecondarySelect();
                secondary1.SetActive(true);
            }
            if (special == true)
            {
                DeactivateSingleSpecialSelect();
                special1.SetActive(true);
            }

            if (P1character == true)
            {
                DeactivateP1CharacterSelect();
                P1character1.SetActive(true);
            }
            if (P1ship == true)
            {
                DeactivateP1ShipSelect();
                P1ship1.SetActive(true);
            }
            if (P1primary == true)
            {
                DeactivateP1PrimarySelect();
                P1primary1.SetActive(true);
            }
            if (P1secondary == true)
            {
                DeactivateP1SecondarySelect();
                P1secondary1.SetActive(true);
            }
            if (P1special == true)
            {
                DeactivateP1SpecialSelect();
                P1special1.SetActive(true);
            }

            if (P2character == true)
            {
                DeactivateP2CharacterSelect();
                P2character1.SetActive(true);
            }
            if (P2ship == true)
            {
                DeactivateP2ShipSelect();
                P2ship1.SetActive(true);
            }
            if (P2primary == true)
            {
                DeactivateP2PrimarySelect();
                P2primary1.SetActive(true);
            }
            if (P2secondary == true)
            {
                DeactivateP2SecondarySelect();
                P2secondary1.SetActive(true);
            }
            if (P2special == true)
            {
                DeactivateP2SpecialSelect();
                P2special1.SetActive(true);
            }
        }
        if (toggleData == 1)
        {
            if (character == true)
            {
                DeactivateSingleCharacterSelect();
                character1.SetActive(true);
            }
            if (ship == true)
            {
                DeactivateSingleShipSelect();
                ship1.SetActive(true);
            }
            if (primary == true)
            {
                DeactivateSinglePrimarySelect();
                primary1.SetActive(true);
            }
            if (secondary == true)
            {
                DeactivateSingleSecondarySelect();
                secondary1.SetActive(true);
            }
            if (special == true)
            {
                DeactivateSingleSpecialSelect();
                special1.SetActive(true);
            }

            if (P1character == true)
            {
                DeactivateP1CharacterSelect();
                P1character1.SetActive(true);
            }
            if (P1ship == true)
            {
                DeactivateP1ShipSelect();
                P1ship1.SetActive(true);
            }
            if (P1primary == true)
            {
                DeactivateP1PrimarySelect();
                P1primary1.SetActive(true);
            }
            if (P1secondary == true)
            {
                DeactivateP1SecondarySelect();
                P1secondary1.SetActive(true);
            }
            if (P1special == true)
            {
                DeactivateP1SpecialSelect();
                P1special1.SetActive(true);
            }

            if (P2character == true)
            {
                DeactivateP2CharacterSelect();
                P2character1.SetActive(true);
            }
            if (P2ship == true)
            {
                DeactivateP2ShipSelect();
                P2ship1.SetActive(true);
            }
            if (P2primary == true)
            {
                DeactivateP2PrimarySelect();
                P2primary1.SetActive(true);
            }
            if (P2secondary == true)
            {
                DeactivateP2SecondarySelect();
                P2secondary1.SetActive(true);
            }
            if (P2special == true)
            {
                DeactivateP2SpecialSelect();
                P2special1.SetActive(true);
            }
        }
        if (toggleData == 2)
        {
            if (character == true)
            {
                DeactivateSingleCharacterSelect();
                character2.SetActive(true);
            }
            if (ship == true)
            {
                DeactivateSingleShipSelect();
                ship2.SetActive(true);
            }
            if (primary == true)
            {
                DeactivateSinglePrimarySelect();
                primary2.SetActive(true);
            }
            if (secondary == true)
            {
                DeactivateSingleSecondarySelect();
                secondary2.SetActive(true);
            }
            if (special == true)
            {
                DeactivateSingleSpecialSelect();
                special2.SetActive(true);
            }

            if (P1character == true)
            {
                DeactivateP1CharacterSelect();
                P1character2.SetActive(true);
            }
            if (P1ship == true)
            {
                DeactivateP1ShipSelect();
                P1ship2.SetActive(true);
            }
            if (P1primary == true)
            {
                DeactivateP1PrimarySelect();
                P1primary2.SetActive(true);
            }
            if (P1secondary == true)
            {
                DeactivateP1SecondarySelect();
                P1secondary2.SetActive(true);
            }
            if (P1special == true)
            {
                DeactivateP1SpecialSelect();
                P1special2.SetActive(true);
            }

            if (P2character == true)
            {
                DeactivateP2CharacterSelect();
                P2character2.SetActive(true);
            }
            if (P2ship == true)
            {
                DeactivateP2ShipSelect();
                P2ship2.SetActive(true);
            }
            if (P2primary == true)
            {
                DeactivateP2PrimarySelect();
                P2primary2.SetActive(true);
            }
            if (P2secondary == true)
            {
                DeactivateP2SecondarySelect();
                P2secondary2.SetActive(true);
            }
            if (P2special == true)
            {
                DeactivateP2SpecialSelect();
                P2special2.SetActive(true);
            }
        }
        if (toggleData == 3)
        {
            if (character == true)
            {
                DeactivateSingleCharacterSelect();
                character3.SetActive(true);
            }
            if (ship == true)
            {
                DeactivateSingleShipSelect();
                ship3.SetActive(true);
            }
            if (primary == true)
            {
                DeactivateSinglePrimarySelect();
                primary3.SetActive(true);
            }
            if (secondary == true)
            {
                DeactivateSingleSecondarySelect();
                secondary3.SetActive(true);
            }
            if (special == true)
            {
                DeactivateSingleSpecialSelect();
                special3.SetActive(true);
            }

            if (P1character == true)
            {
                DeactivateP1CharacterSelect();
                P1character3.SetActive(true);
            }
            if (P1ship == true)
            {
                DeactivateP1ShipSelect();
                P1ship3.SetActive(true);
            }
            if (P1primary == true)
            {
                DeactivateP1PrimarySelect();
                P1primary3.SetActive(true);
            }
            if (P1secondary == true)
            {
                DeactivateP1SecondarySelect();
                P1secondary3.SetActive(true);
            }
            if (P1special == true)
            {
                DeactivateP1SpecialSelect();
                P1special3.SetActive(true);
            }

            if (P2character == true)
            {
                DeactivateP2CharacterSelect();
                P2character3.SetActive(true);
            }
            if (P2ship == true)
            {
                DeactivateP2ShipSelect();
                P2ship3.SetActive(true);
            }
            if (P2primary == true)
            {
                DeactivateP2PrimarySelect();
                P2primary3.SetActive(true);
            }
            if (P2secondary == true)
            {
                DeactivateP2SecondarySelect();
                P2secondary3.SetActive(true);
            }
            if (P2special == true)
            {
                DeactivateP2SpecialSelect();
                P2special3.SetActive(true);
            }
        }
        if (toggleData == 4)
        {
            if (character == true)
            {
                DeactivateSingleShipSelect();
                character4.SetActive(true);
            }
            if (ship == true)
            {
                DeactivateSingleShipSelect();
                ship4.SetActive(true);
            }
            if (primary == true)
            {
                toggleData = 3;

                DeactivateSinglePrimarySelect();
                primary3.SetActive(true);
            }
            if (secondary == true)
            {
                toggleData = 3;

                DeactivateSingleSecondarySelect();
                secondary3.SetActive(true);
            }
            if (special == true)
            {
                toggleData = 3;

                DeactivateSingleSpecialSelect();
                special3.SetActive(true);
            }

            if (P1character == true)
            {
                DeactivateP1CharacterSelect();
                P1character4.SetActive(true);
            }
            if (P1ship == true)
            {
                DeactivateP1ShipSelect();
                P1ship4.SetActive(true);
            }
            if (P1primary == true)
            {
                toggleData = 3;

                DeactivateP1PrimarySelect();
                P1primary3.SetActive(true);
            }
            if (P1secondary == true)
            {
                toggleData = 3;

                DeactivateP1SecondarySelect();
                P1secondary3.SetActive(true);
            }
            if (P1special == true)
            {
                toggleData = 3;

                DeactivateP1SpecialSelect();
                P1special3.SetActive(true);
            }

            if (P2character == true)
            {
                DeactivateP2CharacterSelect();
                P2character4.SetActive(true);
            }
            if (P2ship == true)
            {
                DeactivateP2ShipSelect();
                P2ship4.SetActive(true);
            }
            if (P2primary == true)
            {
                toggleData = 3;

                DeactivateP2PrimarySelect();
                P2primary3.SetActive(true);
            }
            if (P2secondary == true)
            {
                toggleData = 3;

                DeactivateP2SecondarySelect();
                P2secondary3.SetActive(true);
            }
            if (P2special == true)
            {
                toggleData = 3;

                DeactivateP2SpecialSelect();
                P2special3.SetActive(true);
            }
        }
        if (toggleData == 5)
        {
            if (character == true)
            {
                toggleData = 4;

                DeactivateSingleShipSelect();
                character4.SetActive(true);
            }
            if (ship == true)
            {
                DeactivateSingleShipSelect();
                ship5.SetActive(true);
            }
            if (primary == true)
            {
                toggleData = 3;

                DeactivateSinglePrimarySelect();
                primary3.SetActive(true);
            }
            if (secondary == true)
            {
                toggleData = 3;

                DeactivateSingleSecondarySelect();
                secondary3.SetActive(true);
            }
            if (special == true)
            {
                toggleData = 3;

                DeactivateSingleSpecialSelect();
                special3.SetActive(true);
            }

            if (P1character == true)
            {
                toggleData = 4;

                DeactivateP1CharacterSelect();
                P1character4.SetActive(true);
            }
            if (P1ship == true)
            {
                DeactivateP1ShipSelect();
                P1ship5.SetActive(true);
            }
            if (P1primary == true)
            {
                toggleData = 3;

                DeactivateP1PrimarySelect();
                P1primary3.SetActive(true);
            }
            if (P1secondary == true)
            {
                toggleData = 3;

                DeactivateP1SecondarySelect();
                P1secondary3.SetActive(true);
            }
            if (P1special == true)
            {
                toggleData = 3;

                DeactivateP1SpecialSelect();
                P1special3.SetActive(true);
            }

            if (P2character == true)
            {
                toggleData = 4;

                DeactivateP2CharacterSelect();
                P2character4.SetActive(true);
            }
            if (P2ship == true)
            {
                DeactivateP2ShipSelect();
                P2ship5.SetActive(true);
            }
            if (P2primary == true)
            {
                toggleData = 3;

                DeactivateP2PrimarySelect();
                P2primary3.SetActive(true);
            }
            if (P2secondary == true)
            {
                toggleData = 3;

                DeactivateP2SecondarySelect();
                P2secondary3.SetActive(true);
            }
            if (P2special == true)
            {
                toggleData = 3;

                DeactivateP2SpecialSelect();
                P2special3.SetActive(true);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (toggleData <= 0)
            {
                toggleData = 1;

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
            if (toggleData == 1)
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
            if (toggleData == 2)
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
            if (toggleData == 3)
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
            if (toggleData == 4)
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
            if (toggleData == 5)
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
                    toggleData = 3;
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

            if (MainMenuController.onePlayer)
            {
                DeactivateSingleCharacterSelect();
                DeactivateSingleShipSelect();
                DeactivateSinglePrimarySelect();
                DeactivateSingleSecondarySelect();
                DeactivateSingleSpecialSelect();
                DeactivateSingleToggle();

                ActivateSingleSelection();
            }
            else
            {
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

                ActivatePlayer1Selection();
                ActivatePlayer2Selection();
            }

            DeactivateSelectionText();

            ResetBool();
        }
    }

    //turning object on or off
    private void ActivateSingleSelection()
    {
        SingleMenu.SetActive(true);
        singleReturnButton.SetActive(true);
        characterButton.SetActive(true);
        shipButton.SetActive(true);
        primaryButton.SetActive(true);
        secondaryButton.SetActive(true);
        specialButton.SetActive(true);
    }
    private void DeactivateSingleSelection()
    {
        SingleMenu.SetActive(false);
        singleReturnButton.SetActive(false);
        characterButton.SetActive(false);
        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);
    }

    private void ActivatePlayer1Selection()
    {
        P1Menu.SetActive(true);
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
        P2characterButton.SetActive(true);
        P2shipButton.SetActive(true);
        P2primaryButton.SetActive(true);
        P2secondaryButton.SetActive(true);
        P2specialButton.SetActive(true);
    }
    private void DeactivatePlayer2Selection()
    {
        P2Menu.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);
    }

    private void ActivateSelectionText()
    {
        selectionText.SetActive(true);
    }
    private void DeactivateSelectionText()
    {
        selectionText.SetActive(false);
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

    //set data
    private void SetToggleData()
    {
        toggleData = 1;
    }
    private void ResetToggleData()
    {
        toggleData = 0;
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
        PlayerHealthSystem.P1maxHealth = 75;
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
    public void StartButton()
    {
        if(MainMenuController.onePlayer)
        {
            Player1WeaponData();
        }
        if(!MainMenuController.onePlayer)
        {
            Player1WeaponData();
            Player2WeaponData();
        }

        SceneManager.LoadScene("Level1");
    }

    public void ReturnButton()
    {
        ResetBool();
        ResetInt();
        ResetToggleData();
        SceneManager.LoadScene("MainMenu");
    }

    public void LeftToggleButton()
    {
        toggleData++;
    }
    public void RightToggleButton()
    {
        toggleData--;
    }

    public void SinglePlayerCharacterButton()
    {
        ActivateSelectionText();
        ActivateSingleToggle();
        SetToggleData();

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
        ActivateSelectionText();
        ActivateP1Toggle();
        SetToggleData();

        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P1characterButton.SetActive(true);
        P1characterButtonShader.SetActive(true);
        P1character = true;
    }
    public void Player2CharacterButton()
    {
        ActivateSelectionText();
        ActivateP2Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
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
        ActivateSelectionText();
        ActivateSingleToggle();
        SetToggleData();

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
        ActivateSelectionText();
        ActivateP1Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P1shipButton.SetActive(true);
        P1shipButtonShader.SetActive(true);
        P1ship = true;
    }
    public void Player2ShipButton()
    {
        ActivateSelectionText();
        ActivateP2Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
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
        ActivateSelectionText();
        ActivateSingleToggle();
        SetToggleData();

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
        ActivateSelectionText();
        ActivateP1Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P1primaryButton.SetActive(true);
        P1primaryButtonShader.SetActive(true);
        P1primary = true;
    }
    public void Player2PrimaryButton()
    {
        ActivateSelectionText();
        ActivateP2Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
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
        ActivateSelectionText();
        ActivateSingleToggle();
        SetToggleData();

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
        ActivateSelectionText();
        ActivateP1Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1specialButton.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P1secondaryButton.SetActive(true);
        P1secondaryButtonShader.SetActive(true);
        P1secondary = true;
    }
    public void Player2SecondaryButton()
    {
        ActivateSelectionText();
        ActivateP2Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
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
        ActivateSelectionText();
        ActivateSingleToggle();
        SetToggleData();

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
        ActivateSelectionText();
        ActivateP1Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P1specialButton.SetActive(true);
        P1specialButtonShader.SetActive(true);
        P1special = true;
    }
    public void Player2SpecialButton()
    {
        ActivateSelectionText();
        ActivateP2Toggle();
        SetToggleData();

        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);

        P2specialButton.SetActive(true);
        P2specialButtonShader.SetActive(true);
        P2special = true;
    }
}
