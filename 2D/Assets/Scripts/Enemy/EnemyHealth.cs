using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 1.0f;

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
            Destroy(gameObject);
        }
    }
}
