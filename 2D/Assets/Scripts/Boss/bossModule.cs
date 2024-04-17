using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossModule : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float spawnRate = 1.0f;
    public GameObject enemyPrefab;

    private float health;
    private GameObject player;
    private GameObject boss;
    private float spawnTimer = 0.0f;

    void Start()
    {
        health = maxHealth;
        player = GameObject.Find("Player");
        boss = GameObject.Find("phase2Boss");
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnRate)
        {
            spawnTimer = 0.0f;
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }

    void ApplyDamage(float Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            death();
        }
    }

    void death()
    {
        boss.SendMessage("moduleDestroyed", gameObject.name);
        Destroy(gameObject); 
    }
}