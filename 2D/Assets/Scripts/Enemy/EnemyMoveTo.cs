using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTo : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity = 4.0f;
    public float deactiveTime = 2.0f;
    public float damage = 2.0f;

    private bool active = true;
    private Rigidbody2D rb;
    private float deactiveTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (!target)
        {
            target = GameObject.Find("Player");
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (active)
        {
            rb.AddForce(-transform.right, ForceMode2D.Impulse);
        }
        else
        {
            deactiveTimer += Time.fixedDeltaTime;
            if (deactiveTimer >= deactiveTime)
            {
                active = true;
                deactiveTimer = 0.0f;
            }
        }

        clampLinearVelocity();
    }

    private void clampLinearVelocity()
    {
        if (rb.velocity.x > maxVelocity)
        {
            rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
        }

        if (rb.velocity.y > maxVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
        }

        if (rb.velocity.x < -maxVelocity)
        {
            rb.velocity = new Vector2(-maxVelocity, rb.velocity.y);
        }

        if (rb.velocity.y < -maxVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == target && active)
        {
            collision.gameObject.SendMessage("ApplyDamage", damage);
            active = false;
            rb.velocity = Vector2.zero;
        }
    }
}
