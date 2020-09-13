using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool isAI;

    void Start()
    {
        team = new Critter[] { Instantiate(critter1,transform).GetComponent<Critter>(),
            Instantiate(critter2, transform).GetComponent<Critter>(),
            Instantiate(critter3, transform).GetComponent<Critter>() };

        CrittersLeft = team.Length;

        for (int i = 0; i < team.Length; i++)
        {
            team[i].Owner = this;
            team[i].gameObject.SetActive(false);
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
            print("perdi");
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
        if (!isAI)
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
            skillbutton.skillName.text = skill.GetSkillName;
            skillbutton.skillDescription.text = skill.GetDescription;
            skillbutton.button.onClick.AddListener(skill.OnSkill);
            skill.OnSkill();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
