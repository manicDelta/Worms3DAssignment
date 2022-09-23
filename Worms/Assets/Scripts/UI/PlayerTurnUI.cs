using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTurnUI : MonoBehaviour
{
    [SerializeField] TMP_Text _turnText;
    private TurnManager _turnManager;
    [SerializeField] float textDuration;
    private bool _firstCalled = false;

    private void Start()
    {
        _turnManager = FindObjectOfType<TurnManager>();
    }

    public void DisplayPlayerTurn()
    {
        //As the turnmanager starts of with starting player ones turn, we need to skip first time this is called. It gets called again when
        //player choses how many players will be ingame, as to show which players turn it is when the game actually starts instead of before.
        if(!_firstCalled)
        {
            _firstCalled = true;
            return;
        }

        //We need to add 1 to the active player id, as player 1 has ID 0, player 2 has ID 1, etc...
        _turnText.text = $"Player {_turnManager.activePlayerID + 1} Turn";
        StartCoroutine(DisplayTextRoutine());
    }

    IEnumerator DisplayTextRoutine()
    {
        _turnText.gameObject.SetActive(true);

        yield return new WaitForSeconds(textDuration);

        _turnText.gameObject.SetActive(false);
    }
}
