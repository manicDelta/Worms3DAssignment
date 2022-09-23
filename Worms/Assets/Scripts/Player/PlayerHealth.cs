using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] public int maxHealth;
    public int currenthealth;
    public bool isAlive;
    private bool _isColliding;

    private VictoryManager _victoryManager;
    private DeathPos _deathPos;
    private HealthBar _myHealthBar;

    private void Awake()
    {
        isAlive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        _victoryManager = FindObjectOfType<VictoryManager>();
        _deathPos = FindObjectOfType<DeathPos>();
        _myHealthBar = GetComponentInChildren<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if(currenthealth <= 0)
        {
            //If player has no health, put them under the map instead of destroying. Destroying a player would seriously mess up the TurnManager
            isAlive = false;
            transform.position = _deathPos.transform.position;
            _victoryManager.CheckForWin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Take damage, _isColliding makes sure that a bullet will not be registered twice
        if (other.gameObject.CompareTag("Bullet") && !_isColliding)
        {
            _isColliding = true;
            currenthealth--;
            _myHealthBar.UpdateHealthBar();
            StartCoroutine(ResetCollidingRoutine());
            Destroy(other.gameObject);
        }
    }

    IEnumerator ResetCollidingRoutine()
    {
        yield return new WaitForEndOfFrame();

        _isColliding = false;
    }
}
