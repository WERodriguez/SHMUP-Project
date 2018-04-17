using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject bossWarning;

    //Arrays of enemies and powerups.
    public GameObject[] lightEnemies;
    public GameObject[] mediumEnemies;
    public GameObject[] heavyEnemies;
    public GameObject[] wings;
    public GameObject[] bosses;
    public GameObject[] powerUps;

    public Transform[] mainSpawns;
    public Transform[] leftSpawns;
    public Transform[] rightSpawns;
    public Transform bossSpawn;
    
    public Vector3 spawnValues;

    //Number of enemies
    public int spawnCount;

    //Which spawn to use
    public int whichSpawn1;
    public int whichSpawn2;

    //Tracks # of waves
    //public int waveCount;
    public int level;

    public float spawnWait;
    public float startWait;
    public float waveWait;

    //MusicVariables
    private AudioClip[] levelOneMusic;
    private AudioClip[] levelTwoMusic;
    private AudioClip[] levelThreeMusic;
    private AudioSource[] musicPlayer;
    //Checks if it's time for the boss.
    private bool isBossTime;
    private bool stopVolumeDecrease;
    private bool stopVolumeIncrease;

    public float volumeChangeSpeed;
    public float desiredVolume;
    public float volume;

    private void Start()
    {
        bossWarning.SetActive(false);

        isBossTime = false;
        stopVolumeDecrease = false;
        stopVolumeIncrease = false;
        musicPlayer = GetComponents<AudioSource>();
        levelOneMusic = new AudioClip[]
        {
            (AudioClip)Resources.Load("Music/LVL1Loop/Be Faster_demo"),
            (AudioClip)Resources.Load("Music/LVL1Boss/Can't Stop Me_demo")
        };
        levelTwoMusic = new AudioClip[]
        {
            (AudioClip)Resources.Load("Music/LVL2Loop/Time For Action_demo"),
            (AudioClip)Resources.Load("Music/LVL2Boss/Heart of Warrior (Looped)")
        };
        levelThreeMusic = new AudioClip[]
        {
            (AudioClip)Resources.Load("Music/LVL3Loop/Unbreakable (Looped)"),
            (AudioClip)Resources.Load("Music/LVL3Boss/No Way Back (Looped)")
        };

        if (level == 1)
        {
            musicPlayer[0].clip = levelOneMusic[0];
            musicPlayer[1].clip = levelOneMusic[1];
            musicPlayer[0].Play();
            StartCoroutine(Level1());
        }
        else if (level == 2)
        {
            musicPlayer[0].clip = levelTwoMusic[0];
            musicPlayer[1].clip = levelTwoMusic[1];
            musicPlayer[0].Play();
            StartCoroutine(Level2());
        }

        else if (level == 3)
        {
            musicPlayer[0].clip = levelThreeMusic[0];
            musicPlayer[1].clip = levelThreeMusic[1];
            musicPlayer[0].Play();
            StartCoroutine(Level3());
        }
    }

    private void Update()
    {
        if (isBossTime && !stopVolumeDecrease)
        {
            volume = musicPlayer[0].volume;
            desiredVolume = -0.1f;

            musicPlayer[0].volume = Mathf.Lerp(volume, desiredVolume, Time.deltaTime * volumeChangeSpeed);

            volume = musicPlayer[0].volume;

            if (volume <= 0)
            {
                musicPlayer[0].volume = 0.0f;
                stopVolumeDecrease = true;
            }
        }
        else if (isBossTime && stopVolumeDecrease && !stopVolumeIncrease)
        {
            volume = musicPlayer[1].volume;
            stopVolumeDecrease = true;
            desiredVolume = 0.5f;
            musicPlayer[1].volume = Mathf.Lerp(volume, desiredVolume, Time.deltaTime * volumeChangeSpeed);

            if (volume > 0.5f)
            {
                stopVolumeIncrease = true;
                musicPlayer[1].volume = 0.05f;
            }
        }
    }

    IEnumerator Level1()
    {
        yield return new WaitForSeconds(startWait);

        //CallBoss();

        Instantiate(lightEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(lightEnemies[0], mainSpawns[7].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[0], mainSpawns[5].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(1.5f);

        //Spawns row of enemies.
        for (int i = 0; i < 3; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[0].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(1.5f);
        //Spawns row of enemies.
        for (int i = 0; i < 3; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[12].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[10].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        //ShooterSpawn
        yield return new WaitForSeconds(1.0f);
        Instantiate(lightEnemies[1], mainSpawns[7].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[5].position, mainSpawns[0].rotation);

        //SHooterSpawn
        yield return new WaitForSeconds(0.5f);
        Instantiate(lightEnemies[1], mainSpawns[8].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[4].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2);

        //Lines of shooter enemies
        Instantiate(lightEnemies[1], mainSpawns[12].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[0].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[11].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);


        //Wing spawn
        yield return new WaitForSeconds(2.0f);
        Instantiate(wings[0], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[10].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(1.5f);
        Instantiate(wings[0], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[11].position, mainSpawns[0].rotation);

        //First time missile boat.
        yield return new WaitForSeconds(3);
        Instantiate(mediumEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);

        //Spawns health down the center for the player.
        yield return new WaitForSeconds(2);
        Instantiate(powerUps[0], mainSpawns[6].position, mainSpawns[0].rotation);

        //Spawns two rows of enemies.
        yield return new WaitForSeconds(6);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[8].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[4].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        //Spawns two rows of enemies.
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        //Spawns two diagonal rows of enemies.
        yield return new WaitForSeconds(2);
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        for (int i = 0; i < 7; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            whichSpawn1++;
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(1);

        for (int i = 0; i <7; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[0].rotation);
            whichSpawn2--;
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(1);

        //Spawns two diagonal rows of enemies.
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        for (int i = 0; i < 7; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            whichSpawn1++;
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(1);

        for (int i = 0; i < 7; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[0].rotation);
            whichSpawn2--;
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(3);

        //Spawns shooter enemies from left to right
        Instantiate(lightEnemies[1], mainSpawns[0].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);

        //Spawns shooter enemies from right to left
        Instantiate(lightEnemies[1], mainSpawns[12].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[11].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);


        //Group of two missile ships.
        yield return new WaitForSeconds(2);
        Instantiate(mediumEnemies[0], mainSpawns[4].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[0], mainSpawns[8].position, mainSpawns[0].rotation);


        yield return new WaitForSeconds(3);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        //Spawns Heavy
        Instantiate(heavyEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(5);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        //Wing spawn
        yield return new WaitForSeconds(10);
        Instantiate(wings[0], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[10].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2.0f);
        Instantiate(mediumEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);

        //Wing spawn
        yield return new WaitForSeconds(2);
        Instantiate(wings[0], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[10].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(1);
        Instantiate(wings[0], mainSpawns[4].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[8].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(3);
        Instantiate(heavyEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);

        //Spawns 2 missiles after heavy enemy
        whichSpawn1 = 6;
        for (int i = 0; i < 2; i++)
        {
            Instantiate(mediumEnemies[0], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            whichSpawn1 += 3;
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(10);
        Instantiate(heavyEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(5);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        //Spawns one shield pick up.
        yield return new WaitForSeconds(3);
        Instantiate(powerUps[1], mainSpawns[6].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(8);
        Instantiate(wings[0], mainSpawns[6].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(0.5f);
        Instantiate(wings[0], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(0.5f);
        //Put shooters in here.
        whichSpawn1 = 3;
        whichSpawn2 = 9;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[0].rotation);
            whichSpawn1++;
            whichSpawn2--;
        }

        yield return new WaitForSeconds(1);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[1].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[11].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(2);
        Instantiate(wings[0], mainSpawns[6].position, mainSpawns[0].rotation);

        whichSpawn1 = 0;
        whichSpawn2 = 12;
        //Diagonal Shooter Spawn
        for (int i = 0; i < 3; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[0].rotation);
            whichSpawn1++;
            whichSpawn2--;
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[4].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[8].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(1.5f);
        Instantiate(wings[0], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(1);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[11].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[1].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        whichSpawn1 = 3;
        whichSpawn2 = 9;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[0].rotation);
            whichSpawn1++;
            whichSpawn2--;
        }

        yield return new WaitForSeconds(1);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[0].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[12].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(1.5f);
        Instantiate(lightEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[11].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[12].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(1);
        Instantiate(mediumEnemies[0], mainSpawns[11].position, mainSpawns[0].rotation);
        
        yield return new WaitForSeconds(1.5f);
        Instantiate(lightEnemies[1], mainSpawns[0].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(1);
        Instantiate(mediumEnemies[0], mainSpawns[1].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(5);
        //Tells the game it's time for boss fightin.
        isBossTime = true;

        yield return new WaitForSeconds(2);
        //Changes the music loop to the boss loop
        musicPlayer[0].Pause();

        Instantiate(powerUps[0], mainSpawns[5].position, mainSpawns[0].rotation);
        Instantiate(powerUps[1], mainSpawns[7].position, mainSpawns[0].rotation);

        bossWarning.SetActive(true);

        yield return new WaitForSeconds(3);

        bossWarning.SetActive(false);

        yield return new WaitForSeconds(3);
        musicPlayer[1].Play();

        for (int i = 0; i <=5; i ++)
        {
            Instantiate(wings[0], mainSpawns[6].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(wings[0], mainSpawns[3].position, mainSpawns[0].rotation);
            Instantiate(wings[0], mainSpawns[9].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        Instantiate(lightEnemies[1], mainSpawns[5].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[6].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[7].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(0.5f);

        Instantiate(lightEnemies[1], mainSpawns[0].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);

        Instantiate(lightEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[11].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[12].position, mainSpawns[0].rotation);


        yield return new WaitForSeconds(2.0f);
        
        Instantiate(mediumEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(mediumEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(1);


        yield return new WaitForSeconds(6);

        Instantiate(bosses[0], bossSpawn.position, bossSpawn.rotation);
    }

    IEnumerator Level2()
    {
        yield return new WaitForSeconds(startWait);
        //Wings
        Instantiate(wings[0], mainSpawns[6].position, mainSpawns[6].rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(wings[0], mainSpawns[4].position, mainSpawns[6].rotation);
        Instantiate(wings[0], mainSpawns[8].position, mainSpawns[6].rotation);

        //Shooter Groups
        yield return new WaitForSeconds(1.5f);
        Instantiate(lightEnemies[1], mainSpawns[0].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);

        Instantiate(lightEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[11].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[12].position, mainSpawns[0].rotation);

        //Center shooter group
        yield return new WaitForSeconds(0.5f);
        Instantiate(lightEnemies[1], mainSpawns[5].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[6].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[7].position, mainSpawns[0].rotation);

        //Missile fighters
        yield return new WaitForSeconds(2.0f);
        Instantiate(mediumEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(mediumEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);
        
        //torpedo introduction
        yield return new WaitForSeconds(2.0f);
        Instantiate(mediumEnemies[1], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(3.0f);
        Instantiate(mediumEnemies[1], mainSpawns[8].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(1.0f);
        Instantiate(mediumEnemies[1], mainSpawns[4].position, mainSpawns[0].rotation);

        //Interceptor introduction
        yield return new WaitForSeconds(4.0f);
        Instantiate(lightEnemies[2], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(2.0f);
        Instantiate(lightEnemies[2], mainSpawns[0].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(0.15f);
        Instantiate(lightEnemies[2], mainSpawns[12].position, mainSpawns[0].rotation);
        
        //More interceptors
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i <= 3; i ++)
        {
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[12].position, mainSpawns[0].rotation);
        }
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i <= 3; i++)
        {
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[0].position, mainSpawns[0].rotation);
        }

        yield return new WaitForSeconds(3.0f);
        Instantiate(lightEnemies[3], mainSpawns[4].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2.0f);
        Instantiate(lightEnemies[3], mainSpawns[8].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[4].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(2.0f);
        Instantiate(lightEnemies[3], mainSpawns[6].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[10].position, mainSpawns[0].rotation);

        //Interceptor group spawns left, swings right.
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[0].position, mainSpawns[0].rotation);
        }
        yield return new WaitForSeconds(0.5f);
        //Interceptor group spawns right, swings left.
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[12].position, mainSpawns[12].rotation);
        }

        //DestroyerGroup
        yield return new WaitForSeconds(0.25f);
        Instantiate(heavyEnemies[0], mainSpawns[2].position, mainSpawns[12].rotation);
        yield return new WaitForSeconds(3.0f);
        Instantiate(heavyEnemies[0], mainSpawns[10].position, mainSpawns[12].rotation);

        //Torpedo > Missile > Torpedo Group
        yield return new WaitForSeconds(3.0f);
        Instantiate(mediumEnemies[1], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(8.0f);
        Instantiate(mediumEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(3.0f);
        Instantiate(mediumEnemies[1], mainSpawns[6].position, mainSpawns[0].rotation);

        //Interceptor Group
        yield return new WaitForSeconds(5.0f);
        for (int i = 0; i <= 7; i++)
        {
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[0].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[12].position, mainSpawns[12].rotation);
        }
        //Carrier
        yield return new WaitForSeconds(1.0f);
        Instantiate(heavyEnemies[1], mainSpawns[6].position, mainSpawns[12].rotation);
        //BeamFighters
        yield return new WaitForSeconds(12.0f);
        Instantiate(mediumEnemies[2], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[2], mainSpawns[9].position, mainSpawns[0].rotation);
        //DestroyerGroup
        yield return new WaitForSeconds(6.0f);
        Instantiate(heavyEnemies[0], mainSpawns[2].position, mainSpawns[12].rotation);
        Instantiate(heavyEnemies[0], mainSpawns[10].position, mainSpawns[12].rotation);
        //BeamFighter
        yield return new WaitForSeconds(12.0f);
        Instantiate(mediumEnemies[2], mainSpawns[6].position, mainSpawns[0].rotation);

        //Machinegunner Group Spawn
        yield return new WaitForSeconds(10.0f);
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        for(int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);

            whichSpawn1++;
            whichSpawn2--;
        }
        Instantiate(lightEnemies[3], mainSpawns[5].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[3], mainSpawns[7].position, mainSpawns[0].rotation);

        //Missile Fighters
        yield return new WaitForSeconds(2.0f);
        Instantiate(mediumEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);

        //Torpedo Group
        yield return new WaitForSeconds(2.0f);
        Instantiate(wings[0], mainSpawns[8].position, mainSpawns[0].rotation);
        whichSpawn1 = 4;
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            Instantiate(mediumEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            whichSpawn1 += 2;
        }
        //Torpedo Group
        yield return new WaitForSeconds(7.5f);
        Instantiate(wings[0], mainSpawns[4].position, mainSpawns[0].rotation);
        whichSpawn1 = 8;
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            Instantiate(mediumEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            whichSpawn1 -= 2;
        }

        //Beam fighter group
        yield return new WaitForSeconds(7.5f);
        whichSpawn1 = 0;
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            Instantiate(mediumEnemies[2], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            whichSpawn1 += 2;
        }
        yield return new WaitForSeconds(1.0f);
        whichSpawn2 = 12;
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            Instantiate(mediumEnemies[2], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);
            whichSpawn2-= 2;
        }

        //InterceptorGroup
        yield return new WaitForSeconds(12.0f);
        whichSpawn1 = 3;
        whichSpawn2 = 9;
        for (int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);
            whichSpawn1 += 1;
            whichSpawn2 -= 1;
        }

        yield return new WaitForSeconds(0.5f);
        Instantiate(heavyEnemies[1], mainSpawns[3].position, mainSpawns[12].rotation);
        Instantiate(heavyEnemies[1], mainSpawns[9].position, mainSpawns[12].rotation);

        yield return new WaitForSeconds(12);
        //Tells the game it's time for boss fightin.
        isBossTime = true;

        yield return new WaitForSeconds(2);
        //Changes the music loop to the boss loop
        musicPlayer[0].Pause();

        Instantiate(powerUps[0], mainSpawns[5].position, mainSpawns[0].rotation);
        Instantiate(powerUps[1], mainSpawns[7].position, mainSpawns[0].rotation);
        bossWarning.SetActive(true);

        yield return new WaitForSeconds(3);

        bossWarning.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        musicPlayer[1].Play();

        yield return new WaitForSeconds(1);


        yield return new WaitForSeconds(6);


        Instantiate(bosses[1], bossSpawn.position, bossSpawn.rotation);
    }

    IEnumerator Level3()
    {
        yield return new WaitForSeconds(startWait);

        //Interceptor Group
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        for (int i = 0; i <= 4; i++)
        {
            Instantiate(lightEnemies[2], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);
            whichSpawn1 += 1;
            whichSpawn2 -= 1;
            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(1.50f);
        //Machinegun Wing
        Instantiate(lightEnemies[3], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(0.15f);
        Instantiate(lightEnemies[3], mainSpawns[5].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[3], mainSpawns[7].position, mainSpawns[0].rotation);
        //Destroyer Escort
        yield return new WaitForSeconds(0.1f);
        Instantiate(heavyEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);

        //TorpedoGroup
        yield return new WaitForSeconds(0.1f);
        Instantiate(mediumEnemies[1], mainSpawns[0].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[1], mainSpawns[12].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(0.25f);
        Instantiate(mediumEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);


        //CarrierGroup
        yield return new WaitForSeconds(6.0f);
        Instantiate(heavyEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(6.0f);
        Instantiate(heavyEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);

        //BeamFighter
        yield return new WaitForSeconds(8.0f);
        Instantiate(mediumEnemies[2], mainSpawns[6].position, mainSpawns[0].rotation);

        //Heavy fighters intro.
        yield return new WaitForSeconds(16.0f);
        Instantiate(mediumEnemies[3], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(5.0f);
        Instantiate(mediumEnemies[3], mainSpawns[3].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(mediumEnemies[3], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2.0f);
        Instantiate(powerUps[0], mainSpawns[3].position, mainSpawns[12].rotation);
        Instantiate(powerUps[3], mainSpawns[9].position, mainSpawns[12].rotation);

        //Interceptor group.
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i <= 2; i++)
        {
            Instantiate(lightEnemies[2], mainSpawns[0].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
        }
        for (int i = 0; i <= 2; i++)
        {
            Instantiate(lightEnemies[2], mainSpawns[12].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
        }

        //Ram wings.
        yield return new WaitForSeconds(2.0f);
        Instantiate(wings[0], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[10].position, mainSpawns[0].rotation);

        //Missile fighters and torp boat.
        yield return new WaitForSeconds(0.25f);
        Instantiate(mediumEnemies[0], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[0], mainSpawns[10].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[1], mainSpawns[6].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(1.25f);
        Instantiate(powerUps[5], mainSpawns[6].position, mainSpawns[12].rotation);


        //Beam fighter group.
        yield return new WaitForSeconds(3.5f);
        whichSpawn1 = 1;
        whichSpawn2 = 11;
        for (int i = 0; i <= 2; i++)
        {
            Instantiate(mediumEnemies[2], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(1.5f);
            Instantiate(mediumEnemies[2], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);
            whichSpawn1 += 2;
            whichSpawn2 -= 2;
            yield return new WaitForSeconds(1.5f);
        }

        yield return new WaitForSeconds(10.0f);
        //Interceptors.
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        for (int i = 0; i <= 4; i++)
        {
            Instantiate(lightEnemies[2], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[2], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);
            whichSpawn1 += 1;
            whichSpawn2 -= 1;
            yield return new WaitForSeconds(0.15f);
        }
        //HeavyFighter Group
        yield return new WaitForSeconds(0.45f);
        Instantiate(mediumEnemies[3], mainSpawns[3].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(mediumEnemies[3], mainSpawns[9].position, mainSpawns[0].rotation);


        Instantiate(powerUps[1], mainSpawns[3].position, mainSpawns[12].rotation);
        Instantiate(powerUps[2], mainSpawns[9].position, mainSpawns[12].rotation);


        yield return new WaitForSeconds(3.5f);
        //Battlecruiser spawn.
        Instantiate(heavyEnemies[2], mainSpawns[6].position, mainSpawns[0].rotation);
        //Ram line spawns
        for (int i = 0; i <= 2; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[2].position, mainSpawns[12].rotation);
            Instantiate(lightEnemies[0], mainSpawns[10].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
        }

        //Shooter enemy spawns
        yield return new WaitForSeconds(5.0f);
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        for (int i = 0; i <= 3; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);
            whichSpawn1 += 1;
            whichSpawn2 -= 1;
            yield return new WaitForSeconds(0.15f);
        }

        //Wing spawns
        yield return new WaitForSeconds(3.0f);
        Instantiate(wings[0], mainSpawns[3].position, mainSpawns[12].rotation);
        Instantiate(wings[0], mainSpawns[9].position, mainSpawns[12].rotation);

        //Torpedo Spawnss
        yield return new WaitForSeconds(3.0f);
        Instantiate(mediumEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(2.0f);
        Instantiate(mediumEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);

        //Wing spawns
        yield return new WaitForSeconds(7.0f);
        Instantiate(wings[0], mainSpawns[3].position, mainSpawns[12].rotation);
        Instantiate(wings[0], mainSpawns[9].position, mainSpawns[12].rotation);
        //Missile/WingSpawns
        yield return new WaitForSeconds(2.0f);
        Instantiate(mediumEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[4].position, mainSpawns[12].rotation);
        Instantiate(wings[0], mainSpawns[8].position, mainSpawns[12].rotation);

        //BattleCruiser
        yield return new WaitForSeconds(6.0f);
        Instantiate(heavyEnemies[2], mainSpawns[10].position, mainSpawns[0].rotation);

        //ShooterLine
        yield return new WaitForSeconds(3.0f);
        Instantiate(lightEnemies[1], mainSpawns[6].position, mainSpawns[12].rotation);
        Instantiate(lightEnemies[1], mainSpawns[5].position, mainSpawns[12].rotation);
        Instantiate(lightEnemies[1], mainSpawns[7].position, mainSpawns[12].rotation);
        yield return new WaitForSeconds(3.0f);
        Instantiate(lightEnemies[1], mainSpawns[6].position, mainSpawns[12].rotation);
        Instantiate(lightEnemies[1], mainSpawns[5].position, mainSpawns[12].rotation);
        Instantiate(lightEnemies[1], mainSpawns[7].position, mainSpawns[12].rotation);
        //Torpedo boat
        yield return new WaitForSeconds(5.0f);
        Instantiate(mediumEnemies[1], mainSpawns[6].position, mainSpawns[12].rotation);

        //Battlecruiser
        yield return new WaitForSeconds(5.0f);
        Instantiate(heavyEnemies[2], mainSpawns[2].position, mainSpawns[0].rotation);

        //Carrier
        yield return new WaitForSeconds(15.0f);
        Instantiate(heavyEnemies[1], mainSpawns[6].position, mainSpawns[0].rotation);
        yield return new WaitForSeconds(3.0f);
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        //ShooterSpawn
        for (int i = 0; i <= 3; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);
            whichSpawn1 += 1;
            whichSpawn2 -= 1;
            yield return new WaitForSeconds(0.15f);
        }
        Instantiate(lightEnemies[3], mainSpawns[4].position, mainSpawns[12].rotation);
        Instantiate(lightEnemies[3], mainSpawns[8].position, mainSpawns[12].rotation);

        //ShooterSpawn
        yield return new WaitForSeconds(3.0f);
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        for (int i = 0; i <= 3; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[12].rotation);
            yield return new WaitForSeconds(0.15f);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[12].rotation);
            whichSpawn1 += 1;
            whichSpawn2 -= 1;
            yield return new WaitForSeconds(0.15f);
        }
        Instantiate(lightEnemies[3], mainSpawns[4].position, mainSpawns[12].rotation);
        Instantiate(lightEnemies[3], mainSpawns[8].position, mainSpawns[12].rotation);






        yield return new WaitForSeconds(12);
        //Tells the game it's time for boss fightin.
        isBossTime = true;

        yield return new WaitForSeconds(2);
        //Changes the music loop to the boss loop
        musicPlayer[0].Pause();

        Instantiate(powerUps[0], mainSpawns[5].position, mainSpawns[0].rotation);
        Instantiate(powerUps[1], mainSpawns[7].position, mainSpawns[0].rotation);

        bossWarning.SetActive(true);
        yield return new WaitForSeconds(3);
        bossWarning.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        musicPlayer[1].Play();

        yield return new WaitForSeconds(1);


        yield return new WaitForSeconds(6);


        Instantiate(bosses[1], bossSpawn.position, bossSpawn.rotation);
    }

    private void CallBoss()
    {
        Instantiate(bosses[0], bossSpawn.position, bossSpawn.rotation);
    }

}
