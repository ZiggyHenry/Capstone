using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBox : MonoBehaviour
{
    public List<GameObject> circles;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void SetHealth(int health)
    {
        health--;
        for (int i = 0; i < circles.Count; i++)
        {
            bool enable = false;
            if (i <= health)
            {
                enable = true;
            }
            circles[i].SetActive(enable);
        }
    }
}
