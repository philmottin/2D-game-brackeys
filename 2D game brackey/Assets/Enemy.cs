using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public GameObject deathEffect;


    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die() {
        GameObject de = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(de, 1f);
        Destroy(gameObject);
    }
}
