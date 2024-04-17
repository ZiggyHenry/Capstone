using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float movementSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 newPosition = new Vector2(target.position.x, target.position.y);

        newPosition = Vector3.Lerp(transform.position, newPosition,
            movementSpeed * Time.deltaTime);

        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
