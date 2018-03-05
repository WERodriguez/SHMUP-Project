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
    
    public GameObject P1character1;
    public GameObject P1character2;
    public GameObject P1character3;
    public GameObject P1character4;
    
    public GameObject P1ship1;
    public GameObject P1ship2;
    public GameObject P1ship3;
    public GameObject P1ship4;
    public GameObject P1ship5;
    public GameObject P1ship6;
    
    public GameObject P1primary1;
    public GameObject P1primary2;
    public GameObject P1primary3;
    
    public GameObject P1secondary1;
    public GameObject P1secondary2;
    public GameObject P1secondary3;
    
    public GameObject P1special1;
    public GameObject P1special2;
    public GameObject P1special3;

    public GameObject P2character1;
    public GameObject P2character2;
    public GameObject P2character3;
    public GameObject P2character4;
    
    public GameObject P2ship1;
    public GameObject P2ship2;
    public GameObject P2ship3;
    public GameObject P2ship4;
    public GameObject P2ship5;
    public GameObject P2ship6;
    
    public GameObject P2primary1;
    public GameObject P2primary2;
    public GameObject P2primary3;
    
    public GameObject P2secondary1;
    public GameObject P2secondary2;
    public GameObject P2secondary3;
    
    public GameObject P2special1;
    public GameObject P2special2;
    public GameObject P2special3;

    private GameObject player1CurrentShip;
    private GameObject player2CurrentShip;

    private void Start()
    {
        /*shipList = new GameObject[2];

        for(int counter = 0; counter < 2; counter++)
        {
            shipList[counter] = transform.gameObject;
            shipList[counter].SetActive(false);
        }*/

        //ship spawning
        if(UIController.onePlayer)
        {
            CheckPlayer1Ship();
            Invoke("SpawnPlayer1", 0f);
        }
        if (!UIController.onePlayer)
        {
            CheckPlayer1Ship();
            Invoke("SpawnPlayer1", 0f);
            CheckPlayer2Ship();
            Invoke("SpawnPlayer2", 0f);
        }
    }

    private void CheckPlayer1Ship()
    {
        if (UIController.P1shipType == 1)
        {
            player1CurrentShip = P1ship1.gameObject;
        }
        if (UIController.P1shipType == 2)
        {
            player1CurrentShip = P1ship2.gameObject;
        }
        if (UIController.P1shipType == 3)
        {
            player1CurrentShip = P1ship3.gameObject;
        }
        if (UIController.P1shipType == 4)
        {
            player1CurrentShip = P1ship4.gameObject;
        }
        if (UIController.P1shipType == 5)
        {
            player1CurrentShip = P1ship5.gameObject;
        }
        if (UIController.P1shipType == 6)
        {
            player1CurrentShip = P1ship5.gameObject;
        }
    }

    private void CheckPlayer2Ship()
    {
        if (UIController.P2shipType == 1)
        {
            player2CurrentShip = P2ship1.gameObject;
        }
        if (UIController.P2shipType == 2)
        {
            player2CurrentShip = P2ship2.gameObject;
        }
        if (UIController.P2shipType == 3)
        {
            player2CurrentShip = P2ship3.gameObject;
        }
        if (UIController.P2shipType == 4)
        {
            player2CurrentShip = P2ship4.gameObject;
        }
        if (UIController.P2shipType == 5)
        {
            player2CurrentShip = P2ship5.gameObject;
        }
        if (UIController.P2shipType == 6)
        {
            player2CurrentShip = P2ship5.gameObject;
        }
    }

    private void SpawnPlayer1()
    {
        Instantiate(player1CurrentShip, new Vector3(-12, 0, 0), Quaternion.identity);
        player1CurrentShip.SetActive(true);
    }
    private void SpawnPlayer2()
    {
        Instantiate(player2CurrentShip, new Vector3(-12, 0, 0), Quaternion.identity);
        player2CurrentShip.SetActive(true);
    }
}
