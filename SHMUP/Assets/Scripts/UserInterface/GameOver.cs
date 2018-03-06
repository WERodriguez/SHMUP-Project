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

    public Animator canvasAnimation;

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

        canvasAnimation.SetBool("EnableCanvasAnimation", false);
    }

    /*
    private void NextAnimation()
    {
        lastingTime--;

        if(lastingTime > 0)
        {
            Invoke("NextAnimation", 1f);
        }
        else
        {
            canvasAnimation.SetBool("EnableCanvasAnimation", true);
        }
    }*/

    private void ResetPlayer1Value()
    {
        PlayerHealthSystem.P1currentLives = PlayerHealthSystem.P1maxLives;
        PlayerHealthSystem.P1currentHealth = PlayerHealthSystem.P1maxHealth;
        PlayerHealthSystem.P1currentShields = PlayerHealthSystem.P1maxShields;
    }
    private void ResetPlayer2Value()
    {
        PlayerHealthSystem.P2currentLives = PlayerHealthSystem.P2maxLives;
        PlayerHealthSystem.P2currentHealth = PlayerHealthSystem.P2maxHealth;
        PlayerHealthSystem.P2currentShields = PlayerHealthSystem.P2maxShields;
    }

    public void HangarButton()
    {
        canvasAnimation.SetBool("EnableCanvasAnimation", true);
        SceneManager.LoadScene("Hangar");
    }

    public void RestartButton()
    {
        if(UIController.onePlayer)
        {
            ResetPlayer1Value();
        }
        else
        {
            ResetPlayer1Value();
            ResetPlayer2Value();
        }

        canvasAnimation.SetBool("EnableCanvasAnimation", true);
        SceneManager.LoadScene("(Testing)TheRange");
    }
}
