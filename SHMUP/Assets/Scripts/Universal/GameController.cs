using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
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
    public AudioClip[] levelOneMusic;
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
        isBossTime = false;
        stopVolumeDecrease = false;
        stopVolumeIncrease = false;
        musicPlayer = GetComponents<AudioSource>();
        levelOneMusic = new AudioClip[]
        {
            (AudioClip)Resources.Load("Music/LVL1Loop/Be Faster_demo"),
            (AudioClip)Resources.Load("Music/LVL1Boss/Can't Stop Me_demo")
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

        }

        else if (level == 3)
        {

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

        yield return new WaitForSeconds(2f);

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

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        for (int i = 0; i < 3; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[10].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        for (int i = 0; i < 3; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        //ShooterSpawn
        yield return new WaitForSeconds(1.5f);
        Instantiate(lightEnemies[1], mainSpawns[7].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[5].position, mainSpawns[0].rotation);

        //SHooterSpawn
        yield return new WaitForSeconds(5f);
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
        yield return new WaitForSeconds(2);
        Instantiate(wings[0], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[10].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2);
        Instantiate(wings[0], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[11].position, mainSpawns[0].rotation);

        //First time missile boat.
        yield return new WaitForSeconds(8);
        Instantiate(mediumEnemies[0], mainSpawns[6].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(3);
        Instantiate(powerUps[2], mainSpawns[6].position, mainSpawns[0].rotation);

        //Spawns two rows of enemies.
        yield return new WaitForSeconds(8);
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
        yield return new WaitForSeconds(3);
        whichSpawn1 = 0;
        whichSpawn2 = 12;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[0].rotation);
            whichSpawn1++;
            whichSpawn2--;
            yield return new WaitForSeconds(spawnWait);
        }

        //Spawns two diagonal rows of enemies.
        yield return new WaitForSeconds(3);
        whichSpawn1 = 5;
        whichSpawn2 = 7;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[1], mainSpawns[whichSpawn2].position, mainSpawns[0].rotation);
            whichSpawn1--;
            whichSpawn2++;
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(2);

        Instantiate(lightEnemies[1], mainSpawns[12].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[0].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[11].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);


        //Group of two missile ships.
        yield return new WaitForSeconds(3);
        Instantiate(mediumEnemies[0], mainSpawns[4].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[0], mainSpawns[8].position, mainSpawns[0].rotation);


        yield return new WaitForSeconds(5);
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
            Instantiate(lightEnemies[0], mainSpawns[8].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[4].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        //Wing spawn
        yield return new WaitForSeconds(10);
        Instantiate(wings[0], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2.5f);
        Instantiate(mediumEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(mediumEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);

        //Wing spawn
        yield return new WaitForSeconds(6);
        Instantiate(wings[0], mainSpawns[2].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[10].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(3);
        Instantiate(heavyEnemies[0], mainSpawns[3].position, mainSpawns[0].rotation);

        whichSpawn1 = 4;
        for (int i = 0; i < 2; i++)
        {
            Instantiate(mediumEnemies[0], mainSpawns[whichSpawn1].position, mainSpawns[0].rotation);
            whichSpawn1 += 3;
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(10);
        Instantiate(heavyEnemies[0], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(5);
        Instantiate(wings[0], mainSpawns[6].position, mainSpawns[0].rotation);

        //Spawns 2 PrimaryUp power ups.
        yield return new WaitForSeconds(3);
        Instantiate(powerUps[2], mainSpawns[4].position, mainSpawns[0].rotation);
        Instantiate(powerUps[2], mainSpawns[8].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(10);
        Instantiate(wings[0], mainSpawns[6].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[4].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[8].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(3);
        Instantiate(wings[0], mainSpawns[6].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[4].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[8].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(3);
        Instantiate(wings[0], mainSpawns[3].position, mainSpawns[0].rotation);
        Instantiate(wings[0], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[11].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[1].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(lightEnemies[0], mainSpawns[0].position, mainSpawns[0].rotation);
            Instantiate(lightEnemies[0], mainSpawns[12].position, mainSpawns[0].rotation);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(3);
        Instantiate(lightEnemies[1], mainSpawns[10].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[11].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[12].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(3);
        Instantiate(mediumEnemies[0], mainSpawns[11].position, mainSpawns[0].rotation);
        
        yield return new WaitForSeconds(3);
        Instantiate(lightEnemies[1], mainSpawns[0].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[1].position, mainSpawns[0].rotation);
        Instantiate(lightEnemies[1], mainSpawns[2].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(3);
        Instantiate(mediumEnemies[0], mainSpawns[1].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(6);
        Instantiate(powerUps[2], mainSpawns[5].position, mainSpawns[0].rotation);
        Instantiate(powerUps[2], mainSpawns[7].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2);
        //Tells the game it's time for boss fightin.
        isBossTime = true;

        yield return new WaitForSeconds(2);
        //Changes the music loop to the boss loop
        musicPlayer[0].Pause();

        Instantiate(powerUps[0], mainSpawns[4].position, mainSpawns[0].rotation);
        Instantiate(powerUps[1], mainSpawns[3].position, mainSpawns[0].rotation);

        Instantiate(powerUps[0], mainSpawns[8].position, mainSpawns[0].rotation);
        Instantiate(powerUps[1], mainSpawns[9].position, mainSpawns[0].rotation);

        yield return new WaitForSeconds(2);
        musicPlayer[1].Play();

        yield return new WaitForSeconds(10);

        Instantiate(bosses[0], bossSpawn.position, bossSpawn.rotation);
    }

    private void CallBoss()
    {
        Instantiate(bosses[0], bossSpawn.position, bossSpawn.rotation);
    }
}
