using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
  //  public Animator animator;
    public int damage = 40;
    public GameObject raycastImpactEffect;
    public LineRenderer line;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        } else if (Input.GetButtonDown("Fire2")) {            
            StartCoroutine(ShootRaycast());
        }

        
    }

    void Shoot() {
       // animator.SetTrigger("Shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator ShootRaycast() {
       // animator.SetTrigger("Shoot");
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        

        if (hitInfo) {
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, hitInfo.point);
            //Debug.Log(hitInfo.transform.name);
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }

            GameObject rc = Instantiate(raycastImpactEffect, hitInfo.point, Quaternion.identity);
            Destroy(rc, 1f);

        } else {
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.right * 100); ;
        }

        line.enabled = true;

        // wait 1 frame
        //yield return 0;
        yield return new WaitForSeconds(0.1f);

        line.enabled = false;
    }
}
