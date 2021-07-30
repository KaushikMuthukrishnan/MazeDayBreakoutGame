using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float damage = 5;
    private Transform player;
    public Animator deathAnim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Shoot());
    }

    void Update()
    {
        if (health <= 0)
        {
            StopCoroutine(Shoot());
            Die();
            return;
        }
        //look at the player
        transform.LookAt(player);
    }

    private IEnumerator Shoot()
    {
        while (health > 0)
        {
            Physics.Raycast
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
        yield break;
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

