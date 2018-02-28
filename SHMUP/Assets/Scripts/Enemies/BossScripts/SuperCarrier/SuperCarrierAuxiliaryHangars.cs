using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCarrierAuxiliaryHangars : MonoBehaviour
{
    public Transform hangarSpawn;

    public GameObject[] enemyships;

    //Hangar spawn variables.
    public float startWait;
    private int shipSpawns;

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

            shipSpawns = 5;
            //Takes 1.25 seconds to loop through
            for (int i = 0; i < shipSpawns; i++)
            {
                Instantiate(enemyships[0], hangarSpawn.position, hangarSpawn.rotation);
                yield return new WaitForSeconds(0.25f);
            }

            yield return new WaitForSeconds(5.0f);
            Instantiate(enemyships[2], hangarSpawn.position, hangarSpawn.rotation);

            yield return new WaitForSeconds(10.0f);
            Instantiate(enemyships[1], hangarSpawn.position, hangarSpawn.rotation);

            yield return new WaitForSeconds(10.0f);
            shipSpawns = 5;

            //Adds up to 10 seconds with previous time.
            yield return new WaitForSeconds(10);
            Instantiate(enemyships[1], hangarSpawn.position, hangarSpawn.rotation);

            yield return new WaitForSeconds(5.0f);
            Instantiate(enemyships[2], hangarSpawn.position, hangarSpawn.rotation);

            yield return new WaitForSeconds(10.0f);
            Instantiate(enemyships[1], hangarSpawn.position, hangarSpawn.rotation);

            yield return new WaitForSeconds(5.0f);
            Instantiate(enemyships[2], hangarSpawn.position, hangarSpawn.rotation);

            //yield return new WaitForSeconds(30.0f);
        }
    }
}
