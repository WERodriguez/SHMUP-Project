using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    public GameObject mainMenuButton;

    private AudioClip[] soundEffect;
    private AudioSource[] buttonSoundEffect;

    private bool waiting;

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

        if(!waiting)
        {
            if(Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0) || FlexToggle.myFlexBool == true)
            {
                SelectingSound();

                MainMenuButton();
            }
        }
    }

    private void ResetPlayer1Value()
    {
        PlayerHealthSystem.P1currentHealth = 0;
        PlayerHealthSystem.P1currentShields = 0;
        PlayerHealthSystem.P1currentLives = 0;

        PlayerWeaponController.P1savedWeaponLevel = 0;
        PlayerWeaponController.P1savedSecondaryLevel = 0;
        PlayerWeaponController.P1savedSuperAmmo = 0;
    }
    private void ResetPlayer2Value()
    {
        PlayerHealthSystem.P2currentHealth = 0;
        PlayerHealthSystem.P2currentShields = 0;
        PlayerHealthSystem.P2currentLives = 0;

        PlayerWeaponController.P2savedWeaponLevel = 0;
        PlayerWeaponController.P2savedSecondaryLevel = 0;
        PlayerWeaponController.P2savedSuperAmmo = 0;
    }
    private void ResetType()
    {
        SelectionMenuController.P1characterType = 0;
        SelectionMenuController.P1shipType = 0;
        SelectionMenuController.P1primaryType = 0;
        SelectionMenuController.P1secondaryType = 0;
        SelectionMenuController.P1specialType = 0;

        SelectionMenuController.P2characterType = 0;
        SelectionMenuController.P2shipType = 0;
        SelectionMenuController.P2primaryType = 0;
        SelectionMenuController.P2secondaryType = 0;
        SelectionMenuController.P2specialType = 0;
    }

    IEnumerator Timer()
    {
        buttonSoundEffect = GetComponents<AudioSource>();
        soundEffect = new AudioClip[]
        {
            (AudioClip)Resources.Load("Music/MenuSound/SelectingSound")
        };

        waiting = true;

        mainMenuButton.SetActive(false);

        yield return new WaitForSeconds(21f);

        mainMenuButton.SetActive(true);

        waiting = false;
    }

    private void MainMenuButton()
    {
        MainMenuController.currentStage = 1;

        ResetPlayer1Value();
        ResetPlayer2Value();
        ResetType();

        Destroy(GameObject.Find("MenuMusicController"));
        Destroy(GameObject.Find("HangarMusicController"));

        SceneManager.LoadScene("MainMenu");
    }

    private void SelectingSound()
    {
        buttonSoundEffect[0].Stop();
        buttonSoundEffect[0].clip = soundEffect[0];
        buttonSoundEffect[0].Play();
    }
}
