using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSimple : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody2D rb;
    private Vector2 movementDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        Vector3 moveRight = transform.right * movementDir.x;
        Vector3 moveUp = transform.up * movementDir.y;

        Vector3 move = transform.position + ((moveRight + moveUp) * movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(move);
    }

    void Update()
    {
        movementDir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementDir.y = 1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementDir.x = -1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementDir.y = -1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementDir.x = 1.0f;
        }
    }
}