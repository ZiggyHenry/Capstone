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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pickUp(collision);
        Destroy(gameObject);
    }

    public void pickUp(Collider2D collision) 
    {
        collision.gameObject.SendMessage(message);
    }
}
