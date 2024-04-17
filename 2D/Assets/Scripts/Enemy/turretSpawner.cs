using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretSpawner : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject turret;

    private float spawnTime;
    void Start()
    {
        
    }

    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= timeToSpawn)
        {
            spawnTime = 0.0f;
            GameObject.Instantiate(turret, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}