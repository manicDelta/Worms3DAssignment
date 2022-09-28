using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{

    TurnManager _turnManager;
    [SerializeField] TMP_Text victoryText;
    [SerializeField] float reloadSceneDelay;

    // Start is called before the first frame update
    void Start()
    {
        _turnManager = FindObjectOfType<TurnManager>();
    }

    public void CheckForWin()
    {
        int defeatedPlayers = 0;

        //See how many players are defeated
        for (int i = 0; i < _turnManager.players.Length; i++)
        {
            PlayerHealth playerHealth = _turnManager.players[i].gameObject.GetComponent<PlayerHealth>();

            if(!playerHealth.isAlive)
            {
                defeatedPlayers++;
            }
        }

        //If 3 or more players are defeated, check find player that is not defeated and put it in victory method. If 2 players is chosen, the other 2 are
        //automatically counted as defeated as their health is put to 0
        if(defeatedPlayers >= 3)
        {
            for (int i = 0; i < _turnManager.players.Length; i++)
            {
                PlayerHealth playerHealth = _turnManager.players[i].gameObject.GetComponent<PlayerHealth>();

                if(playerHealth.isAlive)
                {
                    PlayerVictory(i);
                }
            }
        }
    }

    private void PlayerVictory(int playerID)
    {
        //Add 1 to player ID as player number is 1 higher than ID, player 1 has ID 0, player 2 ID 1, etc...
        victoryText.text = $"Player {playerID + 1} Won";
        victoryText.gameObject.SetActive(true);
        StartCoroutine(ReloadSceneRoutine());
    }

    IEnumerator ReloadSceneRoutine()
    {
        yield return new WaitForSeconds(reloadSceneDelay);
        SceneManager.LoadScene("MainMenu");
    }
}
