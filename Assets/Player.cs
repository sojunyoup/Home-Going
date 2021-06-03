using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject Coll_Punch_1;
    [SerializeField] private GameObject Coll_Kick_1;
    [SerializeField] private GameObject Fire1;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Punch_1()
    {
        animator.SetTrigger("Punch_1");
    }
    public void Kick_1()
    {
        animator.SetTrigger("Kick_1");
    }

    public void Fire_1()
    {
        animator.SetTrigger("Fire_1");
        Fire1.SetActive(true);
    }

    void ATK_Punch_1()
    {
        Coll_Punch_1.SetActive(true);
    }
    void ATK_Kick_1()
    {
        Coll_Kick_1.SetActive(true);
    }
}
