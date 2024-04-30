using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 1.0f;
    public float damage = 1.0f;

    public Color hitColor = new Color(1, 0, 0, 0.8f);

    float time = 0.0f;
    Collider2D collider;
    SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
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

            collider.enabled = false;
            sp.color = hitColor;
            time = lifespan - 0.0f;
        }
    }
}
