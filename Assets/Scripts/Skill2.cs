using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : AtkSkill
{
    //[SerializeField]
    //private string skillName;

    //[SerializeField]
    //private string description;

    // Start is called before the first frame update
    public override void Setup()
    {
        base.Setup();
        SetupSkill();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupSkill()
    {
        skillName = skillName;
        //_description = description;
        OnSkill += Skillsita1;
    }

    private void Skillsita1()
    {
        print("skill Name: " + skillName + "\n" + "Skill type: " + skillType + "\n" + "Skill Affinity: " + skillAffinity + "\n" + "Skill power: " + skillPower + "\n" + "Description: " + description + "\n");
    }

}
