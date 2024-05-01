using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgNumber : MonoBehaviour
{
    public float lifespan = 0.25f;

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= lifespan)
        {
            Destroy(gameObject);
        }
    }
}
