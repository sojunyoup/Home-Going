using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject Collider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Punch_1()
    {
        animator.SetTrigger("Punch_1");
    }
    void Attack()
    {
        Collider.SetActive(true);
        Debug.Log("atk");
    }
}
