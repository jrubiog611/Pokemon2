using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Critter Critter1;

    public Critter Critter2;

    static GameManager instance;

    public SkillButton[] skillButtons;

    public static GameManager Instance { get => instance; }


    private void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
            instance = this;
    }

    public Critter GetEnemy(Critter critter)
    {
        return critter == Critter1 ? Critter2 : Critter1;
    }

    public void SetCombatCritter(Critter critter)
    {
        if (Critter1 == null)
        {
            Critter1 = critter;
            return;
        }
        if (Critter2 == null)
        {
            Critter2 = critter;
            return;
        }
        Debug.LogError("The game has already 2 combat Critters");
    }

    public void RemoveCombatCritter(Critter critter)
    {
        if (Critter1 == critter)
        {
            Critter1 = null;
            return;
        }
        if (Critter2 == critter)
        {
            Critter2 = null;
            return;
        }
        Debug.LogError("The critter: " + critter.name + "that are you trying to remove is not in combat");
    }

}
