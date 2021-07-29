using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//instead of a numerical health system, what if we just added some visual FX to simplify it.
//Like adding blood splatters that fade overtime, and more splatters means less health, kinda like COD
//could dsimplify the health process instead of adding numbers and damage points and health regen, etc yk?
public class HUDDATA : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    public float stamina = 100;
    public float health1;
    public bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //DECREASE HEALTH when c is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            health -= 1;
            Debug.Log("OUCH");

        }
        DamageIndicator();
    }
    public void DamageIndicator()
    {

        if (health > health1)
        {
            Debug.Log("Health: " + health);
            health1 = health;
        }


    }


}

