using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechSystemController : MonoBehaviour
{
    private bool P1NoLiveSpeech;
    private bool P2NoLiveSpeech;

    public GameObject P1Panel;
    public Image P1character1;
    public Image P1character2;
    public Image P1character3;
    public Image P1character4;

    public GameObject P2Panel;
    public Image P2character1;
    public Image P2character2;
    public Image P2character3;
    public Image P2character4;

    public GameObject P1speech;
    public Text P1text;

    public GameObject P2speech;
    public Text P2text;

    private GameObject player1CurrentCharacter;
    private GameObject player2CurrentCharacter;

    private void Awake()
    {
        DeactivateP1Characters();
        DeactivateP2Characters();

        DeactivateP1Speech();
        DeactivateP2Speech();
    }

    private void Start()
    {
        if (MainMenuController.onePlayer)
        {
            StartCoroutine(StartingSpeech1P());
        }
        else
        {
            StartCoroutine(StartingSpeech2P());
        }
    }

    private void Update()
    {
        if(HealthSystem.P1ramEnemy == 3)
        {
            StartCoroutine(P1RamEnemy());
        }
        if (HealthSystem.P2ramEnemy == 3)
        {
            StartCoroutine(P2RamEnemy());
        }

        if (HealthSystem.P1lightEnemy == 3)
        {
            StartCoroutine(P1LightEnemy());
        }
        if (HealthSystem.P2lightEnemy == 3)
        {
            StartCoroutine(P2LightEnemy());
        }

        if (HealthSystem.P1missileEnemy == 1)
        {
            StartCoroutine(P1MissileEnemy());
        }
        if (HealthSystem.P2missileEnemy == 1)
        {
            StartCoroutine(P2MissileEnemy());
        }

        if (PlayerHealthSystem.P1currentLives < 0 && P1NoLiveSpeech)
        {
            StartCoroutine(P1NoLive());
        }
        if (PlayerHealthSystem.P2currentLives < 0 && P2NoLiveSpeech)
        {
            StartCoroutine(P2NoLive());
        }
    }

    IEnumerator StartingSpeech1P()
    {
        SetPlayer1Character();

        ActivateP1Speech();
        P1text.text = "Let's go";

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Speech();
    }
    IEnumerator StartingSpeech2P()
    {
        SetPlayer1Character();
        SetPlayer2Character();

        ActivateP1Speech();
        P1text.text = "Let's go";

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Speech();
        ActivateP2Speech();
        P2text.text = "Okay";

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Speech();
    }

    IEnumerator P1RamEnemy()
    {
        ActivateP1Speech();
        P1text.text = "Congratulation you killed " + HealthSystem.P1ramEnemy + " Rammer";

        yield return new WaitForSeconds(1.5f);

        HealthSystem.P1ramEnemy = 0;
        DeactivateP1Speech();
    }
    IEnumerator P2RamEnemy()
    {
        ActivateP2Speech();
        P2text.text = "Congratulation you killed " + HealthSystem.P2ramEnemy + " Rammer";

        yield return new WaitForSeconds(1.5f);

        HealthSystem.P2ramEnemy = 0;
        DeactivateP2Speech();
    }

    IEnumerator P1LightEnemy()
    {
        ActivateP1Speech();
        P1text.text = "Congratulation you killed " + HealthSystem.P1ramEnemy + " Light Ships";

        yield return new WaitForSeconds(1.5f);

        HealthSystem.P1lightEnemy = 0;
        DeactivateP1Speech();
    }
    IEnumerator P2LightEnemy()
    {
        ActivateP2Speech();
        P2text.text = "Congratulation you kill " + HealthSystem.P2ramEnemy + " Missile Ship";

        yield return new WaitForSeconds(1.5f);

        HealthSystem.P2lightEnemy = 0;
        DeactivateP2Speech();
    }

    IEnumerator P1MissileEnemy()
    {
        ActivateP1Speech();
        P1text.text = "Congratulation you killed " + HealthSystem.P1ramEnemy + " Missile Ship";

        yield return new WaitForSeconds(1.5f);

        HealthSystem.P1missileEnemy = 0;
        DeactivateP1Speech();
    }
    IEnumerator P2MissileEnemy()
    {
        ActivateP2Speech();
        P2text.text = "Congratulation you killed " + HealthSystem.P2ramEnemy + "Rammer";

        yield return new WaitForSeconds(1.5f);

        HealthSystem.P2missileEnemy = 0;
        DeactivateP2Speech();
    }

    IEnumerator P1NoLive()
    {
        ActivateP1Speech();
        P1text.text = "Why can't i revive";

        yield return new WaitForSeconds(1.5f);
        
        DeactivateP1Speech();
        P1NoLiveSpeech = true;
    }
    IEnumerator P2NoLive()
    {
        ActivateP2Speech();
        P2text.text = "Why can't i revive";

        yield return new WaitForSeconds(1.5f);
        
        DeactivateP2Speech();
        P2NoLiveSpeech = true;
    }

    private void ActivateP1Speech()
    {
        P1Panel.SetActive(true);

        P1speech.SetActive(true);
        P1text.enabled = true;
    }
    private void DeactivateP1Speech()
    {
        P1Panel.SetActive(false);

        P1speech.SetActive(false);
        P1text.enabled = false;
    }

    private void ActivateP2Speech()
    {
        P2Panel.SetActive(true);

        P2speech.SetActive(true);
        P2text.enabled = true;
    }
    private void DeactivateP2Speech()
    {
        P2Panel.SetActive(false);

        P2speech.SetActive(false);
        P2text.enabled = false;
    }

    private void SetBool()
    {
        P1NoLiveSpeech = false;
        P2NoLiveSpeech = false;
    }

    private void DeactivateP1Characters()
    {
        P1character1.fillAmount = 0;
        P1character2.fillAmount = 0;
        P1character3.fillAmount = 0;
        P1character4.fillAmount = 0;
    }
    private void DeactivateP2Characters()
    {
        P2character1.fillAmount = 0;
        P2character2.fillAmount = 0;
        P2character3.fillAmount = 0;
        P2character4.fillAmount = 0;
    }

    private void SetPlayer1Character()
    {
        if(SelectionMenuController.P1characterType == 1)
        {
            P1character1.fillAmount = 1;
        }
        if (SelectionMenuController.P1characterType == 2)
        {
            P1character2.fillAmount = 1;
        }
        if (SelectionMenuController.P1characterType == 3)
        {
            P1character3.fillAmount = 1;
        }
        if (SelectionMenuController.P1characterType == 4)
        {
            P1character4.fillAmount = 1;
        }
    }
    private void SetPlayer2Character()
    {
        if (SelectionMenuController.P2characterType == 1)
        {
            P2character1.fillAmount = 1;
        }
        if (SelectionMenuController.P2characterType == 2)
        {
            P2character2.fillAmount = 1;
        }
        if (SelectionMenuController.P2characterType == 3)
        {
            P2character3.fillAmount = 1;
        }
        if (SelectionMenuController.P2characterType == 4)
        {
            P2character4.fillAmount = 1;
        }
    }
}
