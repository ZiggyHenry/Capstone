using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        pickUp(collision);
        Destroy(gameObject);
    }

    public void pickUp(Collision2D collision) 
    {
        collision.gameObject.SendMessage(message);
    }
}
