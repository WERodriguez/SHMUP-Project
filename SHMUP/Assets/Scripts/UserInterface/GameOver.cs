using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject hangarButton;
    public GameObject restartButton;

    public GameObject onePlayerScreen;
    public GameObject twoPlayersScreen;

    private void Start()
    {
        hangarButton.SetActive(true);
        restartButton.SetActive(true);

        if (UIController.onePlayer)
        {
            onePlayerScreen.SetActive(true);
            twoPlayersScreen.SetActive(false);
        }
        else
        {
            onePlayerScreen.SetActive(false);
            twoPlayersScreen.SetActive(true);
        }
    }

    private void ResetValue()
    {
        /*
        PlayerHealthSystem.currentLives = PlayerHealthSystem.maxLives;
        PlayerHealthSystem.currentHealth = PlayerHealthSystem.maxHealth;
        PlayerHealthSystem.currentShields = PlayerHealthSystem.maxShields;
        */
    }

    public void HangarButton()
    {
        SceneManager.LoadScene("Hangar");
    }

    public void RestartButton()
    {
        ResetValue();
        SceneManager.LoadScene("(Testing)TheRange");
    }
}
