using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Rock : MonoBehaviour
{
    float fShaketime = 0;
    float fShakeScale = 0;

    Vector2 initialPosition;

    private void Start()
    {
        initialPosition = new Vector2(2.79f, 1.3f);
    }

    private void Update()
    {
        if (fShaketime > 0)
        {
            transform.position = Random.insideUnitCircle * fShakeScale + initialPosition;
            fShaketime -= Time.deltaTime;
        }
        else
        {
            fShaketime = 0.0f;
            transform.position = initialPosition;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        fShaketime = 0.05f;
        fShakeScale = 0.05f;
        Debug.Log("악");
    }
}
