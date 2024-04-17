using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretHealth : MonoBehaviour
{
    public float health = 1.0f;

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

    void ApplyDamage(float Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            if (boss)
            {
                boss.SendMessage("turretDestroyed");
            }

            Destroy(gameObject);
        }
    }
}
