using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFire : MonoBehaviour
{
    public float firerate = 1.0f;
    public float spinRate = 1.0f;
    public float bulletSpeed = 10.0f;
    public float bulletSize = 0.5f;
    public GameObject bulletPrefab;

    private float fireTimer = 0.0f;
    private int diagonal = 1;

    void Start()
    {

    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= firerate)
        {
            fireTimer = 0.0f;

             GameObject obj = Instantiate(bulletPrefab, transform.position, transform.rotation);
             Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
             objRb.AddForce(obj.transform.right * bulletSpeed, ForceMode2D.Impulse);

             obj.transform.localScale = new Vector3(bulletSize, bulletSize, 1.0f);
        }

        transform.rotation = transform.rotation * Quaternion.Euler(0.0f, 0.0f, spinRate);
    }
}
