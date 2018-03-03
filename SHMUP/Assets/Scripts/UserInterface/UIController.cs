using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static bool onePlayer;
    public static int characterType;
    public static int shipType;
    public static int primaryType;
    public static int secondaryType;
    public static int specialType;

    public Animator mainMenuPivot;
    public Animator SingleSelectionPivot;

    public GameObject mainMenu;
    public GameObject singlePlayer;
    public GameObject doublePlayer;
    public GameObject quitButton;

    public GameObject singleMenu;
    public GameObject characterButton;
    public GameObject shipButton;
    public GameObject primaryButton;
    public GameObject secondaryButton;
    public GameObject specialButton;

    public GameObject returnButton;
    public GameObject startButton;
    public GameObject backButton1;
    public GameObject backButton2;
    public GameObject backButton3;
    public GameObject backButton4;
    public GameObject backButton5;

    public GameObject characterPanel;
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;

    public GameObject shipPanel;
    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    public GameObject ship4;
    public GameObject ship5;
    public GameObject ship6;

    public GameObject primaryPanel;
    public GameObject primary1;
    public GameObject primary2;
    public GameObject primary3;

    public GameObject secondaryPanel;
    public GameObject secondary1;
    public GameObject secondary2;
    public GameObject secondary3;

    public GameObject specialPanel;
    public GameObject special1;
    public GameObject special2;
    public GameObject special3;

    private void Start()
    {
        onePlayer = true;
        characterType = 0;
        shipType = 0;
        primaryType = 0;
        secondaryType = 0;
        specialType = 0;

        mainMenu.SetActive(true);
        singlePlayer.SetActive(true);
        doublePlayer.SetActive(true);
        quitButton.SetActive(true);

        singleMenu.SetActive(false);
        characterButton.SetActive(false);
        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);

        returnButton.SetActive(false);
        startButton.SetActive(false);
        backButton1.SetActive(false);
        backButton2.SetActive(false);
        backButton3.SetActive(false);
        backButton4.SetActive(false);
        backButton5.SetActive(false);

        characterPanel.SetActive(false);
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
        character4.SetActive(false);

        shipPanel.SetActive(false);
        ship1.SetActive(false);
        ship2.SetActive(false);
        ship3.SetActive(false);
        ship4.SetActive(false);
        ship5.SetActive(false);
        ship6.SetActive(false);

        primaryPanel.SetActive(false);
        primary1.SetActive(false);
        primary2.SetActive(false);
        primary3.SetActive(false);

        secondaryPanel.SetActive(false);
        secondary1.SetActive(false);
        secondary2.SetActive(false);
        secondary3.SetActive(false);

        specialPanel.SetActive(false);
        special1.SetActive(false);
        special2.SetActive(false);
        special3.SetActive(false);
    }

    //single player button
    public void SPBonClick()
    {
        onePlayer = true;
        singleMenu.SetActive(true);
        characterButton.SetActive(true);
        shipButton.SetActive(true);
        primaryButton.SetActive(true);
        secondaryButton.SetActive(true);
        specialButton.SetActive(true);

        returnButton.SetActive(true);
        backButton1.SetActive(true);
        backButton2.SetActive(true);
        backButton3.SetActive(true);
        backButton4.SetActive(true);
        backButton5.SetActive(true);
    }

    //return button
    public void RBonClick()
    {
        onePlayer = false;
        singleMenu.SetActive(true);
        characterButton.SetActive(true);
        shipButton.SetActive(true);
        primaryButton.SetActive(true);
        secondaryButton.SetActive(true);
        specialButton.SetActive(true);

        returnButton.SetActive(true);
        backButton1.SetActive(false);
        backButton2.SetActive(true);
        backButton3.SetActive(true);
        backButton4.SetActive(true);
        backButton5.SetActive(true);

        characterPanel.SetActive(false);
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
        character4.SetActive(false);

        shipPanel.SetActive(false);
        ship1.SetActive(false);
        ship2.SetActive(false);
        ship3.SetActive(false);
        ship4.SetActive(false);
        ship5.SetActive(false);
        ship6.SetActive(false);

        primaryPanel.SetActive(false);
        primary1.SetActive(false);
        primary2.SetActive(false);
        primary3.SetActive(false);

        secondaryPanel.SetActive(false);
        secondary1.SetActive(false);
        secondary2.SetActive(false);
        secondary3.SetActive(false);

        specialPanel.SetActive(false);
        special1.SetActive(false);
        special2.SetActive(false);
        special3.SetActive(false);
    }

    //back button
    public void BBonClick()
    {
        characterButton.SetActive(true);
        shipButton.SetActive(true);
        primaryButton.SetActive(true);
        secondaryButton.SetActive(true);
        specialButton.SetActive(true);

        characterPanel.SetActive(false);
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
        character4.SetActive(false);

        shipPanel.SetActive(false);
        ship1.SetActive(false);
        ship2.SetActive(false);
        ship3.SetActive(false);
        ship4.SetActive(false);
        ship5.SetActive(false);
        ship6.SetActive(false);

        primaryPanel.SetActive(false);
        primary1.SetActive(false);
        primary2.SetActive(false);
        primary3.SetActive(false);

        secondaryPanel.SetActive(false);
        secondary1.SetActive(false);
        secondary2.SetActive(false);
        secondary3.SetActive(false);

        specialPanel.SetActive(false);
        special1.SetActive(false);
        special2.SetActive(false);
        special3.SetActive(false);
    }

    //character select
    public void CSonClick()
    {
        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);

        characterPanel.SetActive(true);
        character1.SetActive(true);
        character2.SetActive(true);
        character3.SetActive(true);
        character4.SetActive(true);
    }

    //ship select
    public void SSonClick()
    {
        characterButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);

        shipPanel.SetActive(true);
        ship1.SetActive(true);
        ship2.SetActive(true);
        ship3.SetActive(true);
        ship4.SetActive(true);
        ship5.SetActive(true);
        ship6.SetActive(true);
    }

    //primary button
    public void PBonClick()
    {
        characterButton.SetActive(false);
        shipButton.SetActive(false);
        secondaryButton.SetActive(false);
        specialButton.SetActive(false);

        primaryPanel.SetActive(true);
        primary1.SetActive(true);
        primary2.SetActive(true);
        primary3.SetActive(true);
    }

    //secondary button
    public void SBonClick()
    {
        characterButton.SetActive(false);
        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        specialButton.SetActive(false);

        secondaryPanel.SetActive(true);
        secondary1.SetActive(true);
        secondary2.SetActive(true);
        secondary3.SetActive(true);
    }

    //special button
    public void SPonClick()
    {
        characterButton.SetActive(false);
        shipButton.SetActive(false);
        primaryButton.SetActive(false);
        secondaryButton.SetActive(false);

        specialPanel.SetActive(true);
        special1.SetActive(true);
        special2.SetActive(true);
        special3.SetActive(true);
    }

    //single player button animation
    public void SPBCameraSwitch()
    {
        SPBonClick();
        mainMenuPivot.SetBool("SingleClick", true);
        SingleSelectionPivot.SetBool("BackClick", true);
    }

    //BB camera switch
    public void RBCameraSwitch()
    {
        BBonClick();
        mainMenuPivot.SetBool("SingleClick", false);
        SingleSelectionPivot.SetBool("BackClick", false);
    }

    //start taking in data and pass it to another scene

    //choose character 1
    public void C1onClick()
    {
        characterType = 1;
    }
    //choose character 2
    public void C2onClick()
    {
        characterType = 2;
    }
    //choose character 3
    public void C3onClick()
    {
        characterType = 3;
    }
    //choose character 4
    public void C4onClick()
    {
        characterType = 4;
    }

    //choose ship 1
    public void S1onClick()
    {
        shipType = 1;
    }
    //choose ship 1
    public void S2onClick()
    {
        shipType = 2;
    }
    //choose ship 3
    public void S3onClick()
    {
        shipType = 3;
    }
    //choose ship 4
    public void S4onClick()
    {
        shipType = 4;
    }
    //choose ship 5
    public void S5onClick()
    {
        shipType = 5;
    }
    //choose ship 6
    public void S6onClick()
    {
        shipType = 6;
    }

    //choose primary 1
    public void PW1onClick()
    {
        primaryType = 1;
    }
    //choose primary 2
    public void PW2onClick()
    {
        primaryType = 2;
    }
    //choose primary 3
    public void PW3onClick()
    {
        primaryType = 3;
    }

    //choose secondary 1
    public void SW1onClick()
    {
        secondaryType = 1;
    }
    //choose secondary 2
    public void SW2onClick()
    {
        secondaryType = 2;
    }
    //choose secondary 3
    public void SW3onClick()
    {
        secondaryType = 3;
    }

    //choose Special 1
    public void SP1onClick()
    {
        specialType = 1;
    }
    //choose Special 2
    public void SP2onClick()
    {
        specialType = 2;
    }
    //choose Special 3
    public void SP3onClick()
    {
        specialType = 3;
    }

    private void Update()
    {
        if(characterType > 0 && shipType > 0 && primaryType > 0 && secondaryType > 0 && specialType > 0)
        {
            startButton.SetActive(true);
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene("(Testing)TheRange");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
