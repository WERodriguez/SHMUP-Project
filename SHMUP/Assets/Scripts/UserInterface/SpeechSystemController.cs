using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechSystemController : MonoBehaviour
{
    private bool waitingSpeech;
    private float randomSpeech;
    private bool P1speaking;
    private bool P2speaking;

    private bool P1NoLiveSpeech;
    private bool P2NoLiveSpeech;
    private bool P1HalfHealthSpeech;
    private bool P2HalfHealthSpeech;

    public GameObject P1Panel;
    public GameObject P2Panel;

    public GameObject P1speech;
    public GameObject P2speech;

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

    public Text P1text;
    public Text P2text;

    private void Awake()
    {
        DeactivateP1Characters();
        DeactivateP2Characters();

        DeactivateP1Speech();
        DeactivateP2Speech();

        waitingSpeech = false;
        P1speaking = false;
        P2speaking = false;
    }

    private void Start()
    {
        if(MainMenuController.onePlayer)
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
        if(HUDcontroller.changePlayer2Sprite)
        {
            StartCoroutine(Player2SpriteChange());
        }
        if (waitingSpeech)
        {
            if (MainMenuController.onePlayer)
            {
                if (!P1speaking)
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
            }
            else
            {
                if (!P1speaking)
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

                if (!P2speaking)
                {
                    //enemy
                    if (HealthSystem.P2ramEnemy == 3)
                    {
                        StartCoroutine(P2RamEnemy());
                    }
                    if (HealthSystem.P2lightEnemy == 3)
                    {
                        StartCoroutine(P2LightEnemy());
                    }
                    if (HealthSystem.P2missileEnemy == 1)
                    {
                        StartCoroutine(P2MissileEnemy());
                    }
                    if (HealthSystem.P2destroyerEnemy == 1)
                    {
                        StartCoroutine(P2DestroyerEnemy());
                    }
                    if (HealthSystem.P2bossKill)
                    {
                        StartCoroutine(P2BossKill());
                    }

                    //health pickup
                    if (PlayerHealthSystem.P2lessLive)
                    {
                        StartCoroutine(P2LessLive());
                    }
                    if (PlayerHealthSystem.P2currentLives < 0 && !P2NoLiveSpeech)
                    {
                        StartCoroutine(P2Death());
                    }
                    if (PlayerHealthSystem.P2currentHealth <= (PlayerHealthSystem.P2maxHealth / 2) && !P2HalfHealthSpeech)
                    {
                        StartCoroutine(P2HalfHealth());
                    }
                    if (PlayerHealthSystem.P2moreHealth)
                    {
                        StartCoroutine(P2MoreHealth());
                    }
                    if (PlayerHealthSystem.P2moreShield)
                    {
                        StartCoroutine(P2MoreShield());
                    }
                    if (PlayerHealthSystem.P2moreLive)
                    {
                        StartCoroutine(P2MoreLive());
                    }

                    //weapon pickup
                    if (PlayerWeaponController.P2morePrimary)
                    {
                        StartCoroutine(P2MorePrimary());
                    }
                    if (PlayerWeaponController.P2moreSecondary)
                    {
                        StartCoroutine(P2MoreSecondary());
                    }
                    if (PlayerWeaponController.P2moreAmmo)
                    {
                        StartCoroutine(P2MoreAmmo());
                    }
                }
            }
        }
    }

    IEnumerator StartingSpeech1P()
    {
        SetPlayer1Character();

        DeactivateP1Characters();
        ActivateP1Speech();
        
        P1sprite1.fillAmount = 1;

        randomSpeech = Random.Range(0, 90);

        if (SelectionMenuController.P1characterType == 1)
        {
            if (randomSpeech <= 30)
            {
                P1text.text = "Let’s dance!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P1text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P1text.text = "Try to keep up!";
            }
        }
        if (SelectionMenuController.P1characterType == 2)
        {
            if (randomSpeech <= 30)
            {
                P1text.text = "Let’s dance!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P1text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P1text.text = "Try to keep up!";
            }
        }
        if (SelectionMenuController.P1characterType == 3)
        {
            if (randomSpeech <= 30)
            {
                P1text.text = "Let’s rock!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P1text.text = "Yeah!";
            }
            if (randomSpeech > 60)
            {
                P1text.text = "I’ll show you toasters how it’s done!";
            }
        }
        if (SelectionMenuController.P1characterType == 4)
        {
            if (randomSpeech <= 30)
            {
                P1text.text = "Let’s rock!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P1text.text = "Yeah!";
            }
            if (randomSpeech > 60)
            {
                P1text.text = "I’ll show you toasters how it’s done!";
            }
        }

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        waitingSpeech = true;
    }
    IEnumerator StartingSpeech2P()
    {
        SetPlayer1Character();
        SetPlayer2Character();

        DeactivateP1Characters();
        ActivateP1Speech();
        
        P1sprite1.fillAmount = 1;

        randomSpeech = Random.Range(0, 90);

        if (SelectionMenuController.P1characterType == 1)
        {
            if (randomSpeech <= 30)
            {
                P1text.text = "Let’s dance!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P1text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P1text.text = "Try to keep up!";
            }
        }
        if (SelectionMenuController.P1characterType == 2)
        {
            if (randomSpeech <= 30)
            {
                P1text.text = "Let’s dance!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P1text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P1text.text = "Try to keep up!";
            }
        }
        if (SelectionMenuController.P1characterType == 3)
        {
            if (randomSpeech <= 30)
            {
                P1text.text = "Let’s rock!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P1text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P1text.text = "I’ll show you toasters how it’s done!";
            }
        }
        if (SelectionMenuController.P1characterType == 4)
        {
            if (randomSpeech <= 30)
            {
                P1text.text = "Let’s rock!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P1text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P1text.text = "I’ll show you toasters how it’s done!";
            }
        }

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        DeactivateP2Characters();
        ActivateP2Speech();

        P2sprite1.fillAmount = 1;

        randomSpeech = Random.Range(0, 90);

        if (SelectionMenuController.P2characterType == 1)
        {
            if (randomSpeech <= 30)
            {
                P2text.text = "Let’s dance!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P2text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P2text.text = "Try to keep up!";
            }
        }
        if (SelectionMenuController.P2characterType == 2)
        {
            if (randomSpeech <= 30)
            {
                P2text.text = "Let’s dance!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P2text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P2text.text = "Try to keep up!";
            }
        }
        if (SelectionMenuController.P2characterType == 3)
        {
            if (randomSpeech <= 30)
            {
                P2text.text = "Let’s rock!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P2text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P2text.text = "I’ll show you toasters how it’s done!";
            }
        }
        if (SelectionMenuController.P2characterType == 4)
        {
            if (randomSpeech <= 30)
            {
                P2text.text = "Let’s rock!";
            }
            if (randomSpeech > 30 && randomSpeech <= 60)
            {
                P2text.text = "Oh yeah!";
            }
            if (randomSpeech > 60)
            {
                P2text.text = "I’ll show you toasters how it’s done!";
            }
        }

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        waitingSpeech = true;
    }

    IEnumerator Player2SpriteChange()
    {
        SetPlayer2Character();

        yield return new WaitForSeconds(.25f);
    }

    IEnumerator P1RamEnemy()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite1.fillAmount = 1;

        P1Lines();

        HealthSystem.P1ramEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2RamEnemy()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite1.fillAmount = 1;

        P2Lines();

        HealthSystem.P2ramEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1LightEnemy()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite1.fillAmount = 1;

        P1Lines();

        HealthSystem.P1lightEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2LightEnemy()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite1.fillAmount = 1;

        P2Lines();

        HealthSystem.P2lightEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1MissileEnemy()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite1.fillAmount = 1;

        P1Lines();

        HealthSystem.P1missileEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2MissileEnemy()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite1.fillAmount = 1;

        P2Lines();

        HealthSystem.P2missileEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1DestroyerEnemy()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite1.fillAmount = 1;

        P1Lines();

        HealthSystem.P1destroyerEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2DestroyerEnemy()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite1.fillAmount = 1;

        P2Lines();

        HealthSystem.P2destroyerEnemy = 0;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1BossKill()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite3.fillAmount = 1;

        P1Lines();

        HealthSystem.P1bossKill = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2BossKill()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite3.fillAmount = 1;

        P2Lines();

        HealthSystem.P2bossKill = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1LessLive()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite2.fillAmount = 1;

        P1Lines();

        PlayerHealthSystem.P1lessLive = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2LessLive()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite2.fillAmount = 1;

        P2Lines();

        PlayerHealthSystem.P2lessLive = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1Death()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite2.fillAmount = 1;

        P1Lines();

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1NoLiveSpeech = true;
        P1speaking = false;
    }
    IEnumerator P2Death()
    {
        DeactivateP2Characters();
        ActivateP2Speech();
        
        P2speaking = true;
        P2sprite2.fillAmount = 1;

        P2Lines();

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2NoLiveSpeech = true;
        P2speaking = false;
    }

    IEnumerator P1HalfHealth()
    {
        DeactivateP1Characters();
        ActivateP1Speech();


        P1speaking = true;
        P1sprite4.fillAmount = 1;

        P1Lines();

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1HalfHealthSpeech = true;
        P1speaking = false;
    }
    IEnumerator P2HalfHealth()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite4.fillAmount = 1;

        P2Lines();

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2HalfHealthSpeech = true;
        P2speaking = false;
    }

    IEnumerator P1MoreHealth()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite5.fillAmount = 1;

        P1Lines();

        PlayerHealthSystem.P1moreHealth = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1HalfHealthSpeech = false;
        P1speaking = false;
    }
    IEnumerator P2MoreHealth()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite5.fillAmount = 1;

        P2Lines();

        PlayerHealthSystem.P2moreHealth = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2HalfHealthSpeech = false;
        P2speaking = false;
    }

    IEnumerator P1MoreShield()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite5.fillAmount = 1;

        P1Lines();

        PlayerHealthSystem.P1moreShield = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2MoreShield()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite5.fillAmount = 1;

        P2Lines();

        PlayerHealthSystem.P2moreShield = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1MoreLive()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite5.fillAmount = 1;

        P1Lines();

        PlayerHealthSystem.P1moreLive = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2MoreLive()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite5.fillAmount = 1;

        P2Lines();

        PlayerHealthSystem.P2moreLive = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1MorePrimary()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite5.fillAmount = 1;

        P1Lines();

        PlayerWeaponController.P1morePrimary = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2MorePrimary()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite5.fillAmount = 1;

        P2Lines();

        PlayerWeaponController.P2morePrimary = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1MoreSecondary()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite5.fillAmount = 1;

        P1Lines();

        PlayerWeaponController.P1moreSecondary = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2MoreSecondary()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite5.fillAmount = 1;

        P2Lines();

        PlayerWeaponController.P2moreSecondary = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
    }

    IEnumerator P1MoreAmmo()
    {
        DeactivateP1Characters();
        ActivateP1Speech();

        P1speaking = true;
        P1sprite5.fillAmount = 1;

        P1Lines();

        PlayerWeaponController.P1moreAmmo = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP1Characters();
        DeactivateP1Speech();

        P1speaking = false;
    }
    IEnumerator P2MoreAmmo()
    {
        DeactivateP2Characters();
        ActivateP2Speech();

        P2speaking = true;
        P2sprite5.fillAmount = 1;

        P2Lines();

        PlayerWeaponController.P2moreAmmo = false;

        yield return new WaitForSeconds(1.5f);

        DeactivateP2Characters();
        DeactivateP2Speech();

        P2speaking = false;
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
        if (SelectionMenuController.P1characterType == 1)
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

    private void P1Lines()
    {
        randomSpeech = Random.Range(0, 90);

        if (SelectionMenuController.P1characterType == 1)
        {
            //enemy
            if (HealthSystem.P1ramEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Splash!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Wrecked!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Gotta do better than that!";
                }
            }
            if (HealthSystem.P1lightEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Splash!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Wrecked!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Gotta do better than that!";
                }
            }
            if (HealthSystem.P1missileEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Slagged another one!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Look out below!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "It’s raining scrap";
                }
            }
            if (HealthSystem.P1destroyerEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Slagged another one!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Look out below!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "It’s raining scrap";
                }
            }
            if (HealthSystem.P1bossKill)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Another successful hunt!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Thought you had me there, didn’t ya?";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "The crew’s gonna love hearing this one.";
                }
            }

            //health pickup
            if (PlayerHealthSystem.P1lessLive)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Dangit! That was my favorite ship.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "What’s with all the alarms?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "At least I have a spare.";
                }
            }
            if (PlayerHealthSystem.P1currentLives < 0 && !P1NoLiveSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "That was my last ship?!?";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Emergency landing!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Eject!Eject!";
                }
            }
            if (PlayerHealthSystem.P1currentHealth <= (PlayerHealthSystem.P1maxHealth / 2) && !P1HalfHealthSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Dangit! That was my favorite ship.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "What’s with all the alarms?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "At least I have a spare.";
                }
            }
            if (PlayerHealthSystem.P1moreHealth)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "It was just a scratch!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Was starting to miss that wing!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Just like new.";
                }
            }
            if (PlayerHealthSystem.P1moreShield)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Can’t scratch my paint!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Shields up!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Hah!That tickles.";
                }
            }
            if (PlayerHealthSystem.P1moreLive)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Nice! A spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "You can never have too many ships.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Just try and stop me!";
                }
            }

            //weapon pickup
            if (PlayerWeaponController.P1morePrimary)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "More guns! More glory!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Oooh you’re gonna get it now.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Ya dun goofed, toasters.";
                }
            }
            if (PlayerWeaponController.P1moreSecondary)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "More guns! More glory!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Oooh you’re gonna get it now.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Ya dun goofed, toasters.";
                }
            }
            if (PlayerWeaponController.P1moreAmmo)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "It’s a big girl gun!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Ready to melt some toasters!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Today just got a whole lot better";
                }
            }
        }
        if (SelectionMenuController.P1characterType == 2)
        {
            //enemy
            if (HealthSystem.P1ramEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Splash!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Wrecked!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Gotta do better than that!";
                }
            }
            if (HealthSystem.P1lightEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Splash!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Wrecked!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Gotta do better than that!";
                }
            }
            if (HealthSystem.P1missileEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Slagged another one!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Look out below!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "It’s raining scrap";
                }
            }
            if (HealthSystem.P1destroyerEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Slagged another one!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Look out below!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "It’s raining scrap";
                }
            }
            if (HealthSystem.P1bossKill)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Another successful hunt!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Thought you had me there, didn’t ya?";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "The crew’s gonna love hearing this one.";
                }
            }

            //health pickup
            if (PlayerHealthSystem.P1lessLive)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Dangit! That was my favorite ship.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "What’s with all the alarms?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "At least I have a spare.";
                }
            }
            if (PlayerHealthSystem.P1currentLives < 0 && !P1NoLiveSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "That was my last ship?!?";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Emergency landing!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Eject!Eject!";
                }
            }
            if (PlayerHealthSystem.P1currentHealth <= (PlayerHealthSystem.P1maxHealth / 2) && !P1HalfHealthSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Dangit! That was my favorite ship.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "What’s with all the alarms?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "At least I have a spare.";
                }
            }
            if (PlayerHealthSystem.P1moreHealth)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "It was just a scratch!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Was starting to miss that wing!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Just like new.";
                }
            }
            if (PlayerHealthSystem.P1moreShield)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Can’t scratch my paint!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Shields up!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Hah!That tickles.";
                }
            }
            if (PlayerHealthSystem.P1moreLive)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Nice! A spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "You can never have too many ships.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Just try and stop me!";
                }
            }

            //weapon pickup
            if (PlayerWeaponController.P1morePrimary)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "More guns! More glory!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Oooh you’re gonna get it now.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Ya dun goofed, toasters.";
                }
            }
            if (PlayerWeaponController.P1moreSecondary)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "More guns! More glory!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Oooh you’re gonna get it now.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Ya dun goofed, toasters.";
                }
            }
            if (PlayerWeaponController.P1moreAmmo)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "It’s a big girl gun!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Ready to melt some toasters!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Today just got a whole lot better";
                }
            }
        }
        if (SelectionMenuController.P1characterType == 3)
        {
            //enemy
            if (HealthSystem.P1ramEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Like they ever stood a chance!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Where do they keep getting these?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Not even a fair fight.";
                }
            }
            if (HealthSystem.P1lightEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Like they ever stood a chance!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Where do they keep getting these?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Not even a fair fight.";
                }
            }
            if (HealthSystem.P1missileEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Splash!!!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "At least you tried.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Try and keep up!";
                }
            }
            if (HealthSystem.P1destroyerEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Splash!!!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "At least you tried.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Try and keep up!";
                }
            }
            if (HealthSystem.P1bossKill)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Woo! Actually broke a sweat.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "What did you think was gonna happen?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Can’t wait to brag about this!";
                }
            }

            //health pickup
            if (PlayerHealthSystem.P1lessLive)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Jokes on you I got a spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "That light’s not supposed to flash!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Lucky shot!";
                }
            }
            if (PlayerHealthSystem.P1currentLives < 0 && !P1NoLiveSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "What do you mean I don’t have a spare?!?";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Guess I’m walking…";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Going down!";
                }
            }
            if (PlayerHealthSystem.P1currentHealth <= (PlayerHealthSystem.P1maxHealth / 2) && !P1HalfHealthSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Jokes on you I got a spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "That light’s not supposed to flash!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Lucky shot!";
                }
            }
            if (PlayerHealthSystem.P1moreHealth)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Fresh paint job!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "I was starting to miss that wing.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Guess I could get some fresh air later.";
                }
            }
            if (PlayerHealthSystem.P1moreShield)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Ain’t scratching my paint job now!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Hey toasters!You dropped a battery!!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "O - o oh tingly.";
                }
            }
            if (PlayerHealthSystem.P1moreLive)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Like I need a spare ship!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Guess we can give that spare to the museum.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Nice!An extra ship!!";
                }
            }

            //weapon pickup
            if (PlayerWeaponController.P1morePrimary)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Now with more freedom!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "No we’re talking!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Didn’t think I could get any better!";
                }
            }
            if (PlayerWeaponController.P1moreSecondary)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Now with more freedom!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "No we’re talking!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Didn’t think I could get any better!";
                }
            }
            if (PlayerWeaponController.P1moreAmmo)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "It’s a big boy gun!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "More fuel for the big red button!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Scrap heap’s gonna get a lot bigger!";
                }
            }
        }
        if (SelectionMenuController.P1characterType == 4)
        {
            //enemy
            if (HealthSystem.P1ramEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Like they ever stood a chance!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Where do they keep getting these?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Not even a fair fight.";
                }
            }
            if (HealthSystem.P1lightEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Like they ever stood a chance!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Where do they keep getting these?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Not even a fair fight.";
                }
            }
            if (HealthSystem.P1missileEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Splash!!!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "At least you tried.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Try and keep up!";
                }
            }
            if (HealthSystem.P1destroyerEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Splash!!!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "At least you tried.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Try and keep up!";
                }
            }
            if (HealthSystem.P1bossKill)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Woo! Actually broke a sweat.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "What did you think was gonna happen?!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Can’t wait to brag about this!";
                }
            }

            //health pickup
            if (PlayerHealthSystem.P1lessLive)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Jokes on you I got a spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "That light’s not supposed to flash!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Lucky shot!";
                }
            }
            if (PlayerHealthSystem.P1currentLives < 0 && !P1NoLiveSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "What do you mean I don’t have a spare?!?";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Guess I’m walking…";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Going down!";
                }
            }
            if (PlayerHealthSystem.P1currentHealth <= (PlayerHealthSystem.P1maxHealth / 2) && !P1HalfHealthSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Jokes on you I got a spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "That light’s not supposed to flash!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Lucky shot!";
                }
            }
            if (PlayerHealthSystem.P1moreHealth)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Fresh paint job!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "I was starting to miss that wing.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Guess I could get some fresh air later.";
                }
            }
            if (PlayerHealthSystem.P1moreShield)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Ain’t scratching my paint job now!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Hey toasters!You dropped a battery!!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "O - o oh tingly.";
                }
            }
            if (PlayerHealthSystem.P1moreLive)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Like I need a spare ship!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "Guess we can give that spare to the museum.";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Nice!An extra ship!!";
                }
            }

            //weapon pickup
            if (PlayerWeaponController.P1morePrimary)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Now with more freedom!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "No we’re talking!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Didn’t think I could get any better!";
                }
            }
            if (PlayerWeaponController.P1moreSecondary)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "Now with more freedom!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "No we’re talking!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Didn’t think I could get any better!";
                }
            }
            if (PlayerWeaponController.P1moreAmmo)
            {
                if (randomSpeech <= 30)
                {
                    P1text.text = "It’s a big boy gun!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P1text.text = "More fuel for the big red button!";
                }
                if (randomSpeech > 60)
                {
                    P1text.text = "Scrap heap’s gonna get a lot bigger!";
                }
            }
        }
    }
    private void P2Lines()
    {
        randomSpeech = Random.Range(0, 90);

        if (SelectionMenuController.P2characterType == 1)
        {
            //enemy
            if (HealthSystem.P2ramEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Splash!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Wrecked!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Gotta do better than that!";
                }
            }
            if (HealthSystem.P2lightEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Splash!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Wrecked!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Gotta do better than that!";
                }
            }
            if (HealthSystem.P2missileEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Slagged another one!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Look out below!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "It’s raining scrap";
                }
            }
            if (HealthSystem.P2destroyerEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Slagged another one!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Look out below!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "It’s raining scrap";
                }
            }
            if (HealthSystem.P2bossKill)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Another successful hunt!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Thought you had me there, didn’t ya?";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "The crew’s gonna love hearing this one.";
                }
            }

            //health pickup
            if (PlayerHealthSystem.P2lessLive)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Dangit! That was my favorite ship.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "What’s with all the alarms?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "At least I have a spare.";
                }
            }
            if (PlayerHealthSystem.P2currentLives < 0 && !P2NoLiveSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "That was my last ship?!?";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Emergency landing!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Eject!Eject!";
                }
            }
            if (PlayerHealthSystem.P2currentHealth <= (PlayerHealthSystem.P2maxHealth / 2) && !P2HalfHealthSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Dangit! That was my favorite ship.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "What’s with all the alarms?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "At least I have a spare.";
                }
            }
            if (PlayerHealthSystem.P2moreHealth)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "It was just a scratch!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Was starting to miss that wing!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Just like new.";
                }
            }
            if (PlayerHealthSystem.P2moreShield)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Can’t scratch my paint!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Shields up!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Hah!That tickles.";
                }
            }
            if (PlayerHealthSystem.P2moreLive)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Nice! A spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "You can never have too many ships.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Just try and stop me!";
                }
            }

            //weapon pickup
            if (PlayerWeaponController.P2morePrimary)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "More guns! More glory!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Oooh you’re gonna get it now.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Ya dun goofed, toasters.";
                }
            }
            if (PlayerWeaponController.P2moreSecondary)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "More guns! More glory!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Oooh you’re gonna get it now.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Ya dun goofed, toasters.";
                }
            }
            if (PlayerWeaponController.P2moreAmmo)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "It’s a big girl gun!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Ready to melt some toasters!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Today just got a whole lot better";
                }
            }
        }
        if (SelectionMenuController.P2characterType == 2)
        {
            //enemy
            if (HealthSystem.P2ramEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Splash!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Wrecked!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Gotta do better than that!";
                }
            }
            if (HealthSystem.P2lightEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Splash!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Wrecked!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Gotta do better than that!";
                }
            }
            if (HealthSystem.P2missileEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Slagged another one!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Look out below!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "It’s raining scrap";
                }
            }
            if (HealthSystem.P2destroyerEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Slagged another one!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Look out below!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "It’s raining scrap";
                }
            }
            if (HealthSystem.P2bossKill)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Another successful hunt!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Thought you had me there, didn’t ya?";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "The crew’s gonna love hearing this one.";
                }
            }

            //health pickup
            if (PlayerHealthSystem.P2lessLive)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Dangit! That was my favorite ship.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "What’s with all the alarms?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "At least I have a spare.";
                }
            }
            if (PlayerHealthSystem.P2currentLives < 0 && !P2NoLiveSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "That was my last ship?!?";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Emergency landing!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Eject!Eject!";
                }
            }
            if (PlayerHealthSystem.P2currentHealth <= (PlayerHealthSystem.P2maxHealth / 2) && !P2HalfHealthSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Dangit! That was my favorite ship.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "What’s with all the alarms?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "At least I have a spare.";
                }
            }
            if (PlayerHealthSystem.P2moreHealth)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "It was just a scratch!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Was starting to miss that wing!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Just like new.";
                }
            }
            if (PlayerHealthSystem.P2moreShield)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Can’t scratch my paint!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Shields up!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Hah!That tickles.";
                }
            }
            if (PlayerHealthSystem.P2moreLive)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Nice! A spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "You can never have too many ships.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Just try and stop me!";
                }
            }

            //weapon pickup
            if (PlayerWeaponController.P2morePrimary)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "More guns! More glory!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Oooh you’re gonna get it now.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Ya dun goofed, toasters.";
                }
            }
            if (PlayerWeaponController.P2moreSecondary)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "More guns! More glory!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Oooh you’re gonna get it now.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Ya dun goofed, toasters.";
                }
            }
            if (PlayerWeaponController.P2moreAmmo)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "It’s a big girl gun!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Ready to melt some toasters!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Today just got a whole lot better";
                }
            }
        }
        if (SelectionMenuController.P2characterType == 3)
        {
            //enemy
            if (HealthSystem.P2ramEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Like they ever stood a chance!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Where do they keep getting these?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Not even a fair fight.";
                }
            }
            if (HealthSystem.P2lightEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Like they ever stood a chance!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Where do they keep getting these?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Not even a fair fight.";
                }
            }
            if (HealthSystem.P2missileEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Splash!!!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "At least you tried.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Try and keep up!";
                }
            }
            if (HealthSystem.P2destroyerEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Splash!!!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "At least you tried.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Try and keep up!";
                }
            }
            if (HealthSystem.P2bossKill)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Woo! Actually broke a sweat.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "What did you think was gonna happen?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Can’t wait to brag about this!";
                }
            }

            //health pickup
            if (PlayerHealthSystem.P2lessLive)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Jokes on you I got a spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "That light’s not supposed to flash!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Lucky shot!";
                }
            }
            if (PlayerHealthSystem.P2currentLives < 0 && !P2NoLiveSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "What do you mean I don’t have a spare?!?";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Guess I’m walking…";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Going down!";
                }
            }
            if (PlayerHealthSystem.P2currentHealth <= (PlayerHealthSystem.P2maxHealth / 2) && !P2HalfHealthSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Jokes on you I got a spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "That light’s not supposed to flash!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Lucky shot!";
                }
            }
            if (PlayerHealthSystem.P2moreHealth)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Fresh paint job!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "I was starting to miss that wing.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Guess I could get some fresh air later.";
                }
            }
            if (PlayerHealthSystem.P2moreShield)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Ain’t scratching my paint job now!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Hey toasters!You dropped a battery!!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "O - o oh tingly.";
                }
            }
            if (PlayerHealthSystem.P2moreLive)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Like I need a spare ship!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Guess we can give that spare to the museum.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Nice!An extra ship!!";
                }
            }

            //weapon pickup
            if (PlayerWeaponController.P2morePrimary)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Now with more freedom!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "No we’re talking!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Didn’t think I could get any better!";
                }
            }
            if (PlayerWeaponController.P2moreSecondary)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Now with more freedom!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "No we’re talking!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Didn’t think I could get any better!";
                }
            }
            if (PlayerWeaponController.P2moreAmmo)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "It’s a big boy gun!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "More fuel for the big red button!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Scrap heap’s gonna get a lot bigger!";
                }
            }
        }
        if (SelectionMenuController.P2characterType == 4)
        {
            //enemy
            if (HealthSystem.P2ramEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Like they ever stood a chance!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Where do they keep getting these?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Not even a fair fight.";
                }
            }
            if (HealthSystem.P2lightEnemy == 3)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Like they ever stood a chance!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Where do they keep getting these?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Not even a fair fight.";
                }
            }
            if (HealthSystem.P2missileEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Splash!!!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "At least you tried.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Try and keep up!";
                }
            }
            if (HealthSystem.P2destroyerEnemy == 1)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Splash!!!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "At least you tried.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Try and keep up!";
                }
            }
            if (HealthSystem.P2bossKill)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Woo! Actually broke a sweat.";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "What did you think was gonna happen?!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Can’t wait to brag about this!";
                }
            }

            //health pickup
            if (PlayerHealthSystem.P2lessLive)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Jokes on you I got a spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "That light’s not supposed to flash!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Lucky shot!";
                }
            }
            if (PlayerHealthSystem.P2currentLives < 0 && !P2NoLiveSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "What do you mean I don’t have a spare?!?";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Guess I’m walking…";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Going down!";
                }
            }
            if (PlayerHealthSystem.P2currentHealth <= (PlayerHealthSystem.P2maxHealth / 2) && !P2HalfHealthSpeech)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Jokes on you I got a spare!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "That light’s not supposed to flash!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Lucky shot!";
                }
            }
            if (PlayerHealthSystem.P2moreHealth)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Fresh paint job!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "I was starting to miss that wing.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Guess I could get some fresh air later.";
                }
            }
            if (PlayerHealthSystem.P2moreShield)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Ain’t scratching my paint job now!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Hey toasters!You dropped a battery!!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "O - o oh tingly.";
                }
            }
            if (PlayerHealthSystem.P2moreLive)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Like I need a spare ship!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "Guess we can give that spare to the museum.";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Nice!An extra ship!!";
                }
            }

            //weapon pickup
            if (PlayerWeaponController.P2morePrimary)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Now with more freedom!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "No we’re talking!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Didn’t think I could get any better!";
                }
            }
            if (PlayerWeaponController.P2moreSecondary)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "Now with more freedom!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "No we’re talking!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Didn’t think I could get any better!";
                }
            }
            if (PlayerWeaponController.P2moreAmmo)
            {
                if (randomSpeech <= 30)
                {
                    P2text.text = "It’s a big boy gun!";
                }
                if (randomSpeech > 30 && randomSpeech <= 60)
                {
                    P2text.text = "More fuel for the big red button!";
                }
                if (randomSpeech > 60)
                {
                    P2text.text = "Scrap heap’s gonna get a lot bigger!";
                }
            }
        }
    }
}