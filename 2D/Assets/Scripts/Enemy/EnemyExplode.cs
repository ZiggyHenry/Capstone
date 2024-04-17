using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    public GameObject target;
    public GameObject explosion;
    public float maxHealth = 5.0f;

    private float health;

    void Start()
    {
        if (!target)
        {
            target = GameObject.Find("Player");
        }

        health = maxHealth;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == target)
        {
            Explode();
        }
    }

    void ApplyDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        GameObject.Instantiate(explosion, gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        Destroy(gameObject);
    }
}
