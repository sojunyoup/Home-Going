using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private GameObject HitEffect_1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(Instantiate(HitEffect_1, gameObject.transform.position, Quaternion.identity),0.5f);
        gameObject.SetActive(false);
    }
}
