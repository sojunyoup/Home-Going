using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerClickHandler
{
    //스킬 이름
    public SKillName SkillName;

    //Grade : 1 = 노말, 2 = 에픽, 3 = 유니크, 4 = 레전드리;
    public int Grade;
    public int Cooltime;

    //몇번째칸에 스킬이 있는지
    public int SkillNum;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(gameObject.tag == "InSkill" && GameManager.Instance.nameNum < 6)
        {
            bool isCan = true;
            for(int i = 0; i < 6; i++)
            {
                if (GameManager.Instance.name[i] == SkillName)
                    isCan = false;
            }
            if (eventData.button == PointerEventData.InputButton.Left && isCan) {
                GameManager.Instance.name[GameManager.Instance.nameNum] = SkillName;
                GameManager.Instance.CoolTime[GameManager.Instance.nameNum] = Cooltime;
                //gameObject.tag = "noSkill";
                GameManager.Instance.nameNum += 1;
            }
        }
    }
}
