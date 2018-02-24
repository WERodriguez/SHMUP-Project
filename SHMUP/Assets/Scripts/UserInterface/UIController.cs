using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
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

    public GameObject backButton;
    public GameObject startButton;
    public GameObject upButton1;
    public GameObject upButton2;
    public GameObject upButton3;
    public GameObject upButton4;
    public GameObject upButton5;

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

        backButton.SetActive(false);
        startButton.SetActive(false);
        upButton1.SetActive(false);
        upButton2.SetActive(false);
        upButton3.SetActive(false);
        upButton4.SetActive(false);
        upButton5.SetActive(false);

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
        singleMenu.SetActive(true);
        characterButton.SetActive(true);
        shipButton.SetActive(true);
        primaryButton.SetActive(true);
        secondaryButton.SetActive(true);
        specialButton.SetActive(true);

        backButton.SetActive(true);
        upButton1.SetActive(true);
        upButton2.SetActive(true);
        upButton3.SetActive(true);
        upButton4.SetActive(true);
        upButton5.SetActive(true);
    }

    //back button
    public void BBonClick()
    {
        singleMenu.SetActive(true);
        characterButton.SetActive(true);
        shipButton.SetActive(true);
        primaryButton.SetActive(true);
        secondaryButton.SetActive(true);
        specialButton.SetActive(true);

        backButton.SetActive(true);
        upButton1.SetActive(false);
        upButton2.SetActive(true);
        upButton3.SetActive(true);
        upButton4.SetActive(true);
        upButton5.SetActive(true);

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

    //up button
    public void UBonClick()
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
    public void BBCameraSwitch()
    {
        BBonClick();
        mainMenuPivot.SetBool("SingleClick", false);
        SingleSelectionPivot.SetBool("BackClick", false);
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
