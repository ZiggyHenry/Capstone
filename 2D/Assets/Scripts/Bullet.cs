using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 1.0f;
    public float damage = 1.0f;

    private float time = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= lifespan)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("invincible")
            && collision.gameObject.layer != LayerMask.NameToLayer("eBullet")
            && collision.gameObject.layer != LayerMask.NameToLayer("pBullet"))
        {
            collision.gameObject.SendMessage("ApplyDamage", damage);
            Destroy(gameObject);
        }
    }
}
