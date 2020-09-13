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
    [SerializeField]
    protected Critter owner;

    protected Animator anim;

    public string GetSkillName
    {
        get
        {
            return skillName;
        }
    }

    public string GetDescription
    {
        get
        {
            return description;
        }
    }

    public Action OnSkill;
    public abstract void Setup(Critter owner);

    public abstract void SetupSkill();

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
}




public enum SkillType
{
    AttackSkill,
    SupportSkill
}
