using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public PlayerMovement[] players;
    public int activePlayerID;
    private Camera mainCamera;
    private PlayerTurnUI _turnUI;
    private AmmoUI _ammoUI;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        players = FindObjectsOfType<PlayerMovement>();
        _turnUI = FindObjectOfType<PlayerTurnUI>();
        _ammoUI = FindObjectOfType<AmmoUI>();

        //Assign player IDs
        for (int i = 0; i < players.Length; i++)
        {
            players[i].playerID = i;
        }

        //Active player is -1 before changing turn, because changeturn will add 1 before changing player, making player with ID 0 (player one) being first
        activePlayerID = -1;
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        //Put forward the turn to next player
        activePlayerID++;

        if(activePlayerID >= players.Length)
        {
            activePlayerID = 0;
        }

        //Skip dead players
        PlayerHealth activePlayerHealth = players[activePlayerID].GetComponent<PlayerHealth>();
        if(!activePlayerHealth.isAlive)
        {
            ChangeTurn();
            return;
        }

        //Set active controls
        for (int i = 0; i < players.Length; i++)
        {
            Weapon playerWeapon = players[i].GetComponent<Weapon>();

            //Disable / enable both the playermovement and weapon script, if either of these do not get deactivated
            //Players whose turn it currently is not will also move / shoot with the active player
            if(players[i].playerID == activePlayerID)
            {
                players[i].enabled = true;
                playerWeapon.enabled = true;
                playerWeapon.ResetBullets();
            }
            else
            {
                players[i].enabled = false;
                playerWeapon.enabled = false;
            }
        }

        _ammoUI.ResetAmmo();
        SetCameraOnActivePlayer();
        _turnUI.DisplayPlayerTurn();
    }

    private void SetCameraOnActivePlayer()
    {
        mainCamera.transform.position = players[activePlayerID].cameraPos.position;
        mainCamera.transform.rotation = players[activePlayerID].cameraPos.rotation;
        mainCamera.transform.parent = players[activePlayerID].transform;
    }
}
