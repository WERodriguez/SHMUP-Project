using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Arrays of enemies and powerups.
    public GameObject[] lightEnemies;
    /*public GameObject[] mediumEnemies;
    public GameObject[] heavyEnemies;
    public GameObject[] bosses;
    public GameObject[] powerUps;*/

    public Vector3 spawnValues;

    //Number of enemies
    public int lightEnemyCount;
    public int mediumEnemyCount;
    public int heavyEnemyCount;

    //Tracks # of waves
    public int waveCount;
    
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool gameWin;
    private bool gameOver;
    private bool restart;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        //Wait at the start of the game.
        yield return new WaitForSeconds(startWait);

        //Infinite waves!
        while(true)
        {
            //runs so long as there are enemies being called to spawn.
            for (int i = 0; i < lightEnemyCount; i++)
            {
                //Picks out an enemy from the lightEnemies list.
                GameObject enemySpawn = lightEnemies[Random.Range(0, lightEnemies.Length)];

                //Handles the random positioning of enemies.
                Vector3 spawnPosition = new Vector3
                    (
                    Random.Range (-spawnValues.x, spawnValues.x),    
                    spawnValues.y,
                    spawnValues.z
                    );

                //Handles rotation of objects
                Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);

                //Spawns Enemy
                Instantiate(enemySpawn, spawnPosition, spawnRotation);

                //Waits between spawning enemies.
                yield return new WaitForSeconds(spawnWait);
            }
            //Waits between waves
            yield return new WaitForSeconds(waveWait);
        }
    }
}
