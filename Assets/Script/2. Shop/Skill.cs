using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SKillName { Punch_1, Punch_2, Punch_3, Kick_1, Kick_2, Kick_3, Fire, Lightning, Water, Exposive, Kaioken, Finish, NONE }
public enum SkillGrade { NOMAL, EPIC, UNIQUE, LEGENDARY, Hidden}
[System.Serializable]
public class Skill
{
    public SKillName skillName;
    public Sprite skillImage;
    public SkillGrade skillGrade;
    public int weight;
    public int Cool;
    public bool isTrue = false;
    public Skill(Skill skill)
    {
        this.skillName = skill.skillName;
        this.skillImage = skill.skillImage;
        this.skillGrade = skill.skillGrade;
        this.weight = skill.weight;
        this.Cool = skill.Cool;
        this.isTrue = skill.isTrue;
    }
}
