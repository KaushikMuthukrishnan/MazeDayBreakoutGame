using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDATA : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    // public float stamina = 100;
    public bool damaged = false;
    public Text HealthText;
    public Slider HealthSlider;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "" + health + "%";
        //DECREASE HEALTH when c is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            health -= 10;
            Debug.Log("OUCH");

        }
        DamageIndicator();
    }
    public void DamageIndicator()
    {
        HealthSlider.value = health;


    }


}

