using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarrier : MonoBehaviour
{
    public Transform hangarSpawn;

    public GameObject[] enemyships;

    //Hangar spawn variables.
    public float startWait;
    private int shipSpawns;
    private int spawnSelector;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawnShips());
    }

    IEnumerator spawnShips()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);

            spawnSelector = Random.Range(0, 7);

            //Spawns line of ram enemies.
            if (spawnSelector == 0)
            {
                shipSpawns = 5;
                //Takes 1.25 seconds to loop through
                for (int i = 0; i < shipSpawns; i++)
                {
                    Instantiate(enemyships[0], hangarSpawn.position, hangarSpawn.rotation);
                    yield return new WaitForSeconds(0.25f);
                }
            }
            //Spawns wing of ram enemies.
            else if(spawnSelector == 1)
            {
                Instantiate(enemyships[0], new Vector3(hangarSpawn.position.x, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                yield return new WaitForSeconds(0.2f);
                Instantiate(enemyships[0], new Vector3(hangarSpawn.position.x + 1.5f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                Instantiate(enemyships[0], new Vector3(hangarSpawn.position.x - 1.5f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                yield return new WaitForSeconds(0.5f);
                Instantiate(enemyships[0], new Vector3(hangarSpawn.position.x, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                yield return new WaitForSeconds(0.2f);
                Instantiate(enemyships[0], new Vector3(hangarSpawn.position.x + 1.5f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                Instantiate(enemyships[0], new Vector3(hangarSpawn.position.x - 1.5f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
            }
            //Spawns 3 shooter enemies.
            else if (spawnSelector == 2)
            {
                Instantiate(enemyships[1], new Vector3 (hangarSpawn.position.x, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                yield return new WaitForSeconds(0.2f);
                Instantiate(enemyships[1], new Vector3(hangarSpawn.position.x + 1.0f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                Instantiate(enemyships[1], new Vector3(hangarSpawn.position.x - 1.0f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
            }
            //Spawns 3 machinegun enemies.
            else if (spawnSelector == 3)
            {
                Instantiate(enemyships[2], new Vector3(hangarSpawn.position.x, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                yield return new WaitForSeconds(0.2f);
                Instantiate(enemyships[2], new Vector3(hangarSpawn.position.x + 1.5f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                Instantiate(enemyships[2], new Vector3(hangarSpawn.position.x - 1.5f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
            }
            //Spawns missile fighter
            else if (spawnSelector == 4)
            {
                Instantiate(enemyships[3], hangarSpawn.position, hangarSpawn.rotation);
            }
            else if (spawnSelector == 5)
            {
                Instantiate(enemyships[1], new Vector3(hangarSpawn.position.x, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                Instantiate(enemyships[1], new Vector3(hangarSpawn.position.x + 1.0f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                Instantiate(enemyships[1], new Vector3(hangarSpawn.position.x - 1.0f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                yield return new WaitForSeconds(0.5f);
                Instantiate(enemyships[3], hangarSpawn.position, hangarSpawn.rotation);
            }
            else if (spawnSelector == 6)
            {
                Instantiate(enemyships[2], new Vector3(hangarSpawn.position.x, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                yield return new WaitForSeconds(0.2f);
                Instantiate(enemyships[1], new Vector3(hangarSpawn.position.x + 1.5f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                Instantiate(enemyships[1], new Vector3(hangarSpawn.position.x - 1.5f, hangarSpawn.position.y, hangarSpawn.position.z), hangarSpawn.rotation);
                yield return new WaitForSeconds(0.5f);
                Instantiate(enemyships[3], hangarSpawn.position, hangarSpawn.rotation);
            }
        }
    }
}
