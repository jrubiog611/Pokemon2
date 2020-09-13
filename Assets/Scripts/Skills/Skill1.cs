using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : SuppSkill
{
    public override void SetupSkill()
    {
        OnSkill += Skillsita1;
    }
    private void Skillsita1()
    {
        print("skill Name: " + skillName + "\n" + "Skill type: " + skillType + "\n" + "Skill Affinity: " + skillAffinity + "\n" + "Skill power: " + skillPower + "\n" 
            + "Description: " + description + "\n");
        owner.ModifyAtk(20);
        anim.SetTrigger("Play");
        // spdDown
        //GameManager.Instance.GetEnemy(owner).ModifySpd(-30);

        // Def Up
        //owner.ModifyDef(20);
    }

}
