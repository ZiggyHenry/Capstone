using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (!target)
        {
            target = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = transform.position - target.transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0.0f, 0.0f, angle),
            transform.rotation, Time.deltaTime);
    }
}