using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : AtkSkill
{
    public override void SetupSkill()
    {
        OnSkill += UsingSkill;
    }
    private void UsingSkill()
    {
        print("skill Name: " + skillName + "\n" + "Skill type: " + skillType + "\n" + "Skill Affinity: " + skillAffinity + "\n" + "Skill power: " + skillPower + "\n" + "Description: " + description + "\n");
        Health enemyHealth = GameManager.Instance.GetEnemy(owner).GetComponent<Health>();
        float dmg = owner.BaseAtk + skillPower;
        enemyHealth.TakeDamage(dmg, skillAffinity);
        anim.SetTrigger("Play");
    }
}
