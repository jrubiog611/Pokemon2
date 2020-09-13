using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [Header("Team")]
    [SerializeField]
    private GameObject critter1;
    [SerializeField]
    private GameObject critter2;
    [SerializeField]
    private GameObject critter3;

    private Critter[] team;

    private Critter currentCritter;
    private int CrittersLeft, currentCritterIndex;
    [SerializeField]
    private bool isIA;
    void Start()
    {
        if (isIA)
        {
            GameManager.Instance.IaTurnBegins += IATurnBegin;
        }
        team = new Critter[] { Instantiate(critter1,transform).GetComponent<Critter>(),
            Instantiate(critter2, transform).GetComponent<Critter>(),
            Instantiate(critter3, transform).GetComponent<Critter>() };

        CrittersLeft = team.Length;

        for (int i = 0; i < team.Length; i++)
        {
            team[i].Owner = this;
            team[i].gameObject.SetActive(false);
            if (!isIA)
            {
                team[i].transform.localScale = new Vector3(-team[i].transform.localScale.x, team[i].transform.localScale.y, team[i].transform.localScale.z);
                team[i].transform.position = GameManager.Instance.PlayerCritterPoint.position;
            }
            else
                team[i].transform.position = GameManager.Instance.EnemyCritterPoint.position;
        }
        InvokeCritter(team[0]);

    }


    public void RemoveCritter(Critter critter)
    {
        critter.gameObject.SetActive(false);
        GameManager.Instance.RemoveCombatCritter(critter);
        CrittersLeft--;
        currentCritterIndex++;
        if (CrittersLeft == 0)
        {
            if (isIA)
            {
                GameManager.Instance.PlayerWins();
            }
            else
                GameManager.Instance.IAWins();
        }
        else
        {
            InvokeCritter(team[currentCritterIndex]);
        }
    }
    public void InvokeCritter(Critter critterToInvoke)
    {
        currentCritter = critterToInvoke;
        currentCritter.gameObject.SetActive(true);
        GameManager.Instance.SetCombatCritter(currentCritter);
        if (!isIA)
        {
            AssingSkillsToButtons();
        }
    }

    private void AssingSkillsToButtons()
    {
        for (int i = 0; i <= 2; i++)
        {
            SkillButton skillbutton = GameManager.Instance.skillButtons[i];
            Skill skill = currentCritter.skillList.Skills[i];
            skillbutton.onSkill = null;
            skillbutton.skillName.text = skill.GetSkillName;
            skillbutton.skillDescription.text = skill.GetDescription;
            skillbutton.onSkill += skill.OnSkill;
        }
    }


    #region IA

    private void IATurnBegin()
    {
        if (CrittersLeft == 0)
        {
            //
            return;
        }
        StartCoroutine(IATurn());
    }

    private void IAUsingSkill(int index)
    {
        currentCritter.skillList.Skills[index].OnSkill();
    }
    private IEnumerator IATurn()
    {
        yield return new WaitForSeconds(1);
        int skillIndex = UnityEngine.Random.Range(0,3);
        print(skillIndex);
        IAUsingSkill(skillIndex);
        GameManager.Instance.PlayerTurnBegins();
    }

    #endregion
}
