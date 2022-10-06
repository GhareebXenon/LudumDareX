using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour 
{
    public float duration = 1f;
    public AnimationCurve animCurv;

    void Start()
    {

        
    }

  
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Shaking());
        }


    }
    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime  < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = animCurv.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;



    }
}
