using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public float fireRate = 1.0f;
    public float bulletSpeed = 1.0f;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpread = 3.0f;

    private float fireTimer = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        
        if (fireTimer >= fireRate)
        {
            fireTimer = 0.0f;

            Quaternion rotation = transform.rotation * Quaternion.Euler(0.0f, 0.0f, 90.0f); //rotation of the bullet, change later??
            GameObject obj = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, rotation);

            Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
            objRb.AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
