using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDATA : MonoBehaviour
{
    public float health = 100;
    public Text HealthText;
    public Slider HealthSlider;
    public Vector3 Spawnpoint;
    public GameObject player;

    
    void Start(){

        Spawnpoint = player.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (health <= 0)
        {
 
        //   player.transform.position = new Vector3(20, 50, 100);
        //   player.transform.rotation = Quaternion.Euler(0, 0, 0);
        //   player.transform.position= new vector3(Spawnpoint.x, Spawnpoint.y, Spawnpoint.z);
        player.transform.position = Spawnpoint;
            HealthSlider.value=100;
            health = 100;
        }
        HealthText.text = "" + health + "%";
        DamageIndicator();
        
    }
    public void DamageIndicator()
    {
//if g is pressed subtract health
        if (Input.GetKeyDown(KeyCode.G))
        {
            health -= 20;
        }

        if (HealthSlider.value <= 0){
            health = 0;
        }
        HealthSlider.value = health;
     
    }

    //This method is to be accessed by the enemy scripts so that if their shooting raycast hits the player,
    //they can call this method attached to the player
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }


}

