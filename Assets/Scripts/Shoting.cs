using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{

    public Transform firePoint;
    public Transform blowPoint;
    public GameObject bulletPrefab;
    public GameObject fireBlow;
    public float bulletForce;
    public int bulletNo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletNo > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject blow = Instantiate(fireBlow, blowPoint.position, blowPoint.rotation);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        bulletNo--;
        
        Destroy(blow, 0.1f);
    }


}
