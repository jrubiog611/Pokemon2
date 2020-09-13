using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SkillSet : MonoBehaviour
{
    [SerializeField]
    private Skill skill1;
    [SerializeField]
    private Skill skill2;
    [SerializeField]
    private Skill skill3;

    private Critter owner;

    private List<Skill> skills = new List<Skill>();

    public List<Skill> Skills
    {
        get
        {
            return skills;
        }
         
    }


    public void SetupAllSkills()
    {
        owner = transform.GetComponent<Critter>();
        skills.Add(Instantiate(skill1,transform));
        skills.Add(Instantiate(skill2,transform));
        skills.Add(Instantiate(skill3,transform));
        foreach (var item in skills)
        {
            item.Setup(owner);
        }
    }
}
