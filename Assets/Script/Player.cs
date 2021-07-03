using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [Header("Punch")]
    [SerializeField] private GameObject Coll_Punch_1;
    [SerializeField] private GameObject[] Coll_Punch_2;
    [SerializeField] private GameObject[] Coll_Punch_3;

    [Header("Kick")]
    [SerializeField] private GameObject Coll_Kick_1;
    [SerializeField] private GameObject[] Coll_Kick_2;
    [SerializeField] private GameObject[] Coll_Kick_3;

    [Header("Fire")]
    [SerializeField] private GameObject Fire1;

    private int Punch_2_Count = 0;
    private int Punch_3_Count = 0;

    private int Kick_2_Count = 0;
    private int Kick_3_Count = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Punch_1()
    {
        animator.SetTrigger("Punch_1");
    }

    public void Punch_2()
    {
        Coll_Punch_2[4].SetActive(false);
        Coll_Punch_2[4].SetActive(true);
    }

    public void Punch_3()
    {
        Coll_Punch_3[4].SetActive(false);
        Coll_Punch_3[4].SetActive(true);
    }

    public void Kick_1()
    {
        animator.SetTrigger("Kick_1");
    }

    public void Kick_2()
    {
        Coll_Kick_2[4].SetActive(false);
        Coll_Kick_2[4].SetActive(true);
    }

    public void Kick_3()
    {
        Coll_Kick_3[4].SetActive(false);
        Coll_Kick_3[4].SetActive(true);
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

    void ATK_Punch_2()
    {
        switch (Punch_2_Count)
        {
            case 0:
                ATK_Punch_2_Coll();
                break;
            case 1:
                ATK_Punch_2_Coll();
                break;
            case 2:
                ATK_Punch_2_Coll();
                break;
            case 3:
                ATK_Punch_2_Coll();
                Punch_2_Count = 0;
                break;
            default:
                break;
        }
    }

    void ATK_Punch_3()
    {
        switch(Punch_3_Count)
        {
            case 0:
                ATK_Punch_3_Coll();
                break;
            case 1:
                ATK_Punch_3_Coll();
                break;
            case 2:
                ATK_Punch_3_Coll();
                break;
            case 3:
                ATK_Punch_3_Coll();
                Punch_3_Count = 0;
                break;
            default:
                break;
        }
    }

    void ATK_Punch_2_Coll()
    {
        Coll_Punch_2[Punch_2_Count].SetActive(true);
        Punch_2_Count++;
    }

    void ATK_Punch_3_Coll()
    {
        Coll_Punch_3[Punch_3_Count].SetActive(true);
        Punch_3_Count++;
    }

    void ATK_Kick_1()
    {
        Coll_Kick_1.SetActive(true);
    }

    void ATK_Kick_2()
    {
        switch (Kick_2_Count)
        {
            case 0:
                ATK_Kick_2_Coll();
                break;
            case 1:
                ATK_Kick_2_Coll();
                break;
            case 2:
                ATK_Kick_2_Coll();
                break;
            case 3:
                ATK_Kick_2_Coll();
                Kick_2_Count = 0;
                break;
            default:
                break;
        }
    }

    void ATK_Kick_3()
    {
        switch (Kick_3_Count)
        {
            case 0:
                ATK_Kick_3_Coll();
                break;
            case 1:
                ATK_Kick_3_Coll();
                break;
            case 2:
                ATK_Kick_3_Coll();
                break;
            case 3:
                ATK_Kick_3_Coll();
                Kick_3_Count = 0;
                break;
            default:
                break;
        }
    }

    void ATK_Kick_2_Coll()
    {
        Coll_Kick_2[Kick_2_Count].SetActive(true);
        Kick_2_Count++;
    }

    void ATK_Kick_3_Coll()
    {
        Coll_Kick_3[Kick_3_Count].SetActive(true);
        Kick_3_Count++;
    }
}
