using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase1Boss : MonoBehaviour
{
    public float maxHealth = 100;
    public float spawnRate = 10.0f;
    public float spawnRange = 10.0f;
    public float flashSpeed = 1.0f;
    public Color flashColor = Color.red;
    public int turretsToKill = 10;
    public GameObject turretSpawnPrefab;

    private bool inv = true;
    private float health;
    private GameObject player;
    private int turretsDestroyed = 0;
    private float spawnTimer = 0.0f;
    private SpriteRenderer sp;
    private float flashTimer = 0.0f;
    private Color defColor;

    void Start()
    {
        health = maxHealth;
        player = GameObject.Find("Player");
        sp = GetComponent<SpriteRenderer>();
        defColor = sp.color;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0.0f;
            
            GameObject.Instantiate(turretSpawnPrefab, new Vector3(gameObject.transform.position.x + Random.Range(-spawnRange, spawnRange), gameObject.transform.position.y + Random.Range(-spawnRange, spawnRange), 0.0f), 
               new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        }

        flashTimer += Time.deltaTime;

        if (flashTimer >= flashSpeed && !inv)
        {
            flashTimer = 0.0f;
            if (sp.color == defColor)
            {
                sp.color = flashColor;
            }
            else
            {
                sp.color = defColor;
            }
        }
    }

    void turretDestroyed()
    {
        turretsDestroyed++;
        if(turretsDestroyed >= turretsToKill)
        {
            if (inv)
            {
                inv = false;
                gameObject.layer = LayerMask.NameToLayer("Enemy");
            }
        }
    }

    void ApplyDamage(float damage)
    {
        if (!inv)
        {
            health--;

            if (health <= 0)
            {
                death();
            }
        }
    }

    void death()
    {
        Debug.Log("dead");
    }
}
