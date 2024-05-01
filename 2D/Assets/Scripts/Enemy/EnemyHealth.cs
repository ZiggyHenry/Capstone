using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 1.0f;

    public GameObject pickup;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void ApplyDamage(float Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            death();
        }
    }

    public void death()
    {
        if (pickup) Instantiate(pickup, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
