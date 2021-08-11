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

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (health <= 0)
        {
            player.SetPositionAndRotation(Spawnpoint.position, Spawnpoint.rotation);
            HealthSlider.value = 100;
            health = 100;
        }
        UpdateHealth();
        
    }
    public void UpdateHealth()
    {
        HealthSlider.value = health;
        HealthText.text = health + "%";
    }

    //this method subtracts player health
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }


}

