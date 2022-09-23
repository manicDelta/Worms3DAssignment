using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

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
        //Haha i did it
        mySlider.value = Mathf.Round(playerHealth.currenthealth) / Mathf.Round(playerHealth.maxHealth);
    }
}
