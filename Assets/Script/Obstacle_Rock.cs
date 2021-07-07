using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Obstacle_Rock : MonoBehaviour
{
    float fShaketime = 0;
    float fShakeScale = 0;

    public int Hp = 0;
    public int MaxHp = 0;

    [SerializeField] private Sprite[] Obstacle_Sprite;

    [SerializeField] private GameObject ResultImage;
    [SerializeField] private Image Obstacle_ResultSprite;
    [SerializeField] private Text Result_Damage;
    [SerializeField] private Text Result_lessHP;
    [SerializeField] private Text Result_GettinGold;
    [SerializeField] private Text Result_FullGold;


    SpriteRenderer renderer;
    Vector2 initialPosition;

    int GettinGold = 0;

    private void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        initialPosition = new Vector2(3.25f, 1.3f);
        Sprite_Set();
        Status_Set();
        GettinGold = 0;
    }

    private void Update()
    {
        if (fShaketime > 0)
        {
            transform.localPosition = Random.insideUnitCircle * fShakeScale + initialPosition;
            fShaketime -= Time.deltaTime;
        }
        else
        {
            fShaketime = 0.0f;
            transform.localPosition = initialPosition;
        }

        

        if (GameManager.Instance.Result_Window)
        {
            Debug.Log("wtf");
            ResultImage.SetActive(true);
            Obstacle_ResultSprite.sprite = Obstacle_Sprite[GameManager.Instance.Stage - 1];
            if(Hp <= 0) Hp = 0;

            Result_Damage.text = (MaxHp - Hp).ToString();
            Result_lessHP.text = Hp.ToString();
            Result_GettinGold.text = GettinGold.ToString();
            Result_FullGold.text = (GameManager.Instance.Gold + GettinGold).ToString();
        }
        if (Hp <= 0 && !GameManager.Instance.skillActive && !GameManager.Instance.Result_Window)
        {
            Hp = 0;
            GameManager.Instance.Result_Window = true;
            Debug.Log("hp 0");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        fShaketime = 0.05f;
        fShakeScale = 0.1f;
        Hp -= collision.gameObject.GetComponent<HitBox>().Damage;
        if(Random.Range(0, 3) == 0)
            GettinGold += Random.Range(1, 2);
    }

    void Sprite_Set()
    {
        renderer.sprite = Obstacle_Sprite[GameManager.Instance.Stage - 1];
    }

    void Status_Set()
    {
        switch(GameManager.Instance.Stage)
        {
            case 1:
                MaxHp = 30;
                break;
            case 2:
                MaxHp = 60;
                break;
            case 3:
                MaxHp = 250;
                break;
            case 4:
                MaxHp = 300;
                break;
            case 5:
                MaxHp = 400;
                break;
            default:
                break;
        }
        Hp = MaxHp;
    }

    public void GoShop()
    {
        ResultImage.SetActive(false);
        GameManager.Instance.Gold += GettinGold;
        if (Hp <= 0)
            GameManager.Instance.Stage++;
        Hp = MaxHp;
        GameManager.Instance.Result_Window = false;
        SceneManager.LoadScene("2. Shop");
    }

    public void ReStart()
    {
        ResultImage.SetActive(false);
        GameManager.Instance.Gold += GettinGold;
        if (Hp <= 0)
            GameManager.Instance.Stage++;
        Hp = MaxHp;
        GameManager.Instance.Result_Window = false;
        SceneManager.LoadScene("3. ingame");
    }
}
