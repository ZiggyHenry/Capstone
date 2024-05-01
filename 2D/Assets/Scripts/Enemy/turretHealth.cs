using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretHealth : EnemyHealth
{
    private GameObject boss;

    void Start()
    {
        if (GameObject.Find("phase1Boss"))
        {
            boss = GameObject.Find("phase1Boss");
        }
    }

    void Update()
    {

    }

    void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (boss)
            {
                boss.SendMessage("turretDestroyed");
            }

            death();
        }
    }
}
