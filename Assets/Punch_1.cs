using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
