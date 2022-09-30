using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{

    public float distancePerTurn;
    public float distanceTraveled;
    [SerializeField] private float waitTimeForNextTurn = 1;
    private bool _coroutineStarted;

    private TurnManager _turnManager;
    private Weapon _myWeapon;


    // Start is called before the first frame update
    void Start()
    {
        _turnManager = FindObjectOfType<TurnManager>();
        _myWeapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerTurn();
    }

    private void CheckPlayerTurn()
    {
        //Check if player has traveled their distance this turn, and used up all their bullets. _coroutineStarted is to make sure it does not get triggered 50 times
        // and avoids photosensitive epileptic seizures
        if(distanceTraveled >= distancePerTurn && _myWeapon.currentBullets <= 0 && !_coroutineStarted)
        {
            StartCoroutine(NextTurnRoutine());
        }
    }

    IEnumerator NextTurnRoutine()
    {
        _coroutineStarted = true;
        yield return new WaitForSeconds(waitTimeForNextTurn);

        _turnManager.StartNextTurn();
        distanceTraveled = 0;
        _coroutineStarted = false;
    }
}
