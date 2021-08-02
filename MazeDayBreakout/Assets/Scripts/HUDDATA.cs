using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDATA : MonoBehaviour
{
    public float health = 100;
    public Text HealthText;
    public Slider HealthSlider;

    void Update()
    {
        HealthText.text = "" + health + "%";
        //!Debug Script: remove when done
        if (Input.GetKeyDown(KeyCode.E))
        {
            health -= 10;
            Debug.Log("OUCH -10 health");

        }
        DamageIndicator();
    }
    public void DamageIndicator()
    {
        HealthSlider.value = health;
    }

    //This method is to be accessed by the enemy scripts so that if their shooting raycast hits the player,
    ////they can call this method attached to the player
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }


}

