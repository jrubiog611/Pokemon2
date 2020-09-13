using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Critter : MonoBehaviour
{
    [Header("Name")]
    [SerializeField]
    private string critterName;

    [Header("Base Stats")]
    [SerializeField]
    [Range(10,100)]
    private float baseAtk;
    [SerializeField]
    [Range(10, 100)]
    private float baseDef;
    [SerializeField]
    [Range(1, 50)]
    private float baseSpd;
    [SerializeField]
    private float baseHp;

    private float atkMod, defMod, spdMod;

    [Header("Affinity")]
    [SerializeField]
    private Affinity affinity;


    [Header("Skill Set")]
    //[SerializeField]
    //private SkillSet skills;
    public SkillSet skillList;
    [HideInInspector]
    public Player Owner;

   public Affinity Affinity
    {
        get
        {
            return affinity;
        }
    }

    public float BaseHp
    {
        get
        {
            return baseHp;
        }
    }
    public float BaseAtk
    {
        get
        {
            return baseAtk + atkMod;
        }
    }
    public float BaseSpd
    {
        get
        {
            return baseSpd + spdMod;
        }
    }
    public float BaseDef
    {
        get
        {
            return baseDef + defMod;
        }
    }

    public void ModifyAtk(int amount)
    {
        atkMod += baseAtk * amount/100f;
    }

    public void ModifyDef(int amount)
    {
        defMod += baseDef * amount / 100f;
    }
    public void ModifySpd(int amount)
    {
        spdMod += baseSpd * amount / 100f;
    }
    void Awake()
    {
        skillList.SetupAllSkills();
    }

}

public enum Affinity
{
    Dark,
    Light,
    Fire,
    Water,
    Wind,
    Earth
}