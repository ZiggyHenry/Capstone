using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 1.0f;

    public GameObject pickup;
    public GameObject dmgText;
    public float textRange = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void ApplyDamage(float damage)
    {
        GameObject Text = Instantiate(dmgText, new Vector2(transform.position.x + Random.Range(-textRange, textRange), transform.position.y + Random.Range(-textRange, textRange)), Quaternion.identity);
        Text.GetComponent<TMP_Text>().text = "-" + damage.ToString();

        if (health - damage <= 0) //crappy code look below
        {
            Text.GetComponent<TMP_Text>().color = Color.red;
        }

        Damage(damage);
    }

    void Damage(float damage)
    {
        health -= damage;
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
