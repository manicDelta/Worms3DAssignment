using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfPlayers : MonoBehaviour
{

    private TurnManager _turnManager;
    private PlayerTurnUI _turnUI;
    [SerializeField] GameObject UI;
    public bool gameStarted;


    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        Time.timeScale = 0;
        _turnManager = FindObjectOfType<TurnManager>();
        _turnUI = FindObjectOfType<PlayerTurnUI>();
    }

    //I personally do not like how hardcoded this script is, but whatever, it does its job. Maybe i could do a function
    //with an int as parameter for how many players and put it in for loop.
    public void TwoPlayers()
    {
        //Kill the players on sides to make both players on opposite ends
        _turnManager.players[2].GetComponent<PlayerHealth>().currenthealth = 0;
        _turnManager.players[3].GetComponent<PlayerHealth>().currenthealth = 0;

        UI.SetActive(false);
        _turnUI.DisplayPlayerTurn();
        gameStarted = true;
        Time.timeScale = 1;
    }

    public void FourPlayers()
    {
        UI.SetActive(false);
        _turnUI.DisplayPlayerTurn();
        gameStarted = true;
        Time.timeScale = 1;
    }
}
