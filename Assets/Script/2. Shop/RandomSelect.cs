using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RandomSelect : MonoBehaviour
{
    public GameObject SkillBuyUi;
    public Text GoldUI;
    public Image SkillBuyImage;
    public List<Skill> deck = new List<Skill>();
    public int total = 0;

    public Image[] nomal;
    public Image[] epic;
    public Image[] unique;
    public Image[] legendary;

    public GameObject[] nomalImage;
    public GameObject[] epicImage;
    public GameObject[] uniqueImage;
    public GameObject[] legendaryImage;

    private int nomalNum = 0;
    private int epicNum = 0;
    private int uniqueNum = 0;
    private int legendaryNum = 0;

    void Start()
    {
        nomalNum = 0;
        epicNum = 0;
        uniqueNum = 0;
        legendaryNum = 0;

        if (!GameManager.Instance.BasicSkill)
        {
            GameManager.Instance.Result.Add(new Skill(deck[0]));
            GameManager.Instance.Result.Add(new Skill(deck[2]));
            GameManager.Instance.BasicSkill = true;
        }

        for (int i = 0; i < deck.Count; i++)
        {
            total += deck[i].weight;

            for(int j = 0; j < GameManager.Instance.Result.Count; j++)
            {
                if(GameManager.Instance.Result[j].skillName == deck[i].skillName)
                {
                    deck[i].isTrue = true;

                    if (deck[i].skillGrade == SkillGrade.NOMAL && deck[i].isTrue == true)
                    {
                        nomal[nomalNum].sprite = deck[i].skillImage;
                        nomalImage[nomalNum].gameObject.tag = "InSkill";
                        nomalImage[nomalNum].GetComponent<DragDrop>().SkillName = deck[i].skillName;
                        nomalImage[nomalNum].GetComponent<DragDrop>().Cooltime = deck[i].Cool;
                        nomalNum++;
                    }
                    else if (deck[i].skillGrade == SkillGrade.EPIC && deck[i].isTrue == true)
                    {
                        epic[epicNum].sprite = deck[i].skillImage;
                        epicImage[epicNum].gameObject.tag = "InSkill";
                        epicImage[epicNum].GetComponent<DragDrop>().SkillName = deck[i].skillName;
                        epicImage[epicNum].GetComponent<DragDrop>().Cooltime = deck[i].Cool;
                        epicNum++;
                    }
                    else if (deck[i].skillGrade == SkillGrade.UNIQUE && deck[i].isTrue == true)
                    {
                        unique[uniqueNum].sprite = deck[i].skillImage;
                        uniqueImage[uniqueNum].gameObject.tag = "InSkill";
                        uniqueImage[uniqueNum].GetComponent<DragDrop>().SkillName = deck[i].skillName;
                        uniqueImage[uniqueNum].GetComponent<DragDrop>().Cooltime = deck[i].Cool;
                        uniqueNum++;
                    }
                    else if (deck[i].skillGrade == SkillGrade.LEGENDARY && deck[i].isTrue == true)
                    {
                        legendary[legendaryNum].sprite = deck[i].skillImage;
                        legendaryImage[legendaryNum].gameObject.tag = "InSkill";
                        legendaryImage[legendaryNum].GetComponent<DragDrop>().SkillName = deck[i].skillName;
                        legendaryImage[legendaryNum].GetComponent<DragDrop>().Cooltime = deck[i].Cool;
                        legendaryNum++;
                    }
                }
            }
        }
        
    }
    public void ResultSelect()
    {
        int isFull = 0;
        for(int i = 0; i < deck.Count; i++)
        {
            if (deck[i].isTrue)
                isFull++;
        }
        if (isFull < deck.Count)
        {
            if (GameManager.Instance.Gold >= 100)
            {
                SkillBuyUi.gameObject.SetActive(true);
                Skill n = RandomSkill();
                SkillBuyImage.sprite = n.skillImage;
                GameManager.Instance.Result.Add(n);
                GameManager.Instance.Gold -= 100;
            }
        }
    }

    public Skill RandomSkill()
    {
        int weight = 0;
        int selectNum = 0;

        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for (int i = 0; i < deck.Count; i++)
        {
            weight += deck[i].weight;
            if (selectNum <= weight)
            {
                Skill temp = new Skill(deck[i]);
                if (deck[i].isTrue == true)
                {
                    continue;
                }
                deck[i].isTrue = true;
                if (deck[i].skillGrade == SkillGrade.NOMAL)
                {
                    GameManager.Instance.nomal = GameManager.Instance.nomal + 1;
                    nomal[nomalNum].sprite = deck[i].skillImage;
                    nomalImage[nomalNum].gameObject.tag = "InSkill";
                    nomalImage[nomalNum].GetComponent<DragDrop>().SkillName = deck[i].skillName; 
                    nomalImage[nomalNum].GetComponent<DragDrop>().Cooltime = deck[i].Cool; 
                    nomalNum++;
                }
                else if (deck[i].skillGrade == SkillGrade.EPIC)
                {
                    GameManager.Instance.epic = GameManager.Instance.epic + 1;
                    epic[epicNum].sprite = deck[i].skillImage;
                    epicImage[epicNum].gameObject.tag = "InSkill";
                    epicImage[epicNum].GetComponent<DragDrop>().SkillName = deck[i].skillName;
                    epicImage[epicNum].GetComponent<DragDrop>().Cooltime = deck[i].Cool; 
                    epicNum++;
                }
                else if (deck[i].skillGrade == SkillGrade.UNIQUE)
                {
                    GameManager.Instance.unique = GameManager.Instance.unique + 1;
                    unique[uniqueNum].sprite = deck[i].skillImage;
                    uniqueImage[uniqueNum].gameObject.tag = "InSkill";
                    uniqueImage[uniqueNum].GetComponent<DragDrop>().SkillName = deck[i].skillName;
                    uniqueImage[uniqueNum].GetComponent<DragDrop>().Cooltime = deck[i].Cool; 
                    uniqueNum++;
                }
                else if (deck[i].skillGrade == SkillGrade.LEGENDARY)
                {
                    GameManager.Instance.legendary = GameManager.Instance.legendary + 1;
                    legendary[legendaryNum].sprite = deck[i].skillImage;
                    legendaryImage[legendaryNum].gameObject.tag = "InSkill";
                    legendaryImage[legendaryNum].GetComponent<DragDrop>().SkillName = deck[i].skillName;
                    legendaryImage[legendaryNum].GetComponent<DragDrop>().Cooltime = deck[i].Cool; 
                    legendaryNum++;
                }
                return temp;
            }
        }
        return null;
    }
    private void Update()
    {
        GoldUI.text = GameManager.Instance.Gold.ToString();
    }
}
