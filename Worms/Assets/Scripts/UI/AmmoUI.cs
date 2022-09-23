using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{

    [SerializeField] GameObject[] ammoImages;


    public void ResetAmmo()
    {
        for (int i = 0; i < ammoImages.Length; i++)
        {
            ammoImages[i].SetActive(true);
        }
    }

    public void RemoveOneAmmo()
    {
        //Disable the ammo image that comes before the first disabled ammo image
        for (int i = 0; i < ammoImages.Length; i++)
        {
            if(!ammoImages[i].activeInHierarchy)
            {
                ammoImages[i - 1].SetActive(false);
            }
        }

        //When this is called, the last ammo image always is supposed to be turned off as the first bullet was already shot
        //Also the last ammo image will not turn off in the for loop as there will be no ammo turned off after it
        ammoImages[4].SetActive(false);
    }
}
