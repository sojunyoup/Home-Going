using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;

    [SerializeField] AudioSource audio;

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
    public bool isFinal = false;
    public bool isSound = true;
    public bool isSoundon = true;
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
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (isSoundon && !isSound)
        {
            audio.Play();
            isSound = true;
        }
        else if(!isSoundon && isSound)
        {
            audio.Pause();
            isSound = false;
        }
    }
}
