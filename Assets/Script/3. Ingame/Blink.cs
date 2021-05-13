using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blink : MonoBehaviour
{
    public Image TouchUi;
    bool isBlink = true;
    void Start()
    {
    }

    void Update()
    {
        StartCoroutine(UiBlink());

    }

    IEnumerator UiBlink()
    {
        if (TouchUi.color.a <= 0)
        {
            isBlink = false;
        }
        else if(TouchUi.color.a >= 1)
        {
            isBlink = true;
        }
        while (isBlink)
        {
            TouchUi.color = new Color(TouchUi.color.r, TouchUi.color.g, TouchUi.color.b, TouchUi.color.a - 0.0009f);
            yield return new WaitForSeconds(0.1f);
        } 
        while (!isBlink)
        {
            TouchUi.color = new Color(TouchUi.color.r, TouchUi.color.g, TouchUi.color.b, TouchUi.color.a + 0.0009f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
