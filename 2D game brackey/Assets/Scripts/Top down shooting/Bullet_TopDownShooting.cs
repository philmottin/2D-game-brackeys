using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_TopDownShooting : MonoBehaviour
{
    public GameObject bulletImpactEffect;


    private void OnCollisionEnter2D(Collision2D collision) {
        
        GameObject be = Instantiate(bulletImpactEffect, transform.position, Quaternion.identity);
        Destroy(be, 5f);
        Destroy(gameObject);

    }
}
