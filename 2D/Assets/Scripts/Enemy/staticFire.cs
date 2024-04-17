using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticFire : MonoBehaviour
{
    public float firerate = 1.0f;
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
            float direction = 45.0f * diagonal;

            for (int i = 0; i < 4; i++)
            {
                GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, direction));
                Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
                objRb.AddForce(obj.transform.right * bulletSpeed, ForceMode2D.Impulse);
                obj.transform.localScale = new Vector3(bulletSize, bulletSize, 1.0f);

                direction += 90.0f;
            }

            //is there a better way to do this? like with a bool somehow?
            if (diagonal == 1)
            {
                diagonal = 0;
            }
            else
            {
                diagonal = 1;
            }
        }
    }
}
