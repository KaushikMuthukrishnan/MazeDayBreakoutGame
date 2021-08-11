using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDATA : MonoBehaviour
{
    private float health = 100;
    public Text HealthText;
    public Slider HealthSlider;
    public Transform Spawnpoint;
    private Transform player;

    
    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (health <= 0)
        {
            player.SetPositionAndRotation(Spawnpoint.position, Spawnpoint.rotation);
            HealthSlider.value=100;
            health = 100;
        }

        UpdateDamage();
        
    }
    public void UpdateDamage()
    {
        HealthText.text = "" + health + "%";
        HealthSlider.value = health;
    }

    //This method is to be accessed by the enemy scripts so that if their shooting raycast hits the player,
    //they can call this method attached to the player
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }


}

