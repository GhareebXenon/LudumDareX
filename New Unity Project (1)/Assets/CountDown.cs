using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float TimeStart = 10;
    public Text textBox;
    public GameObject player;


   
    void Start()
    {

        textBox.text = TimeStart.ToString(); 
    }

    void Update()
    {
        if (TimeStart > 0)
        {
            TimeStart -= Time.deltaTime;
        }
        textBox.text = Mathf.Round(TimeStart).ToString();
        if (TimeStart < 0)
        {
            GameObject.Destroy(player);
        }

    }
}
