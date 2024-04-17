using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifespan = 1.0f;

    private float lifeTimer = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer >= lifespan)
        {
            Destroy(gameObject);
        }
    }
}
