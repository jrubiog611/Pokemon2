using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    protected string skillName;
    [SerializeField]
    protected SkillType skillType;
    [SerializeField]
    protected Affinity skillAffinity;
    //[SerializeField]
    protected float skillPower;
    [SerializeField]
    protected string description;


    public Action OnSkill;
    public abstract void Setup();
}




public enum SkillType
{
    AttackSkill,
    SupportSkill
}
