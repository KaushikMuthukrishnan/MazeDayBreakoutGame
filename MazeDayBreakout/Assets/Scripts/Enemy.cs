using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float damage = 5;
    public Animator deathAnim;
    public Transform player;
    public ParticleSystem fireBurst;
    public Transform laserLight;

    private void Start()
    {

        //calls the shoot method at 2 second intervals, almost like a coroutine
        //the random.value is so all bots dont start firing at the same time
        InvokeRepeating("Shoot", Random.value, 1);
    }

    void Update()
    {
        //look at the player
        transform.LookAt(player);
        //turn light towards player
        //laserLight.LookAt(player);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(player.position, 2f);

    }
    private void Shoot()
    {
        if (health > 0)
        {
            //finds a random poin =t in the vicinity of player so robots arent lazer focused on player with each shot
            var randPoint = Random.insideUnitSphere * 2f;
            var target = player.position + randPoint;
            
            fireBurst.Play();

            Debug.DrawLine(transform.position, target, Color.white, 20);

            //checks to see if player was hit on raycast, causes damage if so
            if (Physics.Raycast(transform.position, target, out RaycastHit hit, 100, ~LayerMask.GetMask("Player", "EnvironmentalObjs")))
            {
                Debug.Log(hit.transform);
                Debug.Log("raycast hit");
                hit.transform.GetComponentInChildren<HUDDATA>().TakeDamage(10); //TODO change damage value if necessary
            }

        }
        else
        {
            CancelInvoke("Shoot");
            Die();
            return;
        }
    }

    private void Die()
    {
        deathAnim.Play("RobotDeath");
        Destroy(transform.gameObject);
    }

    //Similar to HUDDATA.takeDamage(), but for the enemy bots
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }
}

