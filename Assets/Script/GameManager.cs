using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;
    public int nomal = 0, epic = 0, unique = 0, legendary = 0;
    public List<Skill> Result = new List<Skill>();
    public string[] name;
    public int nameNum = 0;
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
    
}
