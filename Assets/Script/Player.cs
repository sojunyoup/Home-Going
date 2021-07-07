using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject SkillActive;
    public Button[] Btns;
    public Image[] CDIcons;
    public Image Limit;

    [Header("Punch")]
    [SerializeField] private GameObject Coll_Punch_1;
    [SerializeField] private GameObject[] Coll_Punch_2;
    [SerializeField] private GameObject[] Coll_Punch_3;
    private int Punch_2_Count = 0;
    private int Punch_3_Count = 0;

    [Header("Kick")]
    [SerializeField] private GameObject Coll_Kick_1;
    [SerializeField] private GameObject[] Coll_Kick_2;
    [SerializeField] private GameObject[] Coll_Kick_3;
    private int Kick_2_Count = 0;
    private int Kick_3_Count = 0;

    [Header("Fire")]
    [SerializeField] private GameObject Fire_Timeline;
    [SerializeField] private GameObject Fire_Coll;

    [Header("Lighting")]
    [SerializeField] private GameObject lighting;

    [Header("Explosive")]
    [SerializeField] private GameObject Expl_Coll;

    [Header("Finish")]
    [SerializeField] private GameObject Finish_IntroVideo;
    [SerializeField] private GameObject Finish_Outrovideo;
    [SerializeField] private GameObject Finish_Aura;
    [SerializeField] private GameObject Finish_Swing;
    [SerializeField] private GameObject Finish_Gather_1;
    [SerializeField] private GameObject Finish_Gather_2;
    [SerializeField] private GameObject Finish_Gather_2_2;
    bool isintro = false;
    bool isoutr = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        Button_Image();
    }

    private void Update()
    {
        CoolDown();
        Limit_Update();
        if (GameManager.Instance.Result_Window)
        { 
            transform.position = new Vector2(-4.9f, transform.position.y);
        }
    }

    private void LateUpdate()
    {
        if (Finish_IntroVideo.GetComponent<VideoPlayer>().isPlaying)
        {
            isintro = true;
        }
        if (Finish_Outrovideo.GetComponent<VideoPlayer>().isPlaying)
        {
            isoutr = true;
        }

        if (Finish_IntroVideo.activeSelf)
        {
            if (!Finish_IntroVideo.GetComponent<VideoPlayer>().isPlaying)
            {
                if (isintro == true)
                {
                    Debug.Log("hi");
                    animator.SetTrigger("Finish");

                    Finish_IntroVideo.SetActive(false);
                }
            }
        }

        if (Finish_Outrovideo.activeSelf)
        {
            if (!Finish_Outrovideo.GetComponent<VideoPlayer>().isPlaying)
            {
                if (isoutr == true)
                {
                    Finish_Outrovideo.SetActive(false);
                    SceneManager.LoadScene("1. Title");
                }
            }
        }
    }

    #region 스킬

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

    public void Fire()
    {
        Fire_Timeline.SetActive(false);
        Fire_Timeline.SetActive(true);
    }

    public void Lighting()
    {
        animator.SetTrigger("Lighting");
    }

    public void Water()
    {
        animator.SetTrigger("Water");
    }

    public void Explosive()
    {
        animator.SetTrigger("Explosive");
    }

    public void Finish()
    {
        Finish_IntroVideo.SetActive(true);
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

    void ATK_Lighting_Coll()
    {
        lighting.SetActive(true);
    }

    void ATK_Fire_Coll()
    {
        Fire_Coll.SetActive(true);
    }

    void Explosive_PosSet()
    {
        transform.position = new Vector2(1.97f, -4.09f);
    }

    void Explosive_Coll()
    {
        Expl_Coll.SetActive(true);
    }

    void PosZero()
    {
        transform.position = new Vector2(0, transform.position.y);
    }

    void PosOrigin()
    {
        transform.position = new Vector2(-2.51f, -2.91f);
    }

    void AuraOn_Finish()
    {
        Finish_Aura.SetActive(true);
    }

    void AuraOff_Finish()
    {
        Finish_Aura.SetActive(false);
        Finish_Outrovideo.SetActive(true);
    }

    void CreateGather_1_Finish()
    {
        Destroy(Instantiate(Finish_Gather_1, Finish_Gather_1.transform.position, Quaternion.identity), 1.25f);
    }

    void CreateGather_2_Finish()
    {
        Destroy(Instantiate(Finish_Gather_2, Finish_Gather_2.transform.position, Quaternion.identity), 2.1f);
        Destroy(Instantiate(Finish_Gather_2_2, Finish_Gather_2_2.transform.position, Quaternion.identity), 2.1f);
    }

    void Swing_Finish()
    {
        Destroy(Instantiate(Finish_Swing, Finish_Swing.transform.position, Quaternion.identity), 0.5f);
    }


    #endregion

    #region Button

    bool isCooldown_1 = false;
    bool isCooldown_2 = false;
    bool isCooldown_3 = false;
    bool isCooldown_4 = false;
    bool isCooldown_5 = false;
    bool isCooldown_6 = false;

    public void Button1()
    {
        CDIcons[0].raycastTarget = true;
        CDIcons[0].fillAmount = 1;
        Button_Num(GameManager.Instance.name[0]);
        isCooldown_1 = true;
    }

    public void Button2()
    {
        CDIcons[1].raycastTarget = true;
        CDIcons[1].fillAmount = 1;
        Button_Num(GameManager.Instance.name[1]);
        isCooldown_2 = true;
    }

    public void Button3()
    {
        CDIcons[2].raycastTarget = true;
        CDIcons[2].fillAmount = 1;
        Button_Num(GameManager.Instance.name[2]);
        isCooldown_3 = true;
    }

    public void Button4()
    {
        CDIcons[3].raycastTarget = true;
        CDIcons[3].fillAmount = 1;
        Button_Num(GameManager.Instance.name[3]);
        isCooldown_4 = true;
    }

    public void Button5()
    {
        CDIcons[4].raycastTarget = true;
        CDIcons[4].fillAmount = 1;
        Button_Num(GameManager.Instance.name[4]);
        isCooldown_5 = true;
    }

    public void Button6()
    {
        CDIcons[5].raycastTarget = true;
        CDIcons[5].fillAmount = 1;
        Button_Num(GameManager.Instance.name[5]);
        isCooldown_6 = true;
    }

    public void Button_Num(SKillName num)
    {
        switch (num)
        {
            case SKillName.Punch_1:
                Punch_1();
                break;
            case SKillName.Punch_2:
                Punch_2();
                break;
            case SKillName.Punch_3:
                Punch_3();
                break;
            case SKillName.Kick_1:
                Kick_1();
                break;
            case SKillName.Kick_2:
                Kick_2();
                break;
            case SKillName.Kick_3:
                Kick_3();
                break;
            case SKillName.Fire:
                Fire();
                break;
            case SKillName.Lightning:
                Lighting();
                break;
            case SKillName.Water:
                Water();
                break;
            case SKillName.Exposive:
                Explosive();
                break;
            case SKillName.Kaioken:

                break;
            case SKillName.Finish:
                Finish();
                break;
            case SKillName.NONE:
                break;
            default:
                break;
        }
    }

    void Button_Image()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < GameManager.Instance.Result.Count; j++)
            {
                if (GameManager.Instance.name[i] == GameManager.Instance.Result[j].skillName)
                {
                    Btns[i].GetComponent<Image>().sprite = GameManager.Instance.Result[j].skillImage;
                }
            }
        }

    }

    void CoolDown()
    {
        if(isCooldown_1 == true)
        {
            CDIcons[0].fillAmount -= 1 / (float)GameManager.Instance.CoolTime[0] * Time.deltaTime;
            if(CDIcons[0].fillAmount <= 0)
            {
                CDIcons[0].fillAmount = 0;
                isCooldown_1 = false;
                CDIcons[0].raycastTarget = false;
            }
        }
        if (isCooldown_2 == true)
        {
            CDIcons[1].fillAmount -= 1 / (float)GameManager.Instance.CoolTime[1] * Time.deltaTime;
            if (CDIcons[1].fillAmount <= 0)
            {
                CDIcons[1].fillAmount = 0;
                isCooldown_2 = false;
                CDIcons[1].raycastTarget = false;
            }
        }
        if (isCooldown_3 == true)
        {
            CDIcons[2].fillAmount -= 1 / (float)GameManager.Instance.CoolTime[2] * Time.deltaTime;
            if (CDIcons[2].fillAmount <= 0)
            {
                CDIcons[2].fillAmount = 0;
                isCooldown_3 = false;
                CDIcons[2].raycastTarget = false;
            }
        }
        if (isCooldown_4 == true)
        {
            CDIcons[3].fillAmount -= 1 / (float)GameManager.Instance.CoolTime[3] * Time.deltaTime;
            if (CDIcons[3].fillAmount <= 0)
            {
                CDIcons[3].fillAmount = 0;
                isCooldown_4 = false;
                CDIcons[3].raycastTarget = false;
            }
        }
        if (isCooldown_5 == true)
        {
            CDIcons[4].fillAmount -= 1 / (float)GameManager.Instance.CoolTime[4] * Time.deltaTime;
            if (CDIcons[4].fillAmount <= 0)
            {
                CDIcons[4].fillAmount = 0;
                isCooldown_5 = false;
                CDIcons[4].raycastTarget = false;
            }
        }
        if (isCooldown_6 == true)
        {
            CDIcons[5].fillAmount -= 1 / (float)GameManager.Instance.CoolTime[5] * Time.deltaTime;
            if (CDIcons[5].fillAmount <= 0)
            {
                CDIcons[5].fillAmount = 0;
                isCooldown_6 = false;
                CDIcons[5].raycastTarget = false;
            }
        }

    }
    #endregion


    void IsSkillActive()
    {
        SkillActive.SetActive(true);
        GameManager.Instance.skillActive = true;
        Debug.Log("active");
    }
    void IsSkillActiveEnd()
    {
        SkillActive.SetActive(false);
        GameManager.Instance.skillActive = false;
        Debug.Log("end");
    }

    void Limit_Update()
    {
        if(!GameManager.Instance.Result_Window)
            Limit.fillAmount -= 1 / 30f * Time.deltaTime;
        if (Limit.fillAmount <= 0 && !GameManager.Instance.skillActive && !GameManager.Instance.Result_Window)
        { 
            GameManager.Instance.Result_Window = true;
            Limit.fillAmount = 1;
            transform.position = new Vector2(-4.9f, transform.position.y);
        }
    }
}
