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

    private List<Skill> skills = new List<Skill>();

    public List<Skill> Skills
    {
        get
        {
            return skills;
        }
         
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseAllSkill()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].OnSkill();
        }
    }

    public void SetupAllSkills()
    {
        skills.Add(skill1);
        skills.Add(skill2);
        skills.Add(skill3);
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].Setup();
        }
    }
}
