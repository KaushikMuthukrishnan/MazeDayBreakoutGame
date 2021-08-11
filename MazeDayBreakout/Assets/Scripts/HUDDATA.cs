using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDATA : MonoBehaviour
{
    public float health = 100;
    public Text HealthText;
    public Slider HealthSlider;
    public GameObject Player;
    public GameObject Maincam;
    
    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
         
       

    }

    void Update()
    {
        HealthText.text = "" + health + "%";
        DamageIndicator();
        if (health <= 0)
        {
    
            StartCoroutine(Die());
        }
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


    IEnumerator Die()   //This method is called when the player dies
    {

//disable each child object in the player prefab
        foreach (Transform child in Player.transform)
        {
            child.gameObject.SetActive(false);
        }

 GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;

   yield return new WaitForSeconds(1);








    }

}

