using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 800)
		{
			GetComponent<Animator>().SetBool("isEnraged", true);
		}

		if (health <= 0)
		{
			GetComponent<Animator>().SetBool("isAlive", false);
			GetComponent<Animator>().SetTrigger("die");

			Invoke("Die",3f);
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
