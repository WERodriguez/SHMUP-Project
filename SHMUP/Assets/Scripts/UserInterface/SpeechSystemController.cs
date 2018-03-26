using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechSystemController : MonoBehaviour
{
    private bool P1NoLiveSpeech;
    private bool P2NoLiveSpeech;
    private bool P1HalfHealthSpeech;
    private bool P2HalfHealthSpeech;

    public GameObject P1Panel;
    public GameObject P2Panel;

    public Image P1sprite1;
    public Image P1sprite2;
    public Image P1sprite3;
    public Image P1sprite4;
    public Image P1sprite5;

    public Image P2sprite1;
    public Image P2sprite2;
    public Image P2sprite3;
    public Image P2sprite4;
    public Image P2sprite5;

    public Sprite character1sprite1;
    public Sprite character1sprite2;
    public Sprite character1sprite3;
    public Sprite character1sprite4;
    public Sprite character1sprite5;

    public Sprite character2sprite1;
    public Sprite character2sprite2;
    public Sprite character2sprite3;
    public Sprite character2sprite4;
    public Sprite character2sprite5;

    public Sprite character3sprite1;
    public Sprite character3sprite2;
    public Sprite character3sprite3;
    public Sprite character3sprite4;
    public Sprite character3sprite5;

    public Sprite character4sprite1;
    public Sprite character4sprite2;
    public Sprite character4sprite3;
    public Sprite character4sprite4;
    public Sprite character4sprite5;

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
        if(MainMenuController.onePlayer)
        {
            //enemy
            if (HealthSystem.P1ramEnemy == 3)
            {
                StartCoroutine(P1RamEnemy());
            }

            if (HealthSystem.P1lightEnemy == 3)
            {
                StartCoroutine(P1LightEnemy());
            }

            if (HealthSystem.P1missileEnemy == 1)
            {
                StartCoroutine(P1MissileEnemy());
            }

            if (HealthSystem.P1destroyerEnemy == 1)
            {
                StartCoroutine(P1DestroyerEnemy());
            }

            if (HealthSystem.P1bossKill)
            {
                StartCoroutine(P1BossKill());
            }

            //health pickup
            if (PlayerHealthSystem.P1lessLive)
            {
                StartCoroutine(P1LessLive());
            }

            if (PlayerHealthSystem.P1currentLives < 0 && !P1NoLiveSpeech)
            {
                StartCoroutine(P1Death());
            }

            if (PlayerHealthSystem.P1currentHealth <= (PlayerHealthSystem.P1maxHealth / 2) && !P1HalfHealthSpeech)
            {
                StartCoroutine(P1HalfHealth());
            }

            if (PlayerHealthSystem.P1moreHealth)
            {
                StartCoroutine(P1MoreHealth());
            }

            if (PlayerHealthSystem.P1moreShield)
            {
                StartCoroutine(P1MoreShield());
            }

            if (PlayerHealthSystem.P1moreLive)
            {
                StartCoroutine(P1MoreLive());
            }

            //weapon pickup
            if (PlayerWeaponController.P1morePrimary)
            {
                StartCoroutine(P1MorePrimary());
            }

            if (PlayerWeaponController.P1moreSecondary)
            {
                StartCoroutine(P1MoreSecondary());
            }

            if (PlayerWeaponController.P1moreAmmo)
            {
                StartCoroutine(P1MoreAmmo());
            }
        }
        else
        {
            //enemy
            if (HealthSystem.P1ramEnemy == 3)
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

            if (HealthSystem.P1destroyerEnemy == 1)
            {
                StartCoroutine(P1DestroyerEnemy());
            }
            if (HealthSystem.P2destroyerEnemy == 1)
            {
                StartCoroutine(P2DestroyerEnemy());
            }

            if (HealthSystem.P1bossKill)
            {
                StartCoroutine(P1BossKill());
            }
            if (HealthSystem.P2bossKill)
            {
                StartCoroutine(P2BossKill());
            }

            //health pickup
            if (PlayerHealthSystem.P1lessLive)
            {
                StartCoroutine(P1LessLive());
            }
            if (PlayerHealthSystem.P2lessLive)
            {
                StartCoroutine(P2LessLive());
            }

            if (PlayerHealthSystem.P1currentLives < 0 && !P1NoLiveSpeech)
            {
                StartCoroutine(P1Death());
            }
            if (PlayerHealthSystem.P2currentLives < 0 && !P2NoLiveSpeech)
            {
                StartCoroutine(P2Death());
            }

            if (PlayerHealthSystem.P1currentHealth <= (PlayerHealthSystem.P1maxHealth / 2) && !P1HalfHealthSpeech)
            {
                StartCoroutine(P1HalfHealth());
            }
            if (PlayerHealthSystem.P2currentHealth <= (PlayerHealthSystem.P2maxHealth / 2) && !P2HalfHealthSpeech)
            {
                StartCoroutine(P2HalfHealth());
            }

            if (PlayerHealthSystem.P1moreHealth)
            {
                StartCoroutine(P1MoreHealth());
            }
            if (PlayerHealthSystem.P2moreHealth)
            {
                StartCoroutine(P2MoreHealth());
            }

            if (PlayerHealthSystem.P1moreShield)
            {
                StartCoroutine(P1MoreShield());
            }
            if (PlayerHealthSystem.P2moreShield)
            {
                StartCoroutine(P2MoreShield());
            }

            if (PlayerHealthSystem.P1moreLive)
            {
                StartCoroutine(P1MoreLive());
            }
            if (PlayerHealthSystem.P2moreLive)
            {
                StartCoroutine(P2MoreLive());
            }

            //weapon pickup
            if (PlayerWeaponController.P1morePrimary)
            {
                StartCoroutine(P1MorePrimary());
            }
            if (PlayerWeaponController.P2morePrimary)
            {
                StartCoroutine(P2MorePrimary());
            }

            if (PlayerWeaponController.P1moreSecondary)
            {
                StartCoroutine(P1MoreSecondary());
            }
            if (PlayerWeaponController.P2moreSecondary)
            {
                StartCoroutine(P2MoreSecondary());
            }

            if (PlayerWeaponController.P1moreAmmo)
            {
                StartCoroutine(P1MoreAmmo());
            }
            if (PlayerWeaponController.P2moreAmmo)
            {
                StartCoroutine(P2MoreAmmo());
            }
        }
    }

    IEnumerator StartingSpeech1P()
    {
        SetPlayer1Character();

        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite1.fillAmount = 1;
        P1text.text = "Let's go";

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator StartingSpeech2P()
    {
        SetPlayer1Character();
        SetPlayer2Character();

        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite1.fillAmount = 1;
        P1text.text = "Let's go";

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite1.fillAmount = 1;
        P2text.text = "Okay";

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1RamEnemy()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite1.fillAmount = 1;
        P1text.text = "Congratulation you killed " + HealthSystem.P1ramEnemy + " Rammer";

        HealthSystem.P1ramEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2RamEnemy()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite1.fillAmount = 1;
        P2text.text = "Congratulation you killed " + HealthSystem.P2ramEnemy + " Rammer";

        HealthSystem.P2ramEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1LightEnemy()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite1.fillAmount = 1;
        P1text.text = "Congratulation you killed " + HealthSystem.P1lightEnemy + " Light Ships";

        HealthSystem.P1lightEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2LightEnemy()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite1.fillAmount = 1;
        P2text.text = "Congratulation you kill " + HealthSystem.P2lightEnemy + " Light Ships";

        HealthSystem.P2lightEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1MissileEnemy()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite1.fillAmount = 1;
        P1text.text = "Congratulation you killed " + HealthSystem.P1missileEnemy + " Missile Ship";

        HealthSystem.P1missileEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2MissileEnemy()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite1.fillAmount = 1;
        P2text.text = "Congratulation you killed " + HealthSystem.P2missileEnemy + " Missile Ship";

        HealthSystem.P2missileEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1DestroyerEnemy()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite1.fillAmount = 1;
        P1text.text = "Congratulation you killed " + HealthSystem.P1destroyerEnemy + " Destroyer";

        HealthSystem.P1destroyerEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2DestroyerEnemy()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite1.fillAmount = 1;
        P2text.text = "Congratulation you killed " + HealthSystem.P2destroyerEnemy + " Destroyer";

        HealthSystem.P2destroyerEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1BossKill()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite3.fillAmount = 1;
        P1text.text = "Congratulation you killed the Boss";

        HealthSystem.P1bossKill = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2BossKill()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite3.fillAmount = 1;
        P2text.text = "Congratulation you kill the Boss";

        HealthSystem.P2bossKill = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1LessLive()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite2.fillAmount = 1;
        P1text.text = "Reviving";

        PlayerHealthSystem.P1lessLive = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2LessLive()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite2.fillAmount = 1;
        P2text.text = "Reviving";

        PlayerHealthSystem.P2lessLive = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1Death()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite2.fillAmount = 1;
        P1text.text = "What do you mean i ran out of live";

        yield return new WaitForSeconds(1.5f);

        P1NoLiveSpeech = true;

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2Death()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite2.fillAmount = 1;
        P2text.text = "What do you mean i ran out of live";

        yield return new WaitForSeconds(1.5f);

        P2NoLiveSpeech = true;

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1HalfHealth()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite4.fillAmount = 1;
        P1text.text = "Medic";

        yield return new WaitForSeconds(1.5f);

        P1HalfHealthSpeech = true;

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2HalfHealth()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite4.fillAmount = 1;
        P2text.text = "Medic";

        yield return new WaitForSeconds(1.5f);

        P2HalfHealthSpeech = true;

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1MoreHealth()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite5.fillAmount = 1;

        if(PlayerHealthSystem.P1currentHealth >= PlayerHealthSystem.P1maxHealth)
        {
            P1text.text = "You already have max health";
        }
        else
        {
            P1text.text = "Healing";
        }

        PlayerHealthSystem.P1moreHealth = false;

        yield return new WaitForSeconds(1.5f);

        P1HalfHealthSpeech = false;

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2MoreHealth()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite5.fillAmount = 1;

        if (PlayerHealthSystem.P2currentHealth >= PlayerHealthSystem.P2maxHealth)
        {
            P2text.text = "You already have max health";
        }
        else
        {
            P2text.text = "Healing";
        }

        PlayerHealthSystem.P2moreHealth = false;

        yield return new WaitForSeconds(1.5f);

        P2HalfHealthSpeech = false;

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1MoreShield()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite5.fillAmount = 1;

        if (PlayerHealthSystem.P1currentShields >= PlayerHealthSystem.P1maxShields)
        {
            P1text.text = "You already have max shield";
        }
        else
        {
            P1text.text = "Charging Shield";
        }

        PlayerHealthSystem.P1moreShield = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2MoreShield()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite5.fillAmount = 1;

        if (PlayerHealthSystem.P2currentShields >= PlayerHealthSystem.P2maxShields)
        {
            P2text.text = "You already have max shield";
        }
        else
        {
            P2text.text = "Charging Shield";
        }

        PlayerHealthSystem.P2moreShield = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1MoreLive()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite5.fillAmount = 1;

        if (PlayerHealthSystem.P1currentLives >= 5)
        {
            P1text.text = "You already have max lives";
        }
        else
        {
            P1text.text = "Extra Live";
        }

        PlayerHealthSystem.P1moreLive = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2MoreLive()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite5.fillAmount = 1;

        if (PlayerHealthSystem.P2currentLives >= 5)
        {
            P2text.text = "You already have max lives";
        }
        else
        {
            P2text.text = "Extra Live";
        }

        PlayerHealthSystem.P2moreLive = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1MorePrimary()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite5.fillAmount = 1;

        if (PlayerWeaponController.P1currentWLevel >= 5)
        {
            P1text.text = "You primary is at max level";
        }
        else
        {
            P1text.text = "Stronger Primary";
        }

        PlayerWeaponController.P1morePrimary = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2MorePrimary()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite5.fillAmount = 1;

        if (PlayerWeaponController.P2currentWLevel >= 5)
        {
            P2text.text = "You primary is at max level";
        }
        else
        {
            P2text.text = "Stronger Primary";
        }

        PlayerWeaponController.P2morePrimary = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1MoreSecondary()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite5.fillAmount = 1;

        if (PlayerWeaponController.P1currentSecondaryLevel >= 5)
        {
            P1text.text = "You secondary is at max level";
        }
        else
        {
            P1text.text = "Stronger Secondary";
        }

        PlayerWeaponController.P1moreSecondary = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2MoreSecondary()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite5.fillAmount = 1;

        if (PlayerWeaponController.P2currentSecondaryLevel >= 5)
        {
            P2text.text = "You secondary is at max level";
        }
        else
        {
            P2text.text = "Stronger Secondary";
        }

        PlayerWeaponController.P2moreSecondary = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
    }

    IEnumerator P1MoreAmmo()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1sprite5.fillAmount = 1;

        if (PlayerWeaponController.P1superAmmo >= 5)
        {
            P1text.text = "5 is the max number of supper ammo your ship can hold";
        }
        else
        {
            P1text.text = "Extra Ammo";
        }

        PlayerWeaponController.P1moreAmmo = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();
    }
    IEnumerator P2MoreAmmo()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite5.fillAmount = 1;

        if (PlayerWeaponController.P2superAmmo >= 5)
        {
            P2text.text = "5 is the max number of supper ammo your ship can hold";
        }
        else
        {
            P2text.text = "Extra Ammo";
        }

        PlayerWeaponController.P2moreAmmo = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();
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
        P1HalfHealthSpeech = false;
        P2HalfHealthSpeech = false;
    }

    private void DeactivateP1Characters()
    {
        P1sprite1.fillAmount = 0;
        P1sprite2.fillAmount = 0;
        P1sprite3.fillAmount = 0;
        P1sprite4.fillAmount = 0;
        P1sprite5.fillAmount = 0;
    }
    private void DeactivateP2Characters()
    {
        P2sprite1.fillAmount = 0;
        P2sprite2.fillAmount = 0;
        P2sprite3.fillAmount = 0;
        P2sprite4.fillAmount = 0;
        P2sprite5.fillAmount = 0;
    }

    private void SetPlayer1Character()
    {
        if(SelectionMenuController.P1characterType == 1)
        {
            P1sprite1.sprite = character1sprite1;
            P1sprite2.sprite = character1sprite2;
            P1sprite3.sprite = character1sprite3;
            P1sprite4.sprite = character1sprite4;
            P1sprite5.sprite = character1sprite5;
        }
        if (SelectionMenuController.P1characterType == 2)
        {
            P1sprite1.sprite = character2sprite1;
            P1sprite2.sprite = character2sprite2;
            P1sprite3.sprite = character2sprite3;
            P1sprite4.sprite = character2sprite4;
            P1sprite5.sprite = character2sprite5;
        }
        if (SelectionMenuController.P1characterType == 3)
        {
            P1sprite1.sprite = character3sprite1;
            P1sprite2.sprite = character3sprite2;
            P1sprite3.sprite = character3sprite3;
            P1sprite4.sprite = character3sprite4;
            P1sprite5.sprite = character3sprite5;
        }
        if (SelectionMenuController.P1characterType == 4)
        {
            P1sprite1.sprite = character4sprite1;
            P1sprite2.sprite = character4sprite2;
            P1sprite3.sprite = character4sprite3;
            P1sprite4.sprite = character4sprite4;
            P1sprite5.sprite = character4sprite5;
        }
    }
    private void SetPlayer2Character()
    {
        if (SelectionMenuController.P2characterType == 1)
        {
            P2sprite1.sprite = character1sprite1;
            P2sprite2.sprite = character1sprite2;
            P2sprite3.sprite = character1sprite3;
            P2sprite4.sprite = character1sprite4;
            P2sprite5.sprite = character1sprite5;
        }
        if (SelectionMenuController.P2characterType == 2)
        {
            P2sprite1.sprite = character2sprite1;
            P2sprite2.sprite = character2sprite2;
            P2sprite3.sprite = character2sprite3;
            P2sprite4.sprite = character2sprite4;
            P2sprite5.sprite = character2sprite5;
        }
        if (SelectionMenuController.P2characterType == 3)
        {
            P2sprite1.sprite = character3sprite1;
            P2sprite2.sprite = character3sprite2;
            P2sprite3.sprite = character3sprite3;
            P2sprite4.sprite = character3sprite4;
            P2sprite5.sprite = character3sprite5;
        }
        if (SelectionMenuController.P2characterType == 4)
        {
            P2sprite1.sprite = character4sprite1;
            P2sprite2.sprite = character4sprite2;
            P2sprite3.sprite = character4sprite3;
            P2sprite4.sprite = character4sprite4;
            P2sprite5.sprite = character4sprite5;
        }
    }
}
