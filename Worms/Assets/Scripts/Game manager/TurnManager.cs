using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public PlayerMovement[] players;
    public int activePlayerID;
    [SerializeField] float _turnWaitTime = 3f;
    private Camera mainCamera;
    private PlayerTurnUI _turnUI;
    private AmmoUI _ammoUI;
    private MapOverviewCamera _cameraController;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        players = FindObjectsOfType<PlayerMovement>();
        _turnUI = FindObjectOfType<PlayerTurnUI>();
        _ammoUI = FindObjectOfType<AmmoUI>();
        _cameraController = FindObjectOfType<MapOverviewCamera>();

        //Assign player IDs
        for (int i = 0; i < players.Length; i++)
        {
            players[i].playerID = i;
        }

        //Active player is -1 before changing turn, because changeturn will add 1 before changing player, making player with ID 0 (player one) being first
        activePlayerID = -1;
        CheckNextPlayer();
        DisablePlayersControls();
        ChangeTurn();
    }

    public void StartNextTurn()
    {
        StartCoroutine(StartNextTurnRoutine());
    }

    IEnumerator StartNextTurnRoutine()
    {
        //First off, disable and check who is next player
        DisablePlayersControls();
        CheckNextPlayer();

        //Set camera to be above and display who is the next player, which is why we checked who is next previously
        _cameraController.SetOverviewCam();
        _turnUI.DisplayPlayerTurn();

        yield return new WaitForSeconds(_turnWaitTime);

        //After waiting, actually set the turn and set back to default cam
        ChangeTurn();
        _cameraController.SetDefaultCam();
    }

    private void CheckNextPlayer()
    {
        //Put forward the turn to next player
        activePlayerID++;

        if (activePlayerID >= players.Length)
        {
            activePlayerID = 0;
        }

        //Skip dead players
        PlayerHealth activePlayerHealth = players[activePlayerID].GetComponent<PlayerHealth>();
        if (!activePlayerHealth.isAlive)
        {
            CheckNextPlayer();
            return;
        }
    }

    private void DisablePlayersControls()
    {
        //disable both the playermovement and weapon script, if either of these do not get deactivated
        //Players whose turn it currently is not will also move / shoot with the active player
        for (int i = 0; i < players.Length; i++)
        {
            Weapon playerWeapon = players[i].GetComponent<Weapon>();

            players[i].enabled = false;
            playerWeapon.enabled = false;
        }
    }


    public void ChangeTurn()
    {
        //Set active controls
        for (int i = 0; i < players.Length; i++)
        {
            Weapon playerWeapon = players[i].GetComponent<Weapon>();

            // enable both the playermovement and weapon script, if one of these do not get activated, the player cant move or shoot, depending on which is skipped
            if(players[i].playerID == activePlayerID)
            {
                players[i].enabled = true;
                playerWeapon.enabled = true;
                playerWeapon.ResetBullets();
            }
        }

        _ammoUI.ResetAmmo();
        SetCameraOnActivePlayer();
    }

    private void SetCameraOnActivePlayer()
    {
        mainCamera.transform.position = players[activePlayerID].cameraPos.position;
        mainCamera.transform.rotation = players[activePlayerID].cameraPos.rotation;
        mainCamera.transform.parent = players[activePlayerID].transform;
    }
}
