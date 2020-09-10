using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    
    public bool playerTurn = true; // true for player, false for machine
    public GameObject playerUI;
    Critter currentCritterP1, currentCritterP2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnSwitch();
        }
    }

    private void TurnSwitch()
    {
        playerUI.SetActive(playerTurn);
        playerTurn = !playerTurn;
    }

    public void PlayerTurn(Skill skill)
    {
        Critter attacker;
        Critter target;

        if(playerTurn == true)
        {
            attacker = currentCritterP1;
            target = currentCritterP2;
        }
        else if (playerTurn == false)
        {
            attacker = currentCritterP2;
            target = currentCritterP1;
        }

        /*if(skilltype = attack)
        {
            target.currentHp -= skill.currentAtk;
        }
        else if(skilltype = support)
        {
            support effect
        }*/
    } 
}
