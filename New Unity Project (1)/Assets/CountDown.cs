using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public float TimeStart = 10;
    public Text textBox;
    public GameObject player;
    public GameObject button;


   
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
            button.SetActive(true);

        }

    }
    public void ReStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
