using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    //P1 ship list
    public GameObject P1ship1;
    public GameObject P1ship2;
    public GameObject P1ship3;
    public GameObject P1ship4;
    public GameObject P1ship5;

    //P2 ship list
    public GameObject P2ship1;
    public GameObject P2ship2;
    public GameObject P2ship3;
    public GameObject P2ship4;
    public GameObject P2ship5;

    //Currently selected ships
    private GameObject player1CurrentShip;
    private GameObject player2CurrentShip;

    //Player spawn locations
    public Transform player1Spawn;
    public Transform player2Spawn;

    private void Start()
    {
        DeactivateP1OriginalShips();
        DeactivateP2OriginalShips();

        //ship spawning
        if(MainMenuController.onePlayer)
        {
            CheckPlayer1Ship();
            Invoke("SpawnPlayer1", 0f);
        }
        else
        {
            CheckPlayer1Ship();
            Invoke("SpawnPlayer1", 0f);
            CheckPlayer2Ship();
            Invoke("SpawnPlayer2", 0f);
        }
    }

    private void CheckPlayer1Ship()
    {
        if (SelectionMenuController.P1shipType == 1)
        {
            P1ship1.gameObject.SetActive(true);
            player1CurrentShip = P1ship1.gameObject;
        }
        if (SelectionMenuController.P1shipType == 2)
        {
            P1ship2.gameObject.SetActive(true);
            player1CurrentShip = P1ship2.gameObject;
        }
        if (SelectionMenuController.P1shipType == 3)
        {
            P1ship3.gameObject.SetActive(true);
            player1CurrentShip = P1ship3.gameObject;
        }
        if (SelectionMenuController.P1shipType == 4)
        {
            P1ship4.gameObject.SetActive(true);
            player1CurrentShip = P1ship4.gameObject;
        }
        if (SelectionMenuController.P1shipType == 5)
        {
            P1ship5.gameObject.SetActive(true);
            player1CurrentShip = P1ship5.gameObject;
        }
    }
    private void CheckPlayer2Ship()
    {
        if (SelectionMenuController.P2shipType == 1)
        {
            P2ship1.gameObject.SetActive(true);
            player2CurrentShip = P2ship1.gameObject;
        }
        if (SelectionMenuController.P2shipType == 2)
        {
            P2ship2.gameObject.SetActive(true);
            player2CurrentShip = P2ship2.gameObject;
        }
        if (SelectionMenuController.P2shipType == 3)
        {
            P2ship3.gameObject.SetActive(true);
            player2CurrentShip = P2ship3.gameObject;
        }
        if (SelectionMenuController.P2shipType == 4)
        {
            P2ship4.gameObject.SetActive(true);
            player2CurrentShip = P2ship4.gameObject;
        }
        if (SelectionMenuController.P2shipType == 5)
        {
            P2ship5.gameObject.SetActive(true);
            player2CurrentShip = P2ship5.gameObject;
        }
    }

    private void DeactivateP1OriginalShips()
    {
        P1ship1.gameObject.SetActive(false);
        P1ship2.gameObject.SetActive(false);
        P1ship3.gameObject.SetActive(false);
        P1ship4.gameObject.SetActive(false);
        P1ship5.gameObject.SetActive(false);
    }
    private void DeactivateP2OriginalShips()
    {
        P2ship1.gameObject.SetActive(false);
        P2ship2.gameObject.SetActive(false);
        P2ship3.gameObject.SetActive(false);
        P2ship4.gameObject.SetActive(false);
        P2ship5.gameObject.SetActive(false);
    }

    private void SpawnPlayer1()
    {
        Instantiate(player1CurrentShip, player1Spawn.position, player1Spawn.rotation);
        DeactivateP1OriginalShips();
    }
    private void SpawnPlayer2()
    {
        Instantiate(player2CurrentShip, player2Spawn.position, player2Spawn.rotation);
        DeactivateP2OriginalShips();
    }
}
