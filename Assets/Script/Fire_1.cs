using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_1 : MonoBehaviour
{
    [SerializeField] private Collider2D collider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collider.enabled = false;
    }

    void Off()
    {
        gameObject.SetActive(false);
    }

    void Atk()
    {
        collider.enabled = true;
    }
}
