using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDATA : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    // public float stamina = 100;
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

        //Changed to E from D since it overlaps with WASD controls
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


}

