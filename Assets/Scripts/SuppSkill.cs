using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SuppSkill : Skill
{
    // Start is called before the first frame update
    public override void Setup()
    {
        skillType = SkillType.SupportSkill;
        skillPower = 0;
    }
}
