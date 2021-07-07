using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;
    public int nomal = 0, epic = 0, unique = 0, legendary = 0;
    public List<Skill> Result = new List<Skill>();
    public SKillName[] name;
    public int[] CoolTime;
    public int nameNum = 0;

    public int Stage = 1;

    public int Gold = 0;

    public bool BasicSkill = false;
    public bool Result_Window = false;
    public bool skillActive = false;
    //public 

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) Gold += 50;
    }
}
