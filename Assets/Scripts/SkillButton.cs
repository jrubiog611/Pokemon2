using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillButton : MonoBehaviour
{
    public Button button;
    public Text skillName;
    public Text skillDescription;
    public Action onSkill;
    private void Start()
    {
        button.onClick.AddListener(ExecuteSkillButton);
    }
    public void ExecuteSkillButton()
    {
        onSkill?.Invoke(); 
        GameManager.Instance.PlayerTurnEnd();
    }
}
