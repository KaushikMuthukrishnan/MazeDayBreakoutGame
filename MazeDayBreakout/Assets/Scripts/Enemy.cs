using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float damage = 5;
    public Animator deathAnim;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
            return;
        }
        //look at the player
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    private IEnumerator Shoot()
    {
        

        yield break;
    }

    private void Die()
    {
        deathAnim.Play("RobotDeath");
        Destroy(transform.gameObject);
    }
}

