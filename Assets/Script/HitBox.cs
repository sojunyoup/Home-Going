using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect { NONE, NORMAL, STRONG }


public class HitBox : MonoBehaviour
{
    [SerializeField] private Effect EffectState;
    [SerializeField] private GameObject HitEffect;
    [SerializeField] private GameObject HitEffect_1;
    [SerializeField] private GameObject HitEffect_2;

    public int Damage = 0;

    bool isEffect = true;

    private void Start()
    {
        switch (EffectState)
        {
            case Effect.NONE:
                isEffect = false;
                break;
            case Effect.NORMAL:
                HitEffect = HitEffect_1;
                break;
            case Effect.STRONG:
                HitEffect = HitEffect_2;
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isEffect) Destroy(Instantiate(HitEffect, gameObject.transform.position, Quaternion.identity),0.5f);
        gameObject.SetActive(false);
    }
}
