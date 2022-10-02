using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float TimeStart = 10;
    public Text textBox;



   
    void Start()
    {

        textBox.text = TimeStart.ToString(); 
    }

    void Update()
    {
        TimeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(TimeStart).ToString();
    }
}
