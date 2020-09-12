﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AtkSkill : Skill
{
    [SerializeField]
    [Range(1,10)]
    protected int atkSkillPower;

    // Start is called before the first frame update
    public override void Setup()
    {
        skillType = SkillType.AttackSkill;
        skillPower = atkSkillPower;
    }
}
