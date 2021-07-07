using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClearSkill : MonoBehaviour, IPointerClickHandler
{
    //몇번째칸에 스킬이 있는지
    public int SkillNum;
    private Sprite first;

    void Awake()
    {
        first = gameObject.GetComponent<Image>().sprite;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (SkillNum == 5)
            {
                GameManager.Instance.name[SkillNum] = SKillName.NONE;
                GameManager.Instance.CoolTime[SkillNum] = 0;
            }
            else
            {
                for (int i = SkillNum; i < 6 - 1; i++)
                {
                    GameManager.Instance.name[i] = GameManager.Instance.name[i + 1];
                    if (i >= GameManager.Instance.nameNum - 2)
                    {
                        GameManager.Instance.name[i + 1] = SKillName.NONE;
                        GameManager.Instance.CoolTime[i + 1] = 0;
                    }
                }
            }
            if(GameManager.Instance.nameNum > 0)
            {
                GameManager.Instance.nameNum -= 1;
            }
        }
    }
    public void Update()
    {
        for (int j = 0; j < GameManager.Instance.Result.Count; j++)
        {
            if (GameManager.Instance.name[SkillNum] == SKillName.NONE)
            {
                gameObject.GetComponent<Image>().sprite = first;
            }
            else if (GameManager.Instance.name[SkillNum] == GameManager.Instance.Result[j].skillName)
            {
                gameObject.GetComponent<Image>().sprite = GameManager.Instance.Result[j].skillImage;
            }
            
        }
    }
}
