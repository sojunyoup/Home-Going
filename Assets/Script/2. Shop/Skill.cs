using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillGrade { NOMAL, EPIC, UNIQUE, LEGENDARY}
[System.Serializable]
public class Skill
{
    public string skillName;
    public Sprite skillImage;
    public SkillGrade skillGrade;
    public int weight;
    public bool isTrue = false;
    public Skill(Skill skill)
    {
        this.skillName = skill.skillName;
        this.skillImage = skill.skillImage;
        this.skillGrade = skill.skillGrade;
        this.weight = skill.weight;
        this.isTrue = skill.isTrue;
    }
}
