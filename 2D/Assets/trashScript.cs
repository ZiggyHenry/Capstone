using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class trashScript : MonoBehaviour
{
    TMP_Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetTrash(int trash)
    {
        textBox.text = "Plastics: " + trash;
    }
}
