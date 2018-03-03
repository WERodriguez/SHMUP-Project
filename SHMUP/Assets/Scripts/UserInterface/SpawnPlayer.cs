using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player1Spawn;
    /*public GameObject player2Spawn;

    public GameObject[] characterList;
    public GameObject[] shipList;
    public GameObject[] primaryList;
    public GameObject[] secondaryList;
    public GameObject[] specialList;*/
    
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;
    
    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    public GameObject ship4;
    public GameObject ship5;
    public GameObject ship6;
    
    public GameObject primary1;
    public GameObject primary2;
    public GameObject primary3;
    
    public GameObject secondary1;
    public GameObject secondary2;
    public GameObject secondary3;
    
    public GameObject special1;
    public GameObject special2;
    public GameObject special3;

    private GameObject currentShip;

    private void Start()
    {
        /*shipList = new GameObject[2];

        for(int counter = 0; counter < 2; counter++)
        {
            shipList[counter] = transform.gameObject;
            shipList[counter].SetActive(false);
        }*/

        //ship spawning
        if (UIController.shipType == 1)
        {
            currentShip = ship1.gameObject;
            Invoke("Spawn", 1f);
        }
        if (UIController.shipType == 2)
        {
            currentShip = ship2.gameObject;
            Invoke("Spawn", 1f);
        }
        if (UIController.shipType == 3)
        {
            currentShip = ship3.gameObject;
            Invoke("Spawn", 1f);
        }
        if (UIController.shipType == 4)
        {
            currentShip = ship4.gameObject;
            Invoke("Spawn", 1f);
        }
        if (UIController.shipType == 5)
        {
            currentShip = ship5.gameObject;
            Invoke("Spawn", 1f);
        }
    }

    private void Spawn()
    {
        Instantiate(currentShip, new Vector3(-12, 0, 0), Quaternion.identity);
        currentShip.SetActive(true);
    }
}
