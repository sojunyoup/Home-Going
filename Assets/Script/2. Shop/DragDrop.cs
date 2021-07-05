using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerClickHandler
{
    //스킬 이름
    public string SkillNamae;

    //Grade : 1 = 노말, 2 = 에픽, 3 = 유니크, 4 = 레전드리;
    public int Grade;

    //몇번째칸에 스킬이 있는지
    public int SkillNum;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(gameObject.tag == "InSkill" && GameManager.Instance.nameNum < 6)
        {
            if (eventData.button == PointerEventData.InputButton.Left) {
                GameManager.Instance.name[GameManager.Instance.nameNum] = SkillNamae;
                //gameObject.tag = "noSkill";
                GameManager.Instance.nameNum += 1;
            }
        }
    }
}
