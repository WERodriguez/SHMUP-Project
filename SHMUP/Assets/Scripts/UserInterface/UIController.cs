using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static bool onePlayer;

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

    public Animator mainMenuPivot;
    public Animator SelectionPivot;

    public GameObject mainMenu;
    public GameObject singlePlayer;
    public GameObject doublePlayer;
    public GameObject quitButton;

    public GameObject returnButton;
    public GameObject startButton;

    public GameObject P1Menu;
    public GameObject P2Menu;

    public GameObject P1characterButton;
    public GameObject P1shipButton;
    public GameObject P1primaryButton;
    public GameObject P1secondaryButton;
    public GameObject P1specialButton;

    public GameObject P1backButton1;
    public GameObject P1backButton2;
    public GameObject P1backButton3;
    public GameObject P1backButton4;
    public GameObject P1backButton5;

    public GameObject P1characterPanel;
    public GameObject P1character1;
    public GameObject P1character2;
    public GameObject P1character3;
    public GameObject P1character4;

    public GameObject P1shipPanel;
    public GameObject P1ship1;
    public GameObject P1ship2;
    public GameObject P1ship3;
    public GameObject P1ship4;
    public GameObject P1ship5;
    public GameObject P1ship6;

    public GameObject P1primaryPanel;
    public GameObject P1primary1;
    public GameObject P1primary2;
    public GameObject P1primary3;

    public GameObject P1secondaryPanel;
    public GameObject P1secondary1;
    public GameObject P1secondary2;
    public GameObject P1secondary3;

    public GameObject P1specialPanel;
    public GameObject P1special1;
    public GameObject P1special2;
    public GameObject P1special3;
    
    public GameObject P2characterButton;
    public GameObject P2shipButton;
    public GameObject P2primaryButton;
    public GameObject P2secondaryButton;
    public GameObject P2specialButton;
    
    public GameObject P2backButton1;
    public GameObject P2backButton2;
    public GameObject P2backButton3;
    public GameObject P2backButton4;
    public GameObject P2backButton5;

    public GameObject P2characterPanel;
    public GameObject P2character1;
    public GameObject P2character2;
    public GameObject P2character3;
    public GameObject P2character4;

    public GameObject P2shipPanel;
    public GameObject P2ship1;
    public GameObject P2ship2;
    public GameObject P2ship3;
    public GameObject P2ship4;
    public GameObject P2ship5;
    public GameObject P2ship6;

    public GameObject P2primaryPanel;
    public GameObject P2primary1;
    public GameObject P2primary2;
    public GameObject P2primary3;

    public GameObject P2secondaryPanel;
    public GameObject P2secondary1;
    public GameObject P2secondary2;
    public GameObject P2secondary3;

    public GameObject P2specialPanel;
    public GameObject P2special1;
    public GameObject P2special2;
    public GameObject P2special3;

    private void Start()
    {
        onePlayer = true;

        SetPlayerData();

        ActivateMainMenu();
        DeactivateReturnButton();
        DeactivatePlayer1BackButton();
        DeactivatePlayer2BackButton();
        Player1BackButton();
        Player2BackButton();
        DeactivatePlayer1Menu();
        DeactivatePlayer2Menu();
    }

    private void Update()
    {
        if(onePlayer)
        {
            if (P1characterType > 0 && P1shipType > 0 && P1primaryType > 0 && P1secondaryType > 0 && P1specialType > 0)
            {
                startButton.SetActive(true);
            }
            else
            {
                startButton.SetActive(false);
            }
        }
        if(!onePlayer)
        {
            if (P1characterType > 0 && P1shipType > 0 && P1primaryType > 0 && P1secondaryType > 0 && P1specialType > 0 && P2characterType > 0 && P2shipType > 0 && P2primaryType > 0 && P2secondaryType > 0 && P2specialType > 0)
            {
                startButton.SetActive(true);
            }
            else
            {
                startButton.SetActive(false);
            }
        }
    }

    //set player data
    private void SetPlayerData()
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

    //button clicked
    public void StartButton()
    {
        SceneManager.LoadScene("(Testing)TheRange");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    //single player button clicked
    public void SinglePlayerButton()
    {
        onePlayer = true;

        ActivatePlayer1Menu();
        ActivateReturnButton();
        mainMenuPivot.SetBool("SingleClick", true);
        SelectionPivot.SetBool("BackClick", true);
    }

    //double player button clicked
    public void DoublePlayerButton()
    {
        onePlayer = false;

        ActivatePlayer1Menu();
        ActivatePlayer2Menu();
        ActivateReturnButton();
        mainMenuPivot.SetBool("SingleClick", true);
        SelectionPivot.SetBool("BackClick", true);
    }

    //return button clicked
    public void ReturnButton()
    {
        SetPlayerData();
        mainMenuPivot.SetBool("SingleClick", false);
        SelectionPivot.SetBool("BackClick", false);
    }

    //player 1 back button click
    public void Player1BackButton()
    {
        P1characterPanel.SetActive(false);
        P1character1.SetActive(false);
        P1character2.SetActive(false);
        P1character3.SetActive(false);
        P1character4.SetActive(false);

        P1shipPanel.SetActive(false);
        P1ship1.SetActive(false);
        P1ship2.SetActive(false);
        P1ship3.SetActive(false);
        P1ship4.SetActive(false);
        P1ship5.SetActive(false);
        P1ship6.SetActive(false);

        P1primaryPanel.SetActive(false);
        P1primary1.SetActive(false);
        P1primary2.SetActive(false);
        P1primary3.SetActive(false);

        P1secondaryPanel.SetActive(false);
        P1secondary1.SetActive(false);
        P1secondary2.SetActive(false);
        P1secondary3.SetActive(false);

        P1specialPanel.SetActive(false);
        P1special1.SetActive(false);
        P1special2.SetActive(false);
        P1special3.SetActive(false);

        ActivatePlayer1Menu();
        DeactivatePlayer1BackButton();
    }

    //player 2 back button click
    public void Player2BackButton()
    {

        P2characterPanel.SetActive(false);
        P2character1.SetActive(false);
        P2character2.SetActive(false);
        P2character3.SetActive(false);
        P2character4.SetActive(false);

        P2shipPanel.SetActive(false);
        P2ship1.SetActive(false);
        P2ship2.SetActive(false);
        P2ship3.SetActive(false);
        P2ship4.SetActive(false);
        P2ship5.SetActive(false);
        P2ship6.SetActive(false);

        P2primaryPanel.SetActive(false);
        P2primary1.SetActive(false);
        P2primary2.SetActive(false);
        P2primary3.SetActive(false);

        P2secondaryPanel.SetActive(false);
        P2secondary1.SetActive(false);
        P2secondary2.SetActive(false);
        P2secondary3.SetActive(false);

        P2specialPanel.SetActive(false);
        P2special1.SetActive(false);
        P2special2.SetActive(false);
        P2special3.SetActive(false);

        ActivatePlayer2Menu();
        DeactivatePlayer2BackButton();
    }

    //activate P1 character select
    public void ActivatePlayer1CharacterSelect()
    {
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);

        P1characterPanel.SetActive(true);
        P1character1.SetActive(true);
        P1character2.SetActive(true);
        P1character3.SetActive(true);
        P1character4.SetActive(true);

        ActivatePlayer1BackButton();
    }

    //activate P2 character select
    public void ActivatePlayer2CharacterSelect()
    {
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P2characterPanel.SetActive(true);
        P2character1.SetActive(true);
        P2character2.SetActive(true);
        P2character3.SetActive(true);
        P2character4.SetActive(true);

        ActivatePlayer2BackButton();
    }

    //activate player 1 ship select
    public void ActivatePlayer1ShipSelect()
    {
        P1characterButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);

        P1shipPanel.SetActive(true);
        P1ship1.SetActive(true);
        P1ship2.SetActive(true);
        P1ship3.SetActive(true);
        P1ship4.SetActive(true);
        P1ship5.SetActive(true);
        P1ship6.SetActive(true);

        ActivatePlayer1BackButton();
    }

    //activate player 2 ship select
    public void ActivatePlayer2ShipSelect()
    {
        P2characterButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P2shipPanel.SetActive(true);
        P2ship1.SetActive(true);
        P2ship2.SetActive(true);
        P2ship3.SetActive(true);
        P2ship4.SetActive(true);
        P2ship5.SetActive(true);
        P2ship6.SetActive(true);

        ActivatePlayer2BackButton();
    }

    //activate player 1 primary weapon select
    public void ActivatePlayer1PrimarySelect()
    {
        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);

        P1primaryPanel.SetActive(true);
        P1primary1.SetActive(true);
        P1primary2.SetActive(true);
        P1primary3.SetActive(true);

        ActivatePlayer1BackButton();
    }

    //activate player 2 primary weapon select
    public void ActivatePlayer2PrimarySelect()
    {
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P2primaryPanel.SetActive(true);
        P2primary1.SetActive(true);
        P2primary2.SetActive(true);
        P2primary3.SetActive(true);

        ActivatePlayer2BackButton();
    }

    //activate player 1 secondary weapon select
    public void ActivatePlayer1SecondarySelect()
    {
        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1specialButton.SetActive(false);

        P1secondaryPanel.SetActive(true);
        P1secondary1.SetActive(true);
        P1secondary2.SetActive(true);
        P1secondary3.SetActive(true);

        ActivatePlayer1BackButton();
    }

    //activate player 2 secondary weapon select
    public void ActivatePlayer2SecondarySelect()
    {
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2specialButton.SetActive(false);

        P2secondaryPanel.SetActive(true);
        P2secondary1.SetActive(true);
        P2secondary2.SetActive(true);
        P2secondary3.SetActive(true);

        ActivatePlayer2BackButton();
    }

    //activate player 1 special weapon select
    public void ActivatePlayer1SpecialSelect()
    {
        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);

        P1specialPanel.SetActive(true);
        P1special1.SetActive(true);
        P1special2.SetActive(true);
        P1special3.SetActive(true);

        ActivatePlayer1BackButton();
    }

    //activate player 2 special weapon select
    public void ActivatePlayer2SpecialSelect()
    {
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);

        P2specialPanel.SetActive(true);
        P2special1.SetActive(true);
        P2special2.SetActive(true);
        P2special3.SetActive(true);

        ActivatePlayer2BackButton();
    }

    //start taking in data and pass it to another scene
    //player 1 choose character 1
    public void Player1Character1()
    {
        P1characterType = 1;
    }
    //player 1 choose character 2
    public void Player1Character2()
    {
        P1characterType = 2;
    }
    //player 1 choose character 3
    public void Player1Character3()
    {
        P1characterType = 3;
    }
    //player 1 choose character 4
    public void Player1Character4()
    {
        P1characterType = 4;
    }

    //player 1 choose ship 1
    public void Player1Ship1()
    {
        P1shipType = 1;
        HeavyShipData();
    }
    //player 1 choose ship 2
    public void Player1Ship2()
    {
        P1shipType = 2;
    }
    //player 1 choose ship 3
    public void Player1Ship3()
    {
        P1shipType = 3;
    }
    //player 1 choose ship 4
    public void Player1Ship4()
    {
        P1shipType = 4;
    }
    //player 1 choose ship 5
    public void Player1Ship5()
    {
        P1shipType = 5;
    }
    //player 1 choose ship 6
    public void Player1Ship6()
    {
        P1shipType = 6;
    }

    //player 1 choose primary 1
    public void Player1Primary1()
    {
        P1primaryType = 1;
    }
    //player 1 choose primary 2
    public void Player1Primary2()
    {
        P1primaryType = 2;
    }
    //player 1 choose primary 3
    public void Player1Primary3()
    {
        P1primaryType = 3;
    }

    //player 1 choose secondary 1
    public void Player1Secondary1()
    {
        P1secondaryType = 1;
    }
    //player 1 choose secondary 2
    public void Player1Secondary2()
    {
        P1secondaryType = 2;
    }
    //player 1 choose secondary 3
    public void Player1Secondary3()
    {
        P1secondaryType = 3;
    }

    //player 1 choose Special 1
    public void Player1Special1()
    {
        P1specialType = 1;
    }
    //player 1 choose Special 2
    public void Player1Special2()
    {
        P1specialType = 2;
    }
    //player 1 choose Special 3
    public void Player1Special3()
    {
        P1specialType = 3;
    }

    //player 2 choose character 1
    public void Player2Character1()
    {
        P2characterType = 1;
    }
    //player 2 choose character 2
    public void Player2Character2()
    {
        P2characterType = 2;
    }
    //player 2 choose character 3
    public void Player2Character3()
    {
        P2characterType = 3;
    }
    //player 2 choose character 4
    public void Player2Character4()
    {
        P2characterType = 4;
    }

    //player 2 choose ship 1
    public void Player2Ship1()
    {
        P2shipType = 1;
        HeavyShipData();
    }
    //player 2 choose ship 2
    public void Player2Ship2()
    {
        P2shipType = 2;
    }
    //player 2 choose ship 3
    public void Player2Ship3()
    {
        P2shipType = 3;
    }
    //player 2 choose ship 4
    public void Player2Ship4()
    {
        P2shipType = 4;
    }
    //player 2 choose ship 5
    public void Player2Ship5()
    {
        P2shipType = 5;
    }
    //player 2 choose ship 6
    public void Player2Ship6()
    {
        P2shipType = 6;
    }

    //player 2 choose primary 1
    public void Player2Primary1()
    {
        P2primaryType = 1;
    }
    //player 2 choose primary 2
    public void Player2Primary2()
    {
        P2primaryType = 2;
    }
    //player 2 choose primary 3
    public void Player2Primary3()
    {
        P2primaryType = 3;
    }

    //player 2 choose secondary 1
    public void Player2Secondary1()
    {
        P2secondaryType = 1;
    }
    //player 2 choose secondary 2
    public void Player2Secondary2()
    {
        P2secondaryType = 2;
    }
    //player 2 choose secondary 3
    public void Player2Secondary3()
    {
        P2secondaryType = 3;
    }

    //player 2 choose Special 1
    public void Player2Special1()
    {
        P2specialType = 1;
    }
    //player 2 choose Special 2
    public void Player2Special2()
    {
        P2specialType = 2;
    }
    //player 2 choose Special 3
    public void Player2Special3()
    {
        P2specialType = 3;
    }

    //shorten code
    //activate main menu
    private void ActivateMainMenu()
    {
        mainMenu.SetActive(true);
        singlePlayer.SetActive(true);
        doublePlayer.SetActive(true);
        quitButton.SetActive(true);
    }

    //activate return button
    private void ActivateReturnButton()
    {
        returnButton.SetActive(true);
    }

    //deactivate return button
    private void DeactivateReturnButton()
    {
        returnButton.SetActive(false);
    }

    //activate single player button
    private void ActivatePlayer1Menu()
    {
        P1Menu.SetActive(true);
        P1characterButton.SetActive(true);
        P1shipButton.SetActive(true);
        P1primaryButton.SetActive(true);
        P1secondaryButton.SetActive(true);
        P1specialButton.SetActive(true);
    }

    //activate 2 players button
    private void ActivatePlayer2Menu()
    {
        P2Menu.SetActive(true);
        P2characterButton.SetActive(true);
        P2shipButton.SetActive(true);
        P2primaryButton.SetActive(true);
        P2secondaryButton.SetActive(true);
        P2specialButton.SetActive(true);
    }

    //deactivate single player button
    private void DeactivatePlayer1Menu()
    {
        P1Menu.SetActive(false);
        P1characterButton.SetActive(false);
        P1shipButton.SetActive(false);
        P1primaryButton.SetActive(false);
        P1secondaryButton.SetActive(false);
        P1specialButton.SetActive(false);
    }

    //deactivate 2 players button
    private void DeactivatePlayer2Menu()
    {
        P2Menu.SetActive(false);
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);
    }

    //activate player 1 back button
    private void ActivatePlayer1BackButton()
    {
        P1backButton1.SetActive(true);
        P1backButton2.SetActive(true);
        P1backButton3.SetActive(true);
        P1backButton4.SetActive(true);
        P1backButton5.SetActive(true);
    }

    //activate player 2 back button
    private void ActivatePlayer2BackButton()
    {
        P2backButton1.SetActive(true);
        P2backButton2.SetActive(true);
        P2backButton3.SetActive(true);
        P2backButton4.SetActive(true);
        P2backButton5.SetActive(true);
    }

    //deactivate player 1 back button
    private void DeactivatePlayer1BackButton()
    {
        P1backButton1.SetActive(false);
        P1backButton2.SetActive(false);
        P1backButton3.SetActive(false);
        P1backButton4.SetActive(false);
        P1backButton5.SetActive(false);
    }

    //deactivate player 2 back button
    private void DeactivatePlayer2BackButton()
    {
        P2backButton1.SetActive(false);
        P2backButton2.SetActive(false);
        P2backButton3.SetActive(false);
        P2backButton4.SetActive(false);
        P2backButton5.SetActive(false);
    }

    //shorten passing data
    private void HeavyShipData()
    {
        PlayerHealthSystem.maxHealth = 100;
        PlayerHealthSystem.maxShields = 75;
        PlayerHealthSystem.maxLives = 1;

        PlayerHealthSystem.currentHealth = PlayerHealthSystem.maxHealth;
        PlayerHealthSystem.currentShields = PlayerHealthSystem.maxShields;
        PlayerHealthSystem.currentLives = PlayerHealthSystem.maxLives;
    }
}
