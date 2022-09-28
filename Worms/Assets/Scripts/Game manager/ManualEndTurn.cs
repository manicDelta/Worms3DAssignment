using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualEndTurn : MonoBehaviour
{

    private TurnManager _turnManager;

    // Start is called before the first frame update
    void Start()
    {
        _turnManager = FindObjectOfType<TurnManager>();
    }

    private void Update()
    {
        EndTurn();
    }

    private void EndTurn()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Due to PlayerTurn script manually changing distanceTraveled to 0 when the conditions are met,
            //distanceTraveled will have to be changed manually here as the conditions will not be met if manually ending turn
            _turnManager.players[_turnManager.activePlayerID].GetComponent<PlayerTurn>().distanceTraveled = 0;
            _turnManager.ChangeTurn();
        }
    }
}
