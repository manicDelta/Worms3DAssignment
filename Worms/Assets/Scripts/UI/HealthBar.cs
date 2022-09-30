using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject[] healthImages;
    PlayerHealth playerHealth;
    Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    // Update is called once per frame
   /* void Update()
    {
        //Damn, not performant to have value change and two math functions in update, if i wanna make it more performant later, lets put this in a function called when player
        //takes damage
        //mySlider.value = Mathf.Round(playerHealth.currenthealth) / Mathf.Round(playerHealth.maxHealth);
    } */

    public void UpdateHealthBar()
    {
        //Disable the health image that comes before the first disabled health image
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (!healthImages[i].activeInHierarchy)
            {
                healthImages[i - 1].SetActive(false);
            }
        }

        //When this is called, the last health image always is supposed to be turned off as the first health is lost
        //Also the last health image will not turn off in the for loop as there will be no ammo turned off after it
        healthImages[4].SetActive(false);
    }
}
