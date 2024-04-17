using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase2Boss : MonoBehaviour
{
    public float fireRate = 1.0f;

    private float fireTimer = 0.0f;
    private bool diagonal = false;

    void Start()
    {
        
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            
        }

        diagonal = !diagonal;
    }

    void moduleDestroyed(string moduleName)
    {
        print(moduleName + " destroyed");
    }
}
