using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpactEffect;

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; // * Time.deltaTime;
        //rb.AddForce(transform.right*speed);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log(collision.name);
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }

        GameObject be = Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(be, 1f);
        Destroy(gameObject);
    }
}
