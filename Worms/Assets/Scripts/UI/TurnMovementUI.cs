using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnMovementUI : MonoBehaviour
{

    [SerializeField] private Slider _movementSlider;
    private TurnManager _turnManager;
    [SerializeField] private PlayerTurn[] players;
    private bool _playersInitialized = false;

    // Start is called before the first frame update
    void Start()
    {
        _turnManager = FindObjectOfType<TurnManager>();

        players = new PlayerTurn[4];
        StartCoroutine(FindPlayerTurnScripts());
    }

    IEnumerator FindPlayerTurnScripts()
    {
        //Using coroutine to delay finding the playerturn scripts by one frame so that turnmanager has time to find them. If done in start,
        //player turn scripts can not be assigned as turnmanager has not assigned players yet.
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < _turnManager.players.Length; i++)
        {
            players[i] = _turnManager.players[i].gameObject.GetComponent<PlayerTurn>();
        }

        _playersInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovementUI();
    }

    private void UpdateMovementUI()
    {
        //Wait until the players are initialized before updating the value, without waiting for it, there would be errors as the variables are not assigned
        if (!_playersInitialized) return;

        _movementSlider.value = players[_turnManager.activePlayerID].distanceTraveled / players[_turnManager.activePlayerID].distancePerTurn;
    }
}
