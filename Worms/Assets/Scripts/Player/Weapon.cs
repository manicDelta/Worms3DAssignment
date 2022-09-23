using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    public int currentBullets;
    public int bulletsPerTurn;

    private AmmoUI _ammoUI;

    private void Start()
    {
        _ammoUI = FindObjectOfType<AmmoUI>();
        ResetBullets();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void ResetBullets()
    {
        currentBullets = bulletsPerTurn;
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentBullets > 0)
        {
            //Instantiate bullet at shootpoints position so it does not hit the shooting player, ontop of that set the
            //bullets rotation to the players so it flies forward
            _ammoUI.RemoveOneAmmo();
            Instantiate(_bullet, _shootPoint.position, transform.rotation);
            currentBullets--;
        }
    }
}
